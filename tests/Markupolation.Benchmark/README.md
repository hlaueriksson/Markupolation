# Markupolation Benchmark

This is slow 😭

## Markupolation.Benchmark.BasicUsage

```ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
```

|        Method |        Mean |     Error |    StdDev |
|-------------- |------------:|----------:|----------:|
| StringBuilder |    47.91 ns |  0.665 ns |  0.622 ns |
|  StringFormat |   196.46 ns |  3.537 ns |  4.599 ns |
| Markupolation | 1,378.09 ns | 13.682 ns | 12.128 ns |

## Markupolation.Benchmark.AdvancedUsage

```ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
```

|        Method |          Mean |         Error |        StdDev |
|-------------- |--------------:|--------------:|--------------:|
| StringBuilder |      3.674 μs |     0.0372 μs |     0.0330 μs |
|  StringFormat |     51.402 μs |     0.6351 μs |     0.5941 μs |
| Markupolation | 87,966.842 μs | 1,324.6383 μs | 1,239.0675 μs |
