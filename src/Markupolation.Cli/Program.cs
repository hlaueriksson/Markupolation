using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Markupolation.Converter;

namespace Markupolation.Cli;

/// <summary>
/// Converts HTML into Markupolation source.
/// </summary>
internal static class Program
{
    private const string Usage = """
        markupolation - converts HTML into Markupolation source

        Usage:
          markupolation convert <file>     convert a file
          markupolation convert -          convert standard input
          ... | markupolation convert      the same

        Options:
          --fragment       emit the nodes as given, with no html/head/body wrapper
          --document       emit a whole document, even if the input is a fragment
          --no-aliases     do not qualify ambiguous names with e. and a.
          --indent <n>     spaces per level (default 4)
          --output <file>  write to a file instead of standard output
          --help           show this
        """;

    private static async Task<int> Main(string[] args)
    {
        args ??= [];

        if (args.Length == 0 || Array.IndexOf(args, "--help") >= 0 || Array.IndexOf(args, "-h") >= 0)
        {
            await Console.Out.WriteLineAsync(Usage).ConfigureAwait(false);
            return args.Length == 0 ? 1 : 0;
        }

        if (!string.Equals(args[0], "convert", StringComparison.Ordinal))
        {
            await Console.Error.WriteLineAsync($"Unknown command '{args[0]}'.").ConfigureAwait(false);
            return 1;
        }

        var (arguments, error) = Parse(args);

        if (error != null)
        {
            await Console.Error.WriteLineAsync(error).ConfigureAwait(false);
            return 1;
        }

        return await Run(arguments!).ConfigureAwait(false);
    }

    private static (Arguments? Arguments, string? Error) Parse(string[] args)
    {
        var arguments = new Arguments();

        for (var i = 1; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--fragment":
                    arguments.Options = arguments.Options with { Fragment = true };
                    break;
                case "--document":
                    arguments.Options = arguments.Options with { Fragment = false };
                    break;
                case "--no-aliases":
                    arguments.Options = arguments.Options with { Aliases = false };
                    break;
                case "--indent":
                    if (++i >= args.Length
                        || !int.TryParse(args[i], NumberStyles.Integer, CultureInfo.InvariantCulture, out var indent)
                        || indent < 0)
                    {
                        return (null, "--indent needs a non-negative number.");
                    }

                    arguments.Options = arguments.Options with { Indent = indent };
                    break;
                case "--output":
                    if (++i >= args.Length)
                    {
                        return (null, "--output needs a file.");
                    }

                    arguments.Output = args[i];
                    break;
                default:
                    if (args[i].StartsWith("--", StringComparison.Ordinal))
                    {
                        return (null, $"Unknown option '{args[i]}'.");
                    }

                    arguments.Input = args[i];
                    break;
            }
        }

        return (arguments, null);
    }

    private static async Task<int> Run(Arguments arguments)
    {
        string html;

        if (arguments.Input == null || string.Equals(arguments.Input, "-", StringComparison.Ordinal))
        {
            html = await Console.In.ReadToEndAsync().ConfigureAwait(false);
        }
        else if (!File.Exists(arguments.Input))
        {
            await Console.Error.WriteLineAsync($"No such file: {arguments.Input}").ConfigureAwait(false);
            return 1;
        }
        else
        {
            html = await File.ReadAllTextAsync(arguments.Input).ConfigureAwait(false);
        }

        var source = HtmlConverter.Convert(html, arguments.Options);

        if (arguments.Output == null)
        {
            await Console.Out.WriteLineAsync(source).ConfigureAwait(false);
        }
        else
        {
            await File.WriteAllTextAsync(arguments.Output, source).ConfigureAwait(false);
        }

        return 0;
    }

    private sealed class Arguments
    {
        internal string? Input { get; set; }

        internal string? Output { get; set; }

        internal ConvertOptions Options { get; set; } = new();
    }
}
