# Markupolation Benchmark

> `Markupolation` vs [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-6.0) vs [String.Format](https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=net-6.0) vs [HtmlTags](https://github.com/HtmlTags/htmltags) vs [HyperTextExpression](https://github.com/T0shik/HyperTextExpression) vs [RazorSlices](https://github.com/DamianEdwards/RazorSlices)

```ini
BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
```

## Markupolation.Benchmark.BasicUsage

| Method              | Mean        | Error     | StdDev    | Median      |
|-------------------- |------------:|----------:|----------:|------------:|
| StringBuilder       |    31.45 ns |  0.410 ns |  0.384 ns |    31.45 ns |
| StringFormat        |    85.86 ns |  0.763 ns |  0.637 ns |    85.78 ns |
| Markupolation       |   998.48 ns | 19.606 ns | 45.829 ns |   976.00 ns |
| HtmlTags            | 1,916.66 ns | 21.277 ns | 17.767 ns | 1,917.32 ns |
| HyperTextExpression |   370.65 ns |  4.091 ns |  3.626 ns |   370.18 ns |
| RazorSlices         |   253.07 ns |  4.717 ns |  4.413 ns |   251.39 ns |

## Markupolation.Benchmark.AdvancedUsage

| Method              | Mean      | Error     | StdDev    |
|-------------------- |----------:|----------:|----------:|
| StringBuilder       |  1.336 μs | 0.0131 μs | 0.0123 μs |
| StringFormat        | 45.456 μs | 0.8806 μs | 0.8238 μs |
| Markupolation       | 34.764 μs | 0.4018 μs | 0.3562 μs |
| HtmlTags            | 51.494 μs | 0.8077 μs | 0.7160 μs |
| HyperTextExpression | 13.999 μs | 0.3803 μs | 1.1213 μs |
| RazorSlices         |  7.241 μs | 0.1448 μs | 0.2957 μs |
