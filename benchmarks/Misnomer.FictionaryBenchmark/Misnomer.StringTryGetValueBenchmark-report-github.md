``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-BYUVYJ : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-RYZJAE : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-KZIREJ : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-SQSDFQ : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-ZJRZNF : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-QBZYGI : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Platform=X64  IterationCount=3  LaunchCount=1  
WarmupCount=3  Categories=String  

```
|                        Method |        Job |       Jit |       Runtime |     Mean |     Error |   StdDev | Ratio | RatioSD |
|------------------------------ |----------- |---------- |-------------- |---------:|----------:|---------:|------:|--------:|
|       DictionaryConcreteValue | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 18.60 ns |  0.944 ns | 0.052 ns |  1.20 |    0.07 |
|       FictionaryConcreteValue | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 16.56 ns |  0.988 ns | 0.054 ns |  1.07 |    0.06 |
|   DictionaryConcreteReference | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 16.33 ns |  1.806 ns | 0.099 ns |  1.05 |    0.06 |
|   FictionaryConcreteReference | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 19.01 ns |  4.623 ns | 0.253 ns |  1.23 |    0.08 |
|        DictionaryVirtualValue | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 18.73 ns |  2.197 ns | 0.120 ns |  1.21 |    0.08 |
|        FictionaryVirtualValue | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 23.33 ns |  2.731 ns | 0.150 ns |  1.51 |    0.09 |
|    DictionaryVirtualReference | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 16.30 ns |  2.383 ns | 0.131 ns |  1.05 |    0.05 |
|    FictionaryVirtualReference | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 18.85 ns |  2.999 ns | 0.164 ns |  1.22 |    0.08 |
| DictionaryStandardPolymorphic | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 15.53 ns | 16.619 ns | 0.911 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | Job-BYUVYJ | LegacyJit |    .NET 4.6.1 | 20.79 ns |  2.296 ns | 0.126 ns |  1.34 |    0.08 |
|                               |            |           |               |          |           |          |       |         |
|       DictionaryConcreteValue | Job-RYZJAE | LegacyJit |      .NET 4.8 | 18.20 ns |  2.593 ns | 0.142 ns |  1.23 |    0.00 |
|       FictionaryConcreteValue | Job-RYZJAE | LegacyJit |      .NET 4.8 | 16.95 ns |  6.378 ns | 0.350 ns |  1.14 |    0.03 |
|   DictionaryConcreteReference | Job-RYZJAE | LegacyJit |      .NET 4.8 | 15.45 ns |  6.236 ns | 0.342 ns |  1.04 |    0.02 |
|   FictionaryConcreteReference | Job-RYZJAE | LegacyJit |      .NET 4.8 | 16.07 ns |  0.657 ns | 0.036 ns |  1.08 |    0.01 |
|        DictionaryVirtualValue | Job-RYZJAE | LegacyJit |      .NET 4.8 | 18.34 ns |  3.832 ns | 0.210 ns |  1.24 |    0.02 |
|        FictionaryVirtualValue | Job-RYZJAE | LegacyJit |      .NET 4.8 | 22.59 ns |  9.180 ns | 0.503 ns |  1.52 |    0.04 |
|    DictionaryVirtualReference | Job-RYZJAE | LegacyJit |      .NET 4.8 | 15.45 ns |  4.698 ns | 0.257 ns |  1.04 |    0.02 |
|    FictionaryVirtualReference | Job-RYZJAE | LegacyJit |      .NET 4.8 | 16.11 ns |  1.077 ns | 0.059 ns |  1.09 |    0.01 |
| DictionaryStandardPolymorphic | Job-RYZJAE | LegacyJit |      .NET 4.8 | 14.84 ns |  1.550 ns | 0.085 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | Job-RYZJAE | LegacyJit |      .NET 4.8 | 20.56 ns |  2.412 ns | 0.132 ns |  1.39 |    0.01 |
|                               |            |           |               |          |           |          |       |         |
|       DictionaryConcreteValue | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 18.81 ns |  2.361 ns | 0.129 ns |  1.26 |    0.01 |
|       FictionaryConcreteValue | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 16.50 ns |  0.905 ns | 0.050 ns |  1.10 |    0.00 |
|   DictionaryConcreteReference | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 16.18 ns |  3.405 ns | 0.187 ns |  1.08 |    0.02 |
|   FictionaryConcreteReference | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 18.76 ns |  2.473 ns | 0.136 ns |  1.25 |    0.01 |
|        DictionaryVirtualValue | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 18.86 ns |  5.848 ns | 0.321 ns |  1.26 |    0.02 |
|        FictionaryVirtualValue | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 24.91 ns | 22.124 ns | 1.213 ns |  1.67 |    0.08 |
|    DictionaryVirtualReference | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 16.27 ns |  1.665 ns | 0.091 ns |  1.09 |    0.00 |
|    FictionaryVirtualReference | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 18.95 ns | 15.589 ns | 0.855 ns |  1.27 |    0.07 |
| DictionaryStandardPolymorphic | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 14.95 ns |  1.863 ns | 0.102 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | Job-KZIREJ |    RyuJit |    .NET 4.6.1 | 20.31 ns | 19.792 ns | 1.085 ns |  1.36 |    0.08 |
|                               |            |           |               |          |           |          |       |         |
|       DictionaryConcreteValue | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 20.08 ns |  4.155 ns | 0.228 ns |  1.16 |    0.03 |
|       FictionaryConcreteValue | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 18.90 ns |  4.999 ns | 0.274 ns |  1.09 |    0.03 |
|   DictionaryConcreteReference | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 18.34 ns | 13.874 ns | 0.760 ns |  1.06 |    0.06 |
|   FictionaryConcreteReference | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 19.03 ns | 18.219 ns | 0.999 ns |  1.10 |    0.05 |
|        DictionaryVirtualValue | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 19.57 ns |  6.739 ns | 0.369 ns |  1.13 |    0.03 |
|        FictionaryVirtualValue | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 25.22 ns | 13.220 ns | 0.725 ns |  1.45 |    0.06 |
|    DictionaryVirtualReference | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 17.55 ns | 10.903 ns | 0.598 ns |  1.01 |    0.04 |
|    FictionaryVirtualReference | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 18.72 ns |  5.637 ns | 0.309 ns |  1.08 |    0.02 |
| DictionaryStandardPolymorphic | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 17.37 ns |  3.605 ns | 0.198 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | Job-SQSDFQ |    RyuJit |      .NET 4.8 | 25.59 ns | 48.115 ns | 2.637 ns |  1.47 |    0.16 |
|                               |            |           |               |          |           |          |       |         |
|       DictionaryConcreteValue | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
|       FictionaryConcreteValue | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
|   DictionaryConcreteReference | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
|   FictionaryConcreteReference | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
|        DictionaryVirtualValue | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
|        FictionaryVirtualValue | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
|    DictionaryVirtualReference | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
|    FictionaryVirtualReference | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
| DictionaryStandardPolymorphic | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
| FictionaryStandardPolymorphic | Job-KBIIZE |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |
|                               |            |           |               |          |           |          |       |         |
|       DictionaryConcreteValue | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 28.52 ns | 19.286 ns | 1.057 ns |  1.44 |    0.11 |
|       FictionaryConcreteValue | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 22.20 ns |  7.648 ns | 0.419 ns |  1.12 |    0.04 |
|   DictionaryConcreteReference | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 27.28 ns | 31.289 ns | 1.715 ns |  1.38 |    0.08 |
|   FictionaryConcreteReference | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 25.86 ns | 15.292 ns | 0.838 ns |  1.31 |    0.00 |
|        DictionaryVirtualValue | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 25.42 ns |  7.672 ns | 0.421 ns |  1.29 |    0.07 |
|        FictionaryVirtualValue | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 27.19 ns | 16.713 ns | 0.916 ns |  1.37 |    0.02 |
|    DictionaryVirtualReference | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 29.22 ns | 19.977 ns | 1.095 ns |  1.48 |    0.09 |
|    FictionaryVirtualReference | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 25.15 ns | 17.911 ns | 0.982 ns |  1.27 |    0.05 |
| DictionaryStandardPolymorphic | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 19.80 ns | 12.712 ns | 0.697 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | Job-ZJRZNF |    RyuJit | .NET Core 3.1 | 22.29 ns | 15.678 ns | 0.859 ns |  1.13 |    0.07 |
|                               |            |           |               |          |           |          |       |         |
|       DictionaryConcreteValue | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 25.31 ns | 19.784 ns | 1.084 ns |  2.20 |    0.11 |
|       FictionaryConcreteValue | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 22.00 ns | 10.010 ns | 0.549 ns |  1.91 |    0.02 |
|   DictionaryConcreteReference | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 29.04 ns |  8.315 ns | 0.456 ns |  2.52 |    0.00 |
|   FictionaryConcreteReference | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 28.97 ns | 19.007 ns | 1.042 ns |  2.52 |    0.08 |
|        DictionaryVirtualValue | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 25.56 ns | 18.781 ns | 1.029 ns |  2.22 |    0.12 |
|        FictionaryVirtualValue | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 34.67 ns | 47.328 ns | 2.594 ns |  3.01 |    0.27 |
|    DictionaryVirtualReference | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 23.00 ns |  2.024 ns | 0.111 ns |  2.00 |    0.02 |
|    FictionaryVirtualReference | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 25.48 ns | 24.037 ns | 1.318 ns |  2.21 |    0.13 |
| DictionaryStandardPolymorphic | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 11.51 ns |  3.212 ns | 0.176 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | Job-QBZYGI |    RyuJit | .NET Core 5.0 | 19.05 ns |  5.957 ns | 0.327 ns |  1.65 |    0.01 |

Benchmarks with issues:
  StringTryGetValueBenchmark.DictionaryConcreteValue: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringTryGetValueBenchmark.FictionaryConcreteValue: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringTryGetValueBenchmark.DictionaryConcreteReference: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringTryGetValueBenchmark.FictionaryConcreteReference: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringTryGetValueBenchmark.DictionaryVirtualValue: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringTryGetValueBenchmark.FictionaryVirtualValue: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringTryGetValueBenchmark.DictionaryVirtualReference: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringTryGetValueBenchmark.FictionaryVirtualReference: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringTryGetValueBenchmark.DictionaryStandardPolymorphic: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringTryGetValueBenchmark.FictionaryStandardPolymorphic: Job-KBIIZE(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
