using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

// Spawns the built `markupolation` CLI as a subprocess and exercises the scenarios documented in
// src/Markupolation.Cli/cli-manual-testing.md. This needs the CLI already built (dotnet build),
// so it is [Explicit] like GenerateTests/PlaygroundTests: run explicitly, e.g.
// dotnet test tests/Markupolation.Tests --filter "FullyQualifiedName~CliIntegrationTests"
[Explicit]
[Category("Integration")]
public class CliIntegrationTests
{
#if DEBUG
    private const string Configuration = "Debug";
#else
    private const string Configuration = "Release";
#endif

    private static readonly string CliDll = Directory.GetCurrentDirectory() + $@"\..\..\..\..\..\src\Markupolation.Cli\bin\{Configuration}\net10.0\Markupolation.Cli.dll";

    private readonly List<string> tempFiles = new();

    [OneTimeSetUp]
    public void EnsureCliIsBuilt()
    {
        File.Exists(CliDll).Should().BeTrue($"the CLI must be built first (dotnet build); looked for {CliDll}");
    }

    [TearDown]
    public void DeleteTempFiles()
    {
        foreach (var file in tempFiles)
        {
            File.Delete(file);
        }

        tempFiles.Clear();
    }

    [Test]
    public async Task No_arguments_prints_usage_and_exits_with_error()
    {
        var (exitCode, stdout, stderr) = await Run(null);

        exitCode.Should().Be(1);
        stdout.Should().StartWith("markupolation - converts HTML into Markupolation source");
        stderr.Should().BeEmpty();
    }

    [TestCase("--help")]
    [TestCase("-h")]
    public async Task Help_flag_prints_usage_and_exits_successfully(string flag)
    {
        var (exitCode, stdout, stderr) = await Run(null, flag);

        exitCode.Should().Be(0);
        stdout.Should().Contain("--output <file>  write to a file instead of standard output");
        stderr.Should().BeEmpty();
    }

    [Test]
    public async Task Convert_help_prints_usage_and_exits_successfully()
    {
        var (exitCode, stdout, stderr) = await Run(null, "convert", "--help");

        exitCode.Should().Be(0);
        stdout.Should().Contain("Usage:");
        stderr.Should().BeEmpty();
    }

    [TestCase("bogus")]
    [TestCase("--version")]
    public async Task Unknown_command_writes_error_and_exits_with_error(string command)
    {
        var (exitCode, stdout, stderr) = await Run(null, command);

        exitCode.Should().Be(1);
        Normalize(stderr).Should().Be($"Unknown command '{command}'.");
        stdout.Should().BeEmpty();
    }

    [Test]
    public async Task Stdin_is_converted_when_no_input_is_given()
    {
        var (exitCode, stdout, stderr) = await Run("""<div class="card"><h1 title="t">Hello</h1></div>""", "convert");

        exitCode.Should().Be(0);
        Normalize(stdout).Should().Be(Normalize("""
            div(class_("card"),
                h1(a.title("t"), "Hello")
            )
            """));
        stderr.Should().BeEmpty();
    }

    [Test]
    public async Task Stdin_dash_is_converted_the_same_as_implicit_stdin()
    {
        var (exitCode, stdout, stderr) = await Run("""<div class="card"><h1 title="t">Hello</h1></div>""", "convert", "-");

        exitCode.Should().Be(0);
        Normalize(stdout).Should().Be(Normalize("""
            div(class_("card"),
                h1(a.title("t"), "Hello")
            )
            """));
        stderr.Should().BeEmpty();
    }

    [Test]
    public async Task File_input_is_converted()
    {
        var file = CreateTempHtmlFile("""<div class="card"><h1 title="t">Hello</h1></div>""");

        var (exitCode, stdout, stderr) = await Run(null, "convert", file);

        exitCode.Should().Be(0);
        Normalize(stdout).Should().Be(Normalize("""
            div(class_("card"),
                h1(a.title("t"), "Hello")
            )
            """));
        stderr.Should().BeEmpty();
    }

    [Test]
    public async Task Missing_file_writes_error_and_exits_with_error()
    {
        var missing = Path.Combine(Path.GetTempPath(), $"does-not-exist-{Guid.NewGuid():N}.html");

        var (exitCode, stdout, stderr) = await Run(null, "convert", missing);

        exitCode.Should().Be(1);
        Normalize(stderr).Should().Be($"No such file: {missing}");
        stdout.Should().BeEmpty();
    }

    [Test]
    public async Task Fragment_flag_forces_fragment_output_for_a_whole_document()
    {
        var (exitCode, stdout, stderr) = await Run("<!DOCTYPE html><html><body><p>x</p></body></html>", "convert", "--fragment");

        exitCode.Should().Be(0);
        Normalize(stdout).Should().Be("""p("x")""");
        stderr.Should().BeEmpty();
    }

