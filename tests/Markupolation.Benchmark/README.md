# Markupolation Benchmark

> Markupolation vs [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-6.0) vs [String.Format](https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=net-6.0) vs [HtmlTags](https://github.com/HtmlTags/htmltags)

## Markupolation.Benchmark.BasicUsage

```ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1415 (21H2)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
```

|        Method |        Mean |     Error |    StdDev |
|-------------- |------------:|----------:|----------:|
| StringBuilder |    45.97 ns |  0.349 ns |  0.500 ns |
|  StringFormat |   186.36 ns |  2.915 ns |  2.276 ns |
| Markupolation | 1,343.02 ns |  8.996 ns |  8.415 ns |
|      HtmlTags | 2,022.25 ns | 18.516 ns | 16.414 ns |

## Markupolation.Benchmark.AdvancedUsage

```ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1415 (21H2)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
```

|        Method |      Mean |     Error |    StdDev |
|-------------- |----------:|----------:|----------:|
| StringBuilder |  3.471 μs | 0.0438 μs | 0.0538 μs |
|  StringFormat | 49.777 μs | 0.1782 μs | 0.1391 μs |
| Markupolation | 45.832 μs | 0.1841 μs | 0.1632 μs |
|      HtmlTags | 53.477 μs | 0.3632 μs | 0.3397 μs |
