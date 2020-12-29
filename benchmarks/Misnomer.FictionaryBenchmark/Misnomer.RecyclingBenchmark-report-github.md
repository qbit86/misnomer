``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-HMGETO : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-YFYZGE : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-HLWQED : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-YOXKOE : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-DASTXD : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-XCUMFN : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Platform=X64  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|     Method |        Job |       Jit |       Runtime |     Mean |     Error |    StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|----------- |----------- |---------- |-------------- |---------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|
| Dictionary | Job-HMGETO | LegacyJit |    .NET 4.6.1 | 4.543 ms | 5.3017 ms | 0.2906 ms |  1.00 |    0.00 | 234.3750 | 164.0625 | 164.0625 | 1105250 B |
| Fictionary | Job-HMGETO | LegacyJit |    .NET 4.6.1 | 4.176 ms | 0.1372 ms | 0.0075 ms |  0.92 |    0.06 | 125.0000 | 117.1875 | 117.1875 |  529856 B |
|            |            |           |               |          |           |           |       |         |          |          |          |           |
| Dictionary | Job-YFYZGE | LegacyJit |      .NET 4.8 | 4.370 ms | 0.3249 ms | 0.0178 ms |  1.00 |    0.00 | 234.3750 | 164.0625 | 164.0625 | 1105245 B |
| Fictionary | Job-YFYZGE | LegacyJit |      .NET 4.8 | 4.182 ms | 1.1650 ms | 0.0639 ms |  0.96 |    0.02 | 125.0000 | 117.1875 | 117.1875 |  529856 B |
|            |            |           |               |          |           |           |       |         |          |          |          |           |
| Dictionary | Job-HLWQED |    RyuJit |    .NET 4.6.1 | 4.329 ms | 0.1714 ms | 0.0094 ms |  1.00 |    0.00 | 234.3750 | 164.0625 | 164.0625 | 1105250 B |
| Fictionary | Job-HLWQED |    RyuJit |    .NET 4.6.1 | 4.160 ms | 0.4248 ms | 0.0233 ms |  0.96 |    0.01 | 125.0000 | 117.1875 | 117.1875 |  529856 B |
|            |            |           |               |          |           |           |       |         |          |          |          |           |
| Dictionary | Job-YOXKOE |    RyuJit |      .NET 4.8 | 4.433 ms | 1.3714 ms | 0.0752 ms |  1.00 |    0.00 | 234.3750 | 164.0625 | 164.0625 | 1105245 B |
| Fictionary | Job-YOXKOE |    RyuJit |      .NET 4.8 | 4.186 ms | 1.0143 ms | 0.0556 ms |  0.94 |    0.02 | 125.0000 | 117.1875 | 117.1875 |  529856 B |
|            |            |           |               |          |           |           |       |         |          |          |          |           |
| Dictionary | Job-TWMBVS |    RyuJit | .NET Core 2.1 |       NA |        NA |        NA |     ? |       ? |        - |        - |        - |         - |
| Fictionary | Job-TWMBVS |    RyuJit | .NET Core 2.1 |       NA |        NA |        NA |     ? |       ? |        - |        - |        - |         - |
|            |            |           |               |          |           |           |       |         |          |          |          |           |
| Dictionary | Job-DASTXD |    RyuJit | .NET Core 3.1 | 4.473 ms | 0.3315 ms | 0.0182 ms |  1.00 |    0.00 | 234.3750 | 164.0625 | 164.0625 | 1103584 B |
| Fictionary | Job-DASTXD |    RyuJit | .NET Core 3.1 | 4.377 ms | 0.9838 ms | 0.0539 ms |  0.98 |    0.01 |  78.1250 |  78.1250 |  78.1250 |  384376 B |
|            |            |           |               |          |           |           |       |         |          |          |          |           |
| Dictionary | Job-XCUMFN |    RyuJit | .NET Core 5.0 | 2.377 ms | 1.5089 ms | 0.0827 ms |  1.00 |    0.00 | 246.0938 | 164.0625 | 164.0625 | 1103688 B |
| Fictionary | Job-XCUMFN |    RyuJit | .NET Core 5.0 | 2.210 ms | 0.1289 ms | 0.0071 ms |  0.93 |    0.03 |  82.0313 |  82.0313 |  82.0313 |  384401 B |

Benchmarks with issues:
  RecyclingBenchmark.Dictionary: Job-TWMBVS(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  RecyclingBenchmark.Fictionary: Job-TWMBVS(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
