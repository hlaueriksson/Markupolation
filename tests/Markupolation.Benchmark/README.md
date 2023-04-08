# Markupolation Benchmark

> Markupolation vs [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-6.0) vs [String.Format](https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=net-6.0) vs [HtmlTags](https://github.com/HtmlTags/htmltags)

## Markupolation.Benchmark.BasicUsage

``` ini
BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2788/22H2/2022Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
```

|        Method |        Mean |     Error |    StdDev |
|-------------- |------------:|----------:|----------:|
| StringBuilder |    44.43 ns |  0.460 ns |  0.384 ns |
|  StringFormat |   177.91 ns |  2.609 ns |  2.563 ns |
| Markupolation | 1,270.29 ns | 23.338 ns | 20.689 ns |
|      HtmlTags | 1,961.49 ns | 17.428 ns | 15.449 ns |

## Markupolation.Benchmark.AdvancedUsage

``` ini
BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2788/22H2/2022Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
```

|        Method |      Mean |     Error |    StdDev |
|-------------- |----------:|----------:|----------:|
| StringBuilder |  3.282 μs | 0.0231 μs | 0.0216 μs |
|  StringFormat | 46.334 μs | 0.7179 μs | 0.6715 μs |
| Markupolation | 43.967 μs | 0.3525 μs | 0.3125 μs |
|      HtmlTags | 51.795 μs | 0.8292 μs | 0.6924 μs |
