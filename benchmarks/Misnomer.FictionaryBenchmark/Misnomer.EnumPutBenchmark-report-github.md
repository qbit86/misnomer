``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-OVLLTG : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-USOUXK : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-QXMNCR : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-ISGIVZ : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-QYBJCC : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-DBXHFL : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Platform=X64  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                        Method |        Job |       Jit |       Runtime |     Mean |     Error |   StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------ |----------- |---------- |-------------- |---------:|----------:|---------:|------:|--------:|--------:|------:|------:|----------:|
|       DictionaryConcreteValue | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 60.22 μs | 40.393 μs | 2.214 μs |  1.09 |    0.04 | 71.2891 |     - |     - |   39136 B |
|       FictionaryConcreteValue | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 41.12 μs |  3.276 μs | 0.180 μs |  0.75 |    0.00 | 14.8926 |     - |     - |    7941 B |
|   DictionaryConcreteReference | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 55.01 μs |  0.661 μs | 0.036 μs |  1.00 |    0.00 | 71.2891 |     - |     - |   39136 B |
|   FictionaryConcreteReference | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 69.22 μs |  5.820 μs | 0.319 μs |  1.26 |    0.01 | 14.8926 |     - |     - |    7942 B |
|        DictionaryVirtualValue | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 58.69 μs |  3.984 μs | 0.218 μs |  1.07 |    0.00 | 71.2891 |     - |     - |   39136 B |
|        FictionaryVirtualValue | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 71.87 μs |  7.424 μs | 0.407 μs |  1.31 |    0.01 | 14.8926 |     - |     - |    7942 B |
|    DictionaryVirtualReference | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 52.71 μs |  3.444 μs | 0.189 μs |  0.96 |    0.00 | 71.2891 |     - |     - |   39136 B |
|    FictionaryVirtualReference | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 69.47 μs |  1.243 μs | 0.068 μs |  1.26 |    0.00 | 14.8926 |     - |     - |    7942 B |
| DictionaryStandardPolymorphic | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 47.34 μs |  4.971 μs | 0.272 μs |  0.86 |    0.01 | 71.2891 |     - |     - |   39136 B |
| FictionaryStandardPolymorphic | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 65.20 μs | 61.634 μs | 3.378 μs |  1.19 |    0.06 | 14.8926 |     - |     - |    7942 B |
|             DictionaryDefault | Job-OVLLTG | LegacyJit |    .NET 4.6.1 | 47.68 μs |  5.615 μs | 0.308 μs |  0.87 |    0.01 | 71.2891 |     - |     - |   39136 B |
|                               |            |           |               |          |           |          |       |         |         |       |       |           |
|       DictionaryConcreteValue | Job-USOUXK | LegacyJit |      .NET 4.8 | 60.42 μs | 35.100 μs | 1.924 μs |  1.11 |    0.02 | 71.1670 |     - |     - |   39136 B |
|       FictionaryConcreteValue | Job-USOUXK | LegacyJit |      .NET 4.8 | 40.82 μs |  1.939 μs | 0.106 μs |  0.75 |    0.01 | 14.8926 |     - |     - |    7941 B |
|   DictionaryConcreteReference | Job-USOUXK | LegacyJit |      .NET 4.8 | 54.41 μs | 18.526 μs | 1.015 μs |  1.00 |    0.00 | 71.2891 |     - |     - |   39136 B |
|   FictionaryConcreteReference | Job-USOUXK | LegacyJit |      .NET 4.8 | 68.62 μs | 11.337 μs | 0.621 μs |  1.26 |    0.03 | 14.8926 |     - |     - |    7942 B |
|        DictionaryVirtualValue | Job-USOUXK | LegacyJit |      .NET 4.8 | 58.89 μs |  3.026 μs | 0.166 μs |  1.08 |    0.02 | 71.2891 |     - |     - |   39136 B |
|        FictionaryVirtualValue | Job-USOUXK | LegacyJit |      .NET 4.8 | 71.79 μs |  7.698 μs | 0.422 μs |  1.32 |    0.02 | 14.8926 |     - |     - |    7942 B |
|    DictionaryVirtualReference | Job-USOUXK | LegacyJit |      .NET 4.8 | 53.29 μs |  1.244 μs | 0.068 μs |  0.98 |    0.02 | 71.2891 |     - |     - |   39136 B |
|    FictionaryVirtualReference | Job-USOUXK | LegacyJit |      .NET 4.8 | 68.94 μs | 15.385 μs | 0.843 μs |  1.27 |    0.04 | 14.8926 |     - |     - |    7942 B |
| DictionaryStandardPolymorphic | Job-USOUXK | LegacyJit |      .NET 4.8 | 47.55 μs |  4.579 μs | 0.251 μs |  0.87 |    0.01 | 71.2891 |     - |     - |   39136 B |
| FictionaryStandardPolymorphic | Job-USOUXK | LegacyJit |      .NET 4.8 | 63.95 μs |  9.841 μs | 0.539 μs |  1.18 |    0.03 | 14.8926 |     - |     - |    7942 B |
|             DictionaryDefault | Job-USOUXK | LegacyJit |      .NET 4.8 | 47.57 μs |  3.749 μs | 0.205 μs |  0.87 |    0.02 | 71.2891 |     - |     - |   39136 B |
|                               |            |           |               |          |           |          |       |         |         |       |       |           |
|       DictionaryConcreteValue | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 59.25 μs |  2.390 μs | 0.131 μs |  1.11 |    0.03 | 71.1670 |     - |     - |   39136 B |
|       FictionaryConcreteValue | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 41.09 μs |  7.421 μs | 0.407 μs |  0.77 |    0.02 | 14.8926 |     - |     - |    7941 B |
|   DictionaryConcreteReference | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 53.49 μs | 25.728 μs | 1.410 μs |  1.00 |    0.00 | 71.2891 |     - |     - |   39136 B |
|   FictionaryConcreteReference | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 69.39 μs |  2.459 μs | 0.135 μs |  1.30 |    0.03 | 14.8926 |     - |     - |    7942 B |
|        DictionaryVirtualValue | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 58.70 μs |  6.977 μs | 0.382 μs |  1.10 |    0.03 | 71.2891 |     - |     - |   39136 B |
|        FictionaryVirtualValue | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 71.41 μs |  5.984 μs | 0.328 μs |  1.34 |    0.04 | 14.8926 |     - |     - |    7942 B |
|    DictionaryVirtualReference | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 53.49 μs | 27.702 μs | 1.518 μs |  1.00 |    0.00 | 71.2891 |     - |     - |   39136 B |
|    FictionaryVirtualReference | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 69.74 μs |  6.784 μs | 0.372 μs |  1.30 |    0.03 | 14.8926 |     - |     - |    7942 B |
| DictionaryStandardPolymorphic | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 56.78 μs | 42.466 μs | 2.328 μs |  1.06 |    0.06 | 71.2891 |     - |     - |   39136 B |
| FictionaryStandardPolymorphic | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 71.15 μs |  8.241 μs | 0.452 μs |  1.33 |    0.03 | 14.8926 |     - |     - |    7942 B |
|             DictionaryDefault | Job-QXMNCR |    RyuJit |    .NET 4.6.1 | 55.71 μs | 39.451 μs | 2.162 μs |  1.04 |    0.06 | 71.2891 |     - |     - |   39136 B |
|                               |            |           |               |          |           |          |       |         |         |       |       |           |
|       DictionaryConcreteValue | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 68.05 μs | 23.510 μs | 1.289 μs |  1.05 |    0.04 | 71.1670 |     - |     - |   39136 B |
|       FictionaryConcreteValue | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 46.15 μs |  8.669 μs | 0.475 μs |  0.71 |    0.01 | 14.8926 |     - |     - |    7941 B |
|   DictionaryConcreteReference | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 64.56 μs | 24.346 μs | 1.335 μs |  1.00 |    0.00 | 71.2891 |     - |     - |   39136 B |
|   FictionaryConcreteReference | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 78.27 μs | 38.854 μs | 2.130 μs |  1.21 |    0.03 | 14.8926 |     - |     - |    7942 B |
|        DictionaryVirtualValue | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 71.83 μs | 78.442 μs | 4.300 μs |  1.11 |    0.07 | 71.1670 |     - |     - |   39136 B |
|        FictionaryVirtualValue | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 83.25 μs | 41.108 μs | 2.253 μs |  1.29 |    0.06 | 14.8926 |     - |     - |    7942 B |
|    DictionaryVirtualReference | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 61.34 μs | 18.384 μs | 1.008 μs |  0.95 |    0.04 | 71.1670 |     - |     - |   39136 B |
|    FictionaryVirtualReference | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 82.77 μs | 96.431 μs | 5.286 μs |  1.28 |    0.10 | 14.8926 |     - |     - |    7942 B |
| DictionaryStandardPolymorphic | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 55.61 μs | 22.107 μs | 1.212 μs |  0.86 |    0.02 | 71.2891 |     - |     - |   39136 B |
| FictionaryStandardPolymorphic | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 74.95 μs | 47.000 μs | 2.576 μs |  1.16 |    0.05 | 14.8926 |     - |     - |    7942 B |
|             DictionaryDefault | Job-ISGIVZ |    RyuJit |      .NET 4.8 | 54.38 μs | 25.709 μs | 1.409 μs |  0.84 |    0.04 | 71.2891 |     - |     - |   39136 B |
|                               |            |           |               |          |           |          |       |         |         |       |       |           |
|       DictionaryConcreteValue | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
|       FictionaryConcreteValue | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
|   DictionaryConcreteReference | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
|   FictionaryConcreteReference | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
|        DictionaryVirtualValue | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
|        FictionaryVirtualValue | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
|    DictionaryVirtualReference | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
|    FictionaryVirtualReference | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
| DictionaryStandardPolymorphic | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
| FictionaryStandardPolymorphic | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
|             DictionaryDefault | Job-QJKUKE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |       - |     - |     - |         - |
|                               |            |           |               |          |           |          |       |         |         |       |       |           |
|       DictionaryConcreteValue | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 77.94 μs | 57.484 μs | 3.151 μs |  1.26 |    0.04 | 18.3105 |     - |     - |   38768 B |
|       FictionaryConcreteValue | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 41.22 μs |  8.191 μs | 0.449 μs |  0.67 |    0.00 |  3.7231 |     - |     - |    7824 B |
|   DictionaryConcreteReference | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 61.96 μs | 12.137 μs | 0.665 μs |  1.00 |    0.00 | 18.3105 |     - |     - |   38744 B |
|   FictionaryConcreteReference | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 65.82 μs | 16.337 μs | 0.895 μs |  1.06 |    0.01 |  3.6621 |     - |     - |    7824 B |
|        DictionaryVirtualValue | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 76.33 μs | 35.418 μs | 1.941 μs |  1.23 |    0.04 | 18.3105 |     - |     - |   38768 B |
|        FictionaryVirtualValue | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 79.91 μs | 45.765 μs | 2.509 μs |  1.29 |    0.03 |  3.6621 |     - |     - |    7848 B |
|    DictionaryVirtualReference | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 61.99 μs | 17.275 μs | 0.947 μs |  1.00 |    0.02 | 18.3105 |     - |     - |   38744 B |
|    FictionaryVirtualReference | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 66.73 μs | 38.664 μs | 2.119 μs |  1.08 |    0.04 |  3.6621 |     - |     - |    7824 B |
| DictionaryStandardPolymorphic | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 46.88 μs |  3.423 μs | 0.188 μs |  0.76 |    0.01 | 18.3105 |     - |     - |   38744 B |
| FictionaryStandardPolymorphic | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 68.26 μs | 31.029 μs | 1.701 μs |  1.10 |    0.03 |  3.6621 |     - |     - |    7824 B |
|             DictionaryDefault | Job-QYBJCC |    RyuJit | .NET Core 3.1 | 47.19 μs | 21.075 μs | 1.155 μs |  0.76 |    0.02 | 18.3105 |     - |     - |   38744 B |
|                               |            |           |               |          |           |          |       |         |         |       |       |           |
|       DictionaryConcreteValue | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 70.88 μs | 21.978 μs | 1.205 μs |  1.18 |    0.03 | 18.3105 |     - |     - |   38776 B |
|       FictionaryConcreteValue | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 39.95 μs | 13.852 μs | 0.759 μs |  0.67 |    0.02 |  3.7231 |     - |     - |    7824 B |
|   DictionaryConcreteReference | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 60.07 μs | 11.940 μs | 0.654 μs |  1.00 |    0.00 | 18.3105 |     - |     - |   38752 B |
|   FictionaryConcreteReference | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 64.53 μs | 34.855 μs | 1.911 μs |  1.07 |    0.04 |  3.6621 |     - |     - |    7824 B |
|        DictionaryVirtualValue | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 73.69 μs | 12.295 μs | 0.674 μs |  1.23 |    0.02 | 18.3105 |     - |     - |   38776 B |
|        FictionaryVirtualValue | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 79.50 μs | 15.672 μs | 0.859 μs |  1.32 |    0.02 |  3.6621 |     - |     - |    7848 B |
|    DictionaryVirtualReference | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 62.50 μs | 55.287 μs | 3.030 μs |  1.04 |    0.06 | 18.3105 |     - |     - |   38752 B |
|    FictionaryVirtualReference | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 67.71 μs | 22.775 μs | 1.248 μs |  1.13 |    0.02 |  3.6621 |     - |     - |    7824 B |
| DictionaryStandardPolymorphic | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 48.77 μs |  3.752 μs | 0.206 μs |  0.81 |    0.01 | 18.3105 |     - |     - |   38752 B |
| FictionaryStandardPolymorphic | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 69.55 μs | 80.556 μs | 4.416 μs |  1.16 |    0.08 |  3.6621 |     - |     - |    7824 B |
|             DictionaryDefault | Job-DBXHFL |    RyuJit | .NET Core 5.0 | 50.34 μs | 25.104 μs | 1.376 μs |  0.84 |    0.03 | 18.3105 |     - |     - |   38752 B |

Benchmarks with issues:
  EnumPutBenchmark.DictionaryConcreteValue: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.FictionaryConcreteValue: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.DictionaryConcreteReference: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.FictionaryConcreteReference: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.DictionaryVirtualValue: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.FictionaryVirtualValue: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.DictionaryVirtualReference: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.FictionaryVirtualReference: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.DictionaryStandardPolymorphic: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.FictionaryStandardPolymorphic: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumPutBenchmark.DictionaryDefault: Job-QJKUKE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
