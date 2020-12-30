``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-TFSDUG : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-AYJJLE : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-TITCKB : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-UODDGX : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-XYDLOQ : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-DNIAOU : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Platform=X64  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                        Method |        Job |       Jit |       Runtime |      Mean |      Error |    StdDev | Ratio | RatioSD |
|------------------------------ |----------- |---------- |-------------- |----------:|-----------:|----------:|------:|--------:|
|       DictionaryConcreteValue | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 13.651 ns |  3.2416 ns | 0.1777 ns |  1.11 |    0.01 |
|       FictionaryConcreteValue | Job-TFSDUG | LegacyJit |    .NET 4.6.1 |  7.270 ns |  1.4006 ns | 0.0768 ns |  0.59 |    0.01 |
|   DictionaryConcreteReference | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 12.248 ns |  5.5547 ns | 0.3045 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 13.636 ns |  4.1630 ns | 0.2282 ns |  1.11 |    0.04 |
|        DictionaryVirtualValue | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 13.646 ns |  2.0629 ns | 0.1131 ns |  1.11 |    0.04 |
|        FictionaryVirtualValue | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 16.637 ns | 10.6059 ns | 0.5813 ns |  1.36 |    0.07 |
|    DictionaryVirtualReference | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 12.338 ns |  1.1215 ns | 0.0615 ns |  1.01 |    0.03 |
|    FictionaryVirtualReference | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 13.697 ns |  4.7404 ns | 0.2598 ns |  1.12 |    0.01 |
| DictionaryStandardPolymorphic | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 11.272 ns |  2.7185 ns | 0.1490 ns |  0.92 |    0.03 |
| FictionaryStandardPolymorphic | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 14.348 ns |  1.5388 ns | 0.0843 ns |  1.17 |    0.02 |
|             DictionaryDefault | Job-TFSDUG | LegacyJit |    .NET 4.6.1 | 11.213 ns |  1.9571 ns | 0.1073 ns |  0.92 |    0.01 |
|                               |            |           |               |           |            |           |       |         |
|       DictionaryConcreteValue | Job-AYJJLE | LegacyJit |      .NET 4.8 | 14.132 ns |  2.1571 ns | 0.1182 ns |  1.16 |    0.01 |
|       FictionaryConcreteValue | Job-AYJJLE | LegacyJit |      .NET 4.8 |  7.163 ns |  2.3067 ns | 0.1264 ns |  0.59 |    0.01 |
|   DictionaryConcreteReference | Job-AYJJLE | LegacyJit |      .NET 4.8 | 12.155 ns |  0.0958 ns | 0.0053 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | Job-AYJJLE | LegacyJit |      .NET 4.8 | 13.474 ns |  5.7079 ns | 0.3129 ns |  1.11 |    0.03 |
|        DictionaryVirtualValue | Job-AYJJLE | LegacyJit |      .NET 4.8 | 13.784 ns |  3.8292 ns | 0.2099 ns |  1.13 |    0.02 |
|        FictionaryVirtualValue | Job-AYJJLE | LegacyJit |      .NET 4.8 | 16.148 ns |  4.9861 ns | 0.2733 ns |  1.33 |    0.02 |
|    DictionaryVirtualReference | Job-AYJJLE | LegacyJit |      .NET 4.8 | 12.194 ns |  2.3885 ns | 0.1309 ns |  1.00 |    0.01 |
|    FictionaryVirtualReference | Job-AYJJLE | LegacyJit |      .NET 4.8 | 13.669 ns |  1.7144 ns | 0.0940 ns |  1.12 |    0.01 |
| DictionaryStandardPolymorphic | Job-AYJJLE | LegacyJit |      .NET 4.8 | 11.442 ns |  2.6366 ns | 0.1445 ns |  0.94 |    0.01 |
| FictionaryStandardPolymorphic | Job-AYJJLE | LegacyJit |      .NET 4.8 | 13.720 ns |  0.6745 ns | 0.0370 ns |  1.13 |    0.00 |
|             DictionaryDefault | Job-AYJJLE | LegacyJit |      .NET 4.8 | 11.594 ns |  2.2573 ns | 0.1237 ns |  0.95 |    0.01 |
|                               |            |           |               |           |            |           |       |         |
|       DictionaryConcreteValue | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 13.555 ns |  3.5545 ns | 0.1948 ns |  1.10 |    0.01 |
|       FictionaryConcreteValue | Job-TITCKB |    RyuJit |    .NET 4.6.1 |  7.296 ns |  0.9017 ns | 0.0494 ns |  0.59 |    0.01 |
|   DictionaryConcreteReference | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 12.321 ns |  1.4560 ns | 0.0798 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 13.675 ns |  0.4096 ns | 0.0224 ns |  1.11 |    0.01 |
|        DictionaryVirtualValue | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 13.707 ns |  2.1530 ns | 0.1180 ns |  1.11 |    0.00 |
|        FictionaryVirtualValue | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 16.078 ns |  0.5161 ns | 0.0283 ns |  1.30 |    0.01 |
|    DictionaryVirtualReference | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 13.157 ns | 12.2555 ns | 0.6718 ns |  1.07 |    0.05 |
|    FictionaryVirtualReference | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 16.025 ns | 16.1875 ns | 0.8873 ns |  1.30 |    0.08 |
| DictionaryStandardPolymorphic | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 12.622 ns |  5.1821 ns | 0.2840 ns |  1.02 |    0.03 |
| FictionaryStandardPolymorphic | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 15.829 ns |  1.0999 ns | 0.0603 ns |  1.28 |    0.00 |
|             DictionaryDefault | Job-TITCKB |    RyuJit |    .NET 4.6.1 | 12.417 ns |  2.0820 ns | 0.1141 ns |  1.01 |    0.02 |
|                               |            |           |               |           |            |           |       |         |
|       DictionaryConcreteValue | Job-UODDGX |    RyuJit |      .NET 4.8 | 16.753 ns |  8.2984 ns | 0.4549 ns |  1.22 |    0.05 |
|       FictionaryConcreteValue | Job-UODDGX |    RyuJit |      .NET 4.8 |  7.988 ns |  1.4505 ns | 0.0795 ns |  0.58 |    0.02 |
|   DictionaryConcreteReference | Job-UODDGX |    RyuJit |      .NET 4.8 | 13.771 ns |  5.4276 ns | 0.2975 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | Job-UODDGX |    RyuJit |      .NET 4.8 | 15.525 ns | 21.3325 ns | 1.1693 ns |  1.13 |    0.11 |
|        DictionaryVirtualValue | Job-UODDGX |    RyuJit |      .NET 4.8 | 16.684 ns |  3.0710 ns | 0.1683 ns |  1.21 |    0.04 |
|        FictionaryVirtualValue | Job-UODDGX |    RyuJit |      .NET 4.8 | 19.065 ns |  7.5032 ns | 0.4113 ns |  1.38 |    0.02 |
|    DictionaryVirtualReference | Job-UODDGX |    RyuJit |      .NET 4.8 | 13.900 ns |  7.0073 ns | 0.3841 ns |  1.01 |    0.01 |
|    FictionaryVirtualReference | Job-UODDGX |    RyuJit |      .NET 4.8 | 15.258 ns |  4.4754 ns | 0.2453 ns |  1.11 |    0.04 |
| DictionaryStandardPolymorphic | Job-UODDGX |    RyuJit |      .NET 4.8 | 13.402 ns |  8.4283 ns | 0.4620 ns |  0.97 |    0.03 |
| FictionaryStandardPolymorphic | Job-UODDGX |    RyuJit |      .NET 4.8 | 16.325 ns | 18.2971 ns | 1.0029 ns |  1.19 |    0.10 |
|             DictionaryDefault | Job-UODDGX |    RyuJit |      .NET 4.8 | 13.472 ns |  8.1781 ns | 0.4483 ns |  0.98 |    0.01 |
|                               |            |           |               |           |            |           |       |         |
|       DictionaryConcreteValue | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
|       FictionaryConcreteValue | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
|   DictionaryConcreteReference | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
|   FictionaryConcreteReference | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
|        DictionaryVirtualValue | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
|        FictionaryVirtualValue | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
|    DictionaryVirtualReference | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
|    FictionaryVirtualReference | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
| DictionaryStandardPolymorphic | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
| FictionaryStandardPolymorphic | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
|             DictionaryDefault | Job-CGJLIV |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |     ? |       ? |
|                               |            |           |               |           |            |           |       |         |
|       DictionaryConcreteValue | Job-XYDLOQ |    RyuJit | .NET Core 3.1 | 16.032 ns | 13.2259 ns | 0.7250 ns |  1.15 |    0.04 |
|       FictionaryConcreteValue | Job-XYDLOQ |    RyuJit | .NET Core 3.1 |  7.416 ns |  2.5464 ns | 0.1396 ns |  0.53 |    0.02 |
|   DictionaryConcreteReference | Job-XYDLOQ |    RyuJit | .NET Core 3.1 | 13.937 ns |  8.3843 ns | 0.4596 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | Job-XYDLOQ |    RyuJit | .NET Core 3.1 | 13.790 ns |  6.7881 ns | 0.3721 ns |  0.99 |    0.01 |
|        DictionaryVirtualValue | Job-XYDLOQ |    RyuJit | .NET Core 3.1 | 14.954 ns | 11.5361 ns | 0.6323 ns |  1.07 |    0.04 |
|        FictionaryVirtualValue | Job-XYDLOQ |    RyuJit | .NET Core 3.1 | 17.903 ns |  5.4080 ns | 0.2964 ns |  1.29 |    0.06 |
|    DictionaryVirtualReference | Job-XYDLOQ |    RyuJit | .NET Core 3.1 | 14.892 ns | 19.1785 ns | 1.0512 ns |  1.07 |    0.05 |
|    FictionaryVirtualReference | Job-XYDLOQ |    RyuJit | .NET Core 3.1 | 14.149 ns |  7.8131 ns | 0.4283 ns |  1.02 |    0.06 |
| DictionaryStandardPolymorphic | Job-XYDLOQ |    RyuJit | .NET Core 3.1 |  9.642 ns | 32.1102 ns | 1.7601 ns |  0.69 |    0.13 |
| FictionaryStandardPolymorphic | Job-XYDLOQ |    RyuJit | .NET Core 3.1 | 14.888 ns | 11.1631 ns | 0.6119 ns |  1.07 |    0.02 |
|             DictionaryDefault | Job-XYDLOQ |    RyuJit | .NET Core 3.1 |  8.740 ns |  7.4044 ns | 0.4059 ns |  0.63 |    0.04 |
|                               |            |           |               |           |            |           |       |         |
|       DictionaryConcreteValue | Job-DNIAOU |    RyuJit | .NET Core 5.0 | 15.077 ns |  9.2405 ns | 0.5065 ns |  1.19 |    0.04 |
|       FictionaryConcreteValue | Job-DNIAOU |    RyuJit | .NET Core 5.0 |  7.852 ns |  9.2814 ns | 0.5087 ns |  0.62 |    0.04 |
|   DictionaryConcreteReference | Job-DNIAOU |    RyuJit | .NET Core 5.0 | 12.659 ns |  1.1357 ns | 0.0623 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | Job-DNIAOU |    RyuJit | .NET Core 5.0 | 14.094 ns |  1.9966 ns | 0.1094 ns |  1.11 |    0.00 |
|        DictionaryVirtualValue | Job-DNIAOU |    RyuJit | .NET Core 5.0 | 14.945 ns |  6.3219 ns | 0.3465 ns |  1.18 |    0.03 |
|        FictionaryVirtualValue | Job-DNIAOU |    RyuJit | .NET Core 5.0 | 20.257 ns |  8.6664 ns | 0.4750 ns |  1.60 |    0.03 |
|    DictionaryVirtualReference | Job-DNIAOU |    RyuJit | .NET Core 5.0 | 12.496 ns |  6.1276 ns | 0.3359 ns |  0.99 |    0.03 |
|    FictionaryVirtualReference | Job-DNIAOU |    RyuJit | .NET Core 5.0 | 14.031 ns |  3.8040 ns | 0.2085 ns |  1.11 |    0.02 |
| DictionaryStandardPolymorphic | Job-DNIAOU |    RyuJit | .NET Core 5.0 |  8.865 ns |  2.7309 ns | 0.1497 ns |  0.70 |    0.01 |
| FictionaryStandardPolymorphic | Job-DNIAOU |    RyuJit | .NET Core 5.0 | 14.900 ns |  3.2130 ns | 0.1761 ns |  1.18 |    0.01 |
|             DictionaryDefault | Job-DNIAOU |    RyuJit | .NET Core 5.0 |  9.380 ns |  7.5553 ns | 0.4141 ns |  0.74 |    0.03 |

Benchmarks with issues:
  DateTimeTryGetValueBenchmark.DictionaryConcreteValue: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.FictionaryConcreteValue: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.DictionaryConcreteReference: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.FictionaryConcreteReference: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.DictionaryVirtualValue: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.FictionaryVirtualValue: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.DictionaryVirtualReference: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.FictionaryVirtualReference: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.DictionaryStandardPolymorphic: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.FictionaryStandardPolymorphic: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimeTryGetValueBenchmark.DictionaryDefault: Job-CGJLIV(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
