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
| StringBuilder       |    29.64 ns |  0.321 ns |  0.251 ns |  1.00 |    0.01 | 0.0554 |     232 B |        1.00 |
| StringFormat        |    78.59 ns |  1.132 ns |  1.059 ns |  2.65 |    0.04 | 0.0554 |     232 B |        1.00 |
| Markupolation       |   184.07 ns |  2.791 ns |  2.474 ns |  6.21 |    0.10 | 0.2773 |    1160 B |        5.00 |
| HtmlTags            | 1,221.71 ns | 17.045 ns | 15.944 ns | 41.22 |    0.62 | 1.2989 |    5440 B |       23.45 |
| HyperTextExpression |   297.33 ns |  4.892 ns |  4.085 ns | 10.03 |    0.16 | 0.3366 |    1408 B |        6.07 |
| RazorSlices         |   351.75 ns |  5.398 ns |  4.785 ns | 11.87 |    0.18 | 0.1392 |     584 B |        2.52 |

## Markupolation.Benchmark.AdvancedUsage

An html5 head plus a FizzBuzz `<ul>` over `Enumerable.Range(1, 100)`.

| Method              | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0     | Gen1   | Allocated | Alloc Ratio |
|-------------------- |----------:|----------:|----------:|------:|--------:|---------:|-------:|----------:|------------:|
| StringBuilder       |  1.193 μs | 0.0103 μs | 0.0086 μs |  1.00 |    0.01 |   0.9575 |      - |   3.91 KB |        1.00 |
| StringFormat        | 45.460 μs | 0.7840 μs | 1.2881 μs | 38.10 |    1.10 | 161.9873 |      - | 661.55 KB |      169.02 |
| Markupolation       |  7.758 μs | 0.1009 μs | 0.0944 μs |  6.50 |    0.09 |  11.1389 | 0.0153 |  45.53 KB |       11.63 |
| HtmlTags            | 34.716 μs | 0.2381 μs | 0.1988 μs | 29.10 |    0.26 |  32.4707 | 0.0610 | 132.63 KB |       33.89 |
| HyperTextExpression | 10.500 μs | 0.1897 μs | 0.1584 μs |  8.80 |    0.14 |   9.0790 |      - |  37.17 KB |        9.50 |
| RazorSlices         |  4.762 μs | 0.0783 μs | 0.0611 μs |  3.99 |    0.06 |   2.8000 | 0.0076 |  11.48 KB |        2.93 |

## Markupolation.Benchmark.DeepNesting

Twenty nested `<div>` elements around a single text node. Nesting depth, rather than sibling
count, is what makes an eagerly rendered tree expensive: every level re-copies the whole subtree
rendered beneath it.

| Method        | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------- |-----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| StringBuilder |   226.1 ns |  1.82 ns |  1.52 ns |  1.00 |    0.01 | 0.2732 |   1.12 KB |        1.00 |
| Markupolation | 2,334.8 ns | 35.07 ns | 31.09 ns | 10.33 |    0.15 | 4.3716 |  17.86 KB |       15.99 |

## Since 2.1.0

Precomputing the element and attribute name tables, rendering each element in a single sized pass,
and adding a `net10.0` target that builds into one exactly-sized buffer with `string.Create`:

| Benchmark | 2.1.0 | current | Time | Allocated |
|---------- |------:|--------:|-----:|----------:|
| BasicUsage    | 869.57 ns / 2,700 B  | 184.07 ns / 1,160 B  | 4.7x | 2.3x less |
| AdvancedUsage | 30.32 us / 87.43 KB  | 7.76 us / 45.53 KB   | 3.9x | 1.9x less |
| DeepNesting   | 7,273 ns / 26.60 KB  | 2,335 ns / 17.86 KB  | 3.1x | 1.5x less |

Output is unchanged: byte for byte identical to 2.1.0.
