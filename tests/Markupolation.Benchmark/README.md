# Markupolation Benchmark

> `Markupolation` vs [StringBuilder](https://learn.microsoft.com/dotnet/api/system.text.stringbuilder) vs [String.Format](https://learn.microsoft.com/dotnet/api/system.string.format) vs [HtmlTags](https://github.com/HtmlTags/htmltags) vs [HyperTextExpression](https://github.com/T0shik/HyperTextExpression) vs [RazorSlices](https://github.com/DamianEdwards/RazorSlices)

Run it with:

```
dotnet run -c Release
```

That measures the **published** `Markupolation.Extensions` package. To measure the working tree
instead, set the `MarkupolationLocal` environment variable first — it has to be an environment
variable rather than `-p:`, because BenchmarkDotNet builds its own generated project in a child
process that does not inherit `-p:` properties:

```powershell
$env:MarkupolationLocal='true'; dotnet run -c Release
```

`StringBuilder` is the baseline in every table: it is the floor, not a realistic alternative.

```ini
BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.7725/22H2/2022Update)
Intel Core i7-6700 CPU 3.40GHz (Max: 3.41GHz) (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.401
  [Host]     : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3

```

The `Markupolation` rows below were measured from source, ahead of the 3.0.0 release.

## Markupolation.Benchmark.BasicUsage

A minimal document: `<!DOCTYPE html>` + `html` > `head` > `title`, `body` > `h1`.

| Method              | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| StringBuilder       |    28.20 ns |  0.502 ns |  0.635 ns |  1.00 |    0.03 | 0.0554 |     232 B |        1.00 |
| StringFormat        |    80.00 ns |  1.464 ns |  1.223 ns |  2.84 |    0.07 | 0.0554 |     232 B |        1.00 |
| Markupolation       |   205.29 ns |  3.403 ns |  3.919 ns |  7.28 |    0.21 | 0.2906 |    1216 B |        5.24 |
| HtmlTags            | 1,233.24 ns | 19.629 ns | 17.400 ns | 43.75 |    1.11 | 1.2989 |    5440 B |       23.45 |
| HyperTextExpression |   305.00 ns |  4.818 ns |  3.762 ns | 10.82 |    0.27 | 0.3366 |    1408 B |        6.07 |
| RazorSlices         |   357.89 ns |  2.023 ns |  1.689 ns | 12.70 |    0.28 | 0.1392 |     584 B |        2.52 |

## Markupolation.Benchmark.AdvancedUsage

An html5 head plus a FizzBuzz `<ul>` over `Enumerable.Range(1, 100)`.

| Method              | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0     | Gen1   | Allocated | Alloc Ratio |
|-------------------- |----------:|----------:|----------:|------:|--------:|---------:|-------:|----------:|------------:|
| StringBuilder       |  1.198 μs | 0.0234 μs | 0.0261 μs |  1.00 |    0.03 |   0.9575 |      - |   3.91 KB |        1.00 |
| StringFormat        | 44.729 μs | 0.5380 μs | 0.5032 μs | 37.36 |    0.87 | 161.9873 |      - | 661.55 KB |      169.02 |
| Markupolation       |  8.959 μs | 0.1265 μs | 0.1122 μs |  7.48 |    0.18 |  11.3678 |      - |  46.48 KB |       11.88 |
| HtmlTags            | 35.113 μs | 0.4905 μs | 0.4348 μs | 29.33 |    0.70 |  32.4707 | 0.0610 | 132.63 KB |       33.89 |
| HyperTextExpression | 10.578 μs | 0.1466 μs | 0.1372 μs |  8.84 |    0.21 |   9.0790 |      - |  37.17 KB |        9.50 |
| RazorSlices         |  4.634 μs | 0.0290 μs | 0.0226 μs |  3.87 |    0.08 |   2.8000 | 0.0076 |  11.48 KB |        2.93 |

## Markupolation.Benchmark.DeepNesting

Twenty nested `<div>` elements around a single text node. Nesting depth, rather than sibling
count, is what makes an eagerly rendered tree expensive: every level re-copies the whole subtree
rendered beneath it.

| Method        | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------- |-----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| StringBuilder |   219.3 ns |  2.80 ns |  2.99 ns |  1.00 |    0.02 | 0.2735 |   1.12 KB |        1.00 |
| Markupolation | 2,497.5 ns | 49.96 ns | 44.29 ns | 11.39 |    0.24 | 4.4594 |  18.23 KB |       16.31 |

## Since 2.1.0

Precomputing the element and attribute name tables, rendering each element in a single sized pass,
and adding a `net10.0` target that builds into one exactly-sized buffer with `string.Create`:

| Benchmark | 2.1.0 | current | Time | Allocated |
|---------- |------:|--------:|-----:|----------:|
| BasicUsage    | 869.57 ns / 2,700 B  | 205.29 ns / 1,216 B  | 4.2x | 2.2x less |
| AdvancedUsage | 30.32 us / 87.43 KB  | 8.96 us / 46.48 KB   | 3.4x | 1.9x less |
| DeepNesting   | 7,273 ns / 26.60 KB  | 2,497 ns / 18.23 KB  | 2.9x | 1.5x less |

Roughly 7-15% of the remaining time is the encoder introduced in 3.0. It scans for `& < > "` and
returns the input untouched when there is none, which is the common case; the extra allocation is
one 8-byte field per node, for the interpolated string handler.

Output for markup that needs no encoding is byte for byte what 2.1.0 produced.
