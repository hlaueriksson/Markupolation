# Markupolation Benchmark

> Markupolation vs [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-6.0) vs [String.Format](https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=net-6.0) vs [HtmlTags](https://github.com/HtmlTags/htmltags) vs [HyperTextExpression](https://github.com/T0shik/HyperTextExpression)

## Markupolation.Benchmark.BasicUsage

```ini
BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
```

| Method              | Mean        | Error     | StdDev    |
|-------------------- |------------:|----------:|----------:|
| StringBuilder       |    29.10 ns |  0.520 ns |  0.434 ns |
| StringFormat        |    81.32 ns |  1.688 ns |  1.579 ns |
| Markupolation       |   937.99 ns | 13.515 ns | 13.878 ns |
| HtmlTags            | 1,762.68 ns | 25.169 ns | 23.543 ns |
| HyperTextExpression |   326.56 ns |  2.898 ns |  2.710 ns |

## Markupolation.Benchmark.AdvancedUsage

```ini
BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
```

| Method              | Mean      | Error     | StdDev    |
|-------------------- |----------:|----------:|----------:|
| StringBuilder       |  1.245 μs | 0.0175 μs | 0.0155 μs |
| StringFormat        | 43.422 μs | 0.8661 μs | 0.8506 μs |
| Markupolation       | 33.569 μs | 0.2139 μs | 0.1786 μs |
| HtmlTags            | 49.504 μs | 0.3266 μs | 0.2728 μs |
| HyperTextExpression | 11.309 μs | 0.2245 μs | 0.2205 μs |
