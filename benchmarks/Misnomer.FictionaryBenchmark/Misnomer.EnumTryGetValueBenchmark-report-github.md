``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-QSJMJA : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-NWVJDB : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-EJMCRD : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-XKZQNX : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-GLWODF : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-JTUVIF : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Platform=X64  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                      Method |        Job |       Jit |       Runtime |     Mean |     Error |    StdDev | Ratio | RatioSD |
|---------------------------- |----------- |---------- |-------------- |---------:|----------:|----------:|------:|--------:|
| DictionaryConcreteReference | Job-QSJMJA | LegacyJit |    .NET 4.6.1 | 1.942 μs | 0.2122 μs | 0.0116 μs |  1.00 |    0.00 |
|     FictionaryConcreteValue | Job-QSJMJA | LegacyJit |    .NET 4.6.1 | 1.077 μs | 0.0993 μs | 0.0054 μs |  0.55 |    0.00 |
|           DictionaryDefault | Job-QSJMJA | LegacyJit |    .NET 4.6.1 | 1.675 μs | 0.0332 μs | 0.0018 μs |  0.86 |    0.00 |
|                             |            |           |               |          |           |           |       |         |
| DictionaryConcreteReference | Job-NWVJDB | LegacyJit |      .NET 4.8 | 1.918 μs | 0.0913 μs | 0.0050 μs |  1.00 |    0.00 |
|     FictionaryConcreteValue | Job-NWVJDB | LegacyJit |      .NET 4.8 | 1.079 μs | 0.0857 μs | 0.0047 μs |  0.56 |    0.00 |
|           DictionaryDefault | Job-NWVJDB | LegacyJit |      .NET 4.8 | 1.810 μs | 2.2996 μs | 0.1260 μs |  0.94 |    0.06 |
|                             |            |           |               |          |           |           |       |         |
| DictionaryConcreteReference | Job-EJMCRD |    RyuJit |    .NET 4.6.1 | 1.937 μs | 0.3307 μs | 0.0181 μs |  1.00 |    0.00 |
|     FictionaryConcreteValue | Job-EJMCRD |    RyuJit |    .NET 4.6.1 | 1.084 μs | 0.0798 μs | 0.0044 μs |  0.56 |    0.00 |
|           DictionaryDefault | Job-EJMCRD |    RyuJit |    .NET 4.6.1 | 1.675 μs | 0.0862 μs | 0.0047 μs |  0.87 |    0.01 |
|                             |            |           |               |          |           |           |       |         |
| DictionaryConcreteReference | Job-XKZQNX |    RyuJit |      .NET 4.8 | 1.922 μs | 0.1841 μs | 0.0101 μs |  1.00 |    0.00 |
|     FictionaryConcreteValue | Job-XKZQNX |    RyuJit |      .NET 4.8 | 1.116 μs | 0.7855 μs | 0.0431 μs |  0.58 |    0.02 |
|           DictionaryDefault | Job-XKZQNX |    RyuJit |      .NET 4.8 | 1.799 μs | 3.7551 μs | 0.2058 μs |  0.94 |    0.10 |
|                             |            |           |               |          |           |           |       |         |
| DictionaryConcreteReference | Job-OQLGSH |    RyuJit | .NET Core 2.1 |       NA |        NA |        NA |     ? |       ? |
|     FictionaryConcreteValue | Job-OQLGSH |    RyuJit | .NET Core 2.1 |       NA |        NA |        NA |     ? |       ? |
|           DictionaryDefault | Job-OQLGSH |    RyuJit | .NET Core 2.1 |       NA |        NA |        NA |     ? |       ? |
|                             |            |           |               |          |           |           |       |         |
| DictionaryConcreteReference | Job-GLWODF |    RyuJit | .NET Core 3.1 | 1.851 μs | 0.0401 μs | 0.0022 μs |  1.00 |    0.00 |
|     FictionaryConcreteValue | Job-GLWODF |    RyuJit | .NET Core 3.1 | 1.062 μs | 0.0751 μs | 0.0041 μs |  0.57 |    0.00 |
|           DictionaryDefault | Job-GLWODF |    RyuJit | .NET Core 3.1 | 1.415 μs | 0.0237 μs | 0.0013 μs |  0.76 |    0.00 |
|                             |            |           |               |          |           |           |       |         |
| DictionaryConcreteReference | Job-JTUVIF |    RyuJit | .NET Core 5.0 | 1.694 μs | 0.1947 μs | 0.0107 μs |  1.00 |    0.00 |
|     FictionaryConcreteValue | Job-JTUVIF |    RyuJit | .NET Core 5.0 | 1.065 μs | 0.1048 μs | 0.0057 μs |  0.63 |    0.00 |
|           DictionaryDefault | Job-JTUVIF |    RyuJit | .NET Core 5.0 | 1.180 μs | 0.3613 μs | 0.0198 μs |  0.70 |    0.01 |

Benchmarks with issues:
  EnumTryGetValueBenchmark.DictionaryConcreteReference: Job-OQLGSH(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumTryGetValueBenchmark.FictionaryConcreteValue: Job-OQLGSH(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  EnumTryGetValueBenchmark.DictionaryDefault: Job-OQLGSH(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