    [Test]
    public async Task Document_flag_forces_a_document_wrapper_for_a_fragment()
    {
        var (exitCode, stdout, stderr) = await Run("<p>x</p>", "convert", "--document");

        exitCode.Should().Be(0);
        Normalize(stdout).Should().StartWith("html(");
        stderr.Should().BeEmpty();
    }

    [Test]
    public async Task No_aliases_flag_emits_unqualified_ambiguous_names()
    {
        var (exitCode, stdout, stderr) = await Run("<html><head><title>T</title></head><body></body></html>", "convert", "--no-aliases");

        exitCode.Should().Be(0);
        stdout.Should().Contain("title(\"T\")");
        stdout.Should().NotContain("e.title(");
        stderr.Should().BeEmpty();
    }

    [Test]
    public async Task Indent_flag_controls_indentation()
    {
        var (exitCode, stdout, stderr) = await Run("<div><p>x</p></div>", "convert", "--indent", "2");

        exitCode.Should().Be(0);
        Normalize(stdout).Should().Be("div(\n  p(\"x\")\n)");
        stderr.Should().BeEmpty();
    }

    [TestCase("-1")]
    [TestCase("notanumber")]
    public async Task Indent_flag_rejects_invalid_values(string value)
    {
        var (exitCode, stdout, stderr) = await Run("<p>x</p>", "convert", "--indent", value);

        exitCode.Should().Be(1);
        Normalize(stderr).Should().Be("--indent needs a non-negative number.");
        stdout.Should().BeEmpty();
    }

    [Test]
    public async Task Indent_flag_requires_a_value()
    {
        var (exitCode, stdout, stderr) = await Run("<p>x</p>", "convert", "--indent");

        exitCode.Should().Be(1);
        Normalize(stderr).Should().Be("--indent needs a non-negative number.");
        stdout.Should().BeEmpty();
    }

    [Test]
    public async Task Output_flag_writes_to_a_file_instead_of_stdout()
    {
        var output = Path.Combine(Path.GetTempPath(), $"markupolation-cli-test-{Guid.NewGuid():N}.cs");
        tempFiles.Add(output);

        var (exitCode, stdout, stderr) = await Run("<p>x</p>", "convert", "--output", output);

        exitCode.Should().Be(0);
        stdout.Should().BeEmpty();
        stderr.Should().BeEmpty();
        File.ReadAllText(output).Should().Be("""p("x")""");
    }

    [Test]
    public async Task Output_flag_requires_a_value()
    {
        var (exitCode, stdout, stderr) = await Run("<p>x</p>", "convert", "--output");

        exitCode.Should().Be(1);
        Normalize(stderr).Should().Be("--output needs a file.");
        stdout.Should().BeEmpty();
    }

    [Test]
    public async Task Unknown_option_writes_error_and_exits_with_error()
    {
        var (exitCode, stdout, stderr) = await Run("<p>x</p>", "convert", "--nope");

        exitCode.Should().Be(1);
        Normalize(stderr).Should().Be("Unknown option '--nope'.");
        stdout.Should().BeEmpty();
    }

    [Test]
    public async Task Last_positional_argument_wins_when_multiple_are_given()
    {
        var first = CreateTempHtmlFile("<p>first</p>");
        var second = CreateTempHtmlFile("<p>second</p>");

        var (exitCode, stdout, stderr) = await Run(null, "convert", first, second);

        exitCode.Should().Be(0);
        Normalize(stdout).Should().Be("""p("second")""");
        stderr.Should().BeEmpty();
    }

    private static string Normalize(string value) => value.ReplaceLineEndings("\n").Trim('\n');

    private string CreateTempHtmlFile(string html)
    {
        var path = Path.Combine(Path.GetTempPath(), $"markupolation-cli-test-{Guid.NewGuid():N}.html");
        File.WriteAllText(path, html);
        tempFiles.Add(path);
        return path;
    }

    private static async Task<(int ExitCode, string StandardOutput, string StandardError)> Run(string? input, params string[] args)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8,
        };
        startInfo.ArgumentList.Add(CliDll);
        foreach (var arg in args)
        {
            startInfo.ArgumentList.Add(arg);
        }

        using var process = Process.Start(startInfo)!;

        if (!string.IsNullOrEmpty(input))
        {
            await process.StandardInput.WriteAsync(input).ConfigureAwait(false);
        }

        process.StandardInput.Close();

        var stdoutTask = process.StandardOutput.ReadToEndAsync();
        var stderrTask = process.StandardError.ReadToEndAsync();
        await Task.WhenAll(stdoutTask, stderrTask).ConfigureAwait(false);
        await process.WaitForExitAsync().ConfigureAwait(false);

        return (process.ExitCode, await stdoutTask, await stderrTask);
    }
}
