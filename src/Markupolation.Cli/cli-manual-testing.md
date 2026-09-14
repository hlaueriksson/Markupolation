# Manual test matrix for the `markupolation` CLI

Manual walkthrough of every argument/flag in `src/Markupolation.Cli/Program.cs` (the `dotnet tool` wrapper around `Markupolation.Converter`). There is no CLI-specific automated test suite — only `tests/Markupolation.Tests/Converter/HtmlConverterTests.cs`, which tests the converter library directly, not argument parsing — so this is the way to exercise `Program.cs`'s hand-rolled arg parser end to end.

## Setup (once)

`dotnet run --no-build` needs a prior build and needs to be invoked from the CLI project directory:

```powershell
dotnet build
cd src\Markupolation.Cli
```

All commands below assume the working directory is `src\Markupolation.Cli`. Two throwaway fixture files are used by some cases — create them first:

```powershell
'<div class="card"><h1 title="t">Hello</h1></div>' | Out-File -Encoding utf8 test.html
'<p>Göteborg, naïve café</p>' | Out-File -Encoding utf8 unicode.html
```

## Commands, grouped by what they exercise

### Top-level / help / unknown command

```powershell
dotnet run --no-build --
dotnet run --no-build -- --help
dotnet run --no-build -- -h
dotnet run --no-build -- bogus
dotnet run --no-build -- --version
```
Expect: no-args -> usage text, **exit 1**. `--help`/`-h` -> usage text, **exit 0**. `bogus` -> `Unknown command 'bogus'.`, exit 1. `--version` -> `Unknown command '--version'.`, exit 1 (no version flag exists).

### Stdin input (default happy path)

```powershell
'<div class="card"><h1>Hi</h1><input type="checkbox" checked></div>' | dotnet run --no-build -- convert
'<div class="card"><h1>Hi</h1><input type="checkbox" checked></div>' | dotnet run --no-build -- convert -
```
Expect identical output; both read stdin (README canonical example, `Markupolation.Cli.md`).

### File input

```powershell
dotnet run --no-build -- convert test.html
dotnet run --no-build -- convert does-not-exist.html
```
Expect: first succeeds; second -> `No such file: does-not-exist.html`, exit 1.

### `--fragment` / `--document`

```powershell
'<!DOCTYPE html><html lang="en"><head></head><body><p>x</p></body></html>' | dotnet run --no-build -- convert --fragment
'<p>x</p>' | dotnet run --no-build -- convert --document
'<p>x</p>' | dotnet run --no-build -- convert --fragment --document
```
Expect: 1st forces fragment-only output despite a full document input. 2nd forces a full document wrapper despite a fragment input. 3rd: no error, last flag wins (`Fragment=false`, i.e. behaves like `--document`).

### `--no-aliases`

```powershell
'<html><head><title>T</title></head><body></body></html>' | dotnet run --no-build -- convert
'<html><head><title>T</title></head><body></body></html>' | dotnet run --no-build -- convert --no-aliases
```
Expect: default output qualifies the ambiguous `title` as `e.title(...)`; `--no-aliases` emits the unqualified/collision form instead.

### `--indent <n>`

```powershell
'<div><p>x</p></div>' | dotnet run --no-build -- convert --indent 2
'<div><p>x</p></div>' | dotnet run --no-build -- convert --indent 0
'<div><p>x</p></div>' | dotnet run --no-build -- convert --indent -1
'<div><p>x</p></div>' | dotnet run --no-build -- convert --indent notanumber
'<div><p>x</p></div>' | dotnet run --no-build -- convert --indent
```
Expect: 2 and 0 succeed with that many spaces per level (default is 4, so compare against `dotnet run --no-build -- convert` with the same input). Negative, non-numeric, and missing-value all -> `--indent needs a non-negative number.`, exit 1.

### `--output <file>`

```powershell
'<p>x</p>' | dotnet run --no-build -- convert --output out.cs
Get-Content out.cs
'<p>x</p>' | dotnet run --no-build -- convert --output
'<p>x</p>' | dotnet run --no-build -- convert --output nosuchdir\out.cs
```
Expect: 1st writes the converted source to `out.cs` (no console output, no trailing newline appended). 2nd -> `--output needs a file.`, exit 1. 3rd -> unhandled exception/stack trace (no directory-existence check in `Program.cs`) — useful to confirm this known gap.

### Unknown option under `convert`

```powershell
'<p>x</p>' | dotnet run --no-build -- convert --nope
```
Expect: `Unknown option '--nope'.`, exit 1.

### Multiple positional args (last one wins)

```powershell
dotnet run --no-build -- convert test.html unicode.html
```
Expect: no error; only `unicode.html` (the last positional) is actually converted.

### `convert --help`

```powershell
dotnet run --no-build -- convert --help
```
Expect: same usage text as top-level `--help`, exit 0 (the help scan checks the whole `args` array, not just `args[0]`).

### Combined-flags smoke test

```powershell
dotnet run --no-build -- convert --fragment --no-aliases --indent 2 --output combined.cs test.html
Get-Content combined.cs
```
Expect: all flags apply together — fragment output, no `e.`/`a.` aliasing, 2-space indent, written to `combined.cs`.

### Encoding / off-spec inputs (optional extra coverage)

```powershell
dotnet run --no-build -- convert unicode.html
'<div hx-get="/x"></div>' | dotnet run --no-build -- convert
'<my-widget a="1"></my-widget>' | dotnet run --no-build -- convert
'<p><svg viewBox="0 0 1 1"></svg></p>' | dotnet run --no-build -- convert
```
Expect: non-ASCII round-trips correctly; off-spec attribute falls back to `new A("hx-get", "/x")`; off-spec element falls back to `new E(...)`; SVG (foreign content) kept verbatim as `new E("""<svg .../>""")`.

## Cleanup

```powershell
Remove-Item test.html, unicode.html, out.cs, combined.cs -ErrorAction SilentlyContinue
```

## Verification

Running through the list above exercises every flag (`--fragment`, `--document`, `--no-aliases`, `--indent`, `--output`, `--help`/`-h`), every input mode (stdin via `-`/implicit, file, missing file), every documented error path (unknown command, unknown option, bad `--indent`, missing `--output` value), and the two edge behaviors worth knowing about (`--fragment`/`--document` last-wins, multiple positional args last-wins). No automated test changes are needed — this is a manual walkthrough of `src/Markupolation.Cli/Program.cs`.
