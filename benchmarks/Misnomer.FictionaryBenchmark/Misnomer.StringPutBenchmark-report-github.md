``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-TQLWVL : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-CEHWBZ : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-PUGUYQ : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-ORHABV : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-UWMFBT : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-SMMFFY : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Platform=X64  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                        Method |        Job |       Jit |       Runtime |     Mean |     Error |   StdDev | Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------------ |----------- |---------- |-------------- |---------:|----------:|---------:|------:|--------:|---------:|--------:|------:|----------:|
|       DictionaryConcreteValue | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 412.8 μs |  24.96 μs |  1.37 μs |  1.02 |    0.01 | 104.9805 | 25.8789 |     - |  221149 B |
|       FictionaryConcreteValue | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 363.5 μs |  24.49 μs |  1.34 μs |  0.90 |    0.00 | 313.4766 |  2.9297 |     - |  174722 B |
|   DictionaryConcreteReference | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 403.6 μs |  46.10 μs |  2.53 μs |  1.00 |    0.00 | 104.4922 | 25.8789 |     - |  221137 B |
|   FictionaryConcreteReference | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 396.4 μs |  29.46 μs |  1.61 μs |  0.98 |    0.01 | 320.3125 |  1.4648 |     - |  174723 B |
|        DictionaryVirtualValue | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 416.7 μs |  13.72 μs |  0.75 μs |  1.03 |    0.01 | 113.7695 | 25.8789 |     - |  221230 B |
|        FictionaryVirtualValue | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 406.8 μs |   2.27 μs |  0.12 μs |  1.01 |    0.01 | 316.4063 |  1.9531 |     - |  174740 B |
|    DictionaryVirtualReference | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 401.0 μs |  10.60 μs |  0.58 μs |  0.99 |    0.01 | 104.4922 | 25.8789 |     - |  221137 B |
|    FictionaryVirtualReference | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 383.5 μs |  18.22 μs |  1.00 μs |  0.95 |    0.01 | 320.3125 |  1.4648 |     - |  174723 B |
| DictionaryStandardPolymorphic | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 399.0 μs |  32.31 μs |  1.77 μs |  0.99 |    0.01 | 107.4219 | 26.8555 |     - |  221128 B |
| FictionaryStandardPolymorphic | Job-TQLWVL | LegacyJit |    .NET 4.6.1 | 394.5 μs |   8.91 μs |  0.49 μs |  0.98 |    0.01 | 314.4531 |  2.4414 |     - |  174722 B |
|                               |            |           |               |          |           |          |       |         |          |         |       |           |
|       DictionaryConcreteValue | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 417.6 μs |  32.90 μs |  1.80 μs |  1.03 |    0.01 | 104.9805 | 25.8789 |     - |  221162 B |
|       FictionaryConcreteValue | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 368.2 μs |   3.29 μs |  0.18 μs |  0.91 |    0.00 | 305.6641 |  3.9063 |     - |  174723 B |
|   DictionaryConcreteReference | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 406.3 μs |  25.65 μs |  1.41 μs |  1.00 |    0.00 | 108.3984 | 26.8555 |     - |  221125 B |
|   FictionaryConcreteReference | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 401.4 μs |  13.71 μs |  0.75 μs |  0.99 |    0.00 | 314.4531 |  2.4414 |     - |  174722 B |
|        DictionaryVirtualValue | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 419.4 μs |  36.18 μs |  1.98 μs |  1.03 |    0.01 | 104.0039 | 25.8789 |     - |  221171 B |
|        FictionaryVirtualValue | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 397.8 μs |  34.89 μs |  1.91 μs |  0.98 |    0.00 | 323.2422 |  0.9766 |     - |  174740 B |
|    DictionaryVirtualReference | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 402.5 μs |  36.32 μs |  1.99 μs |  0.99 |    0.01 | 108.3984 | 26.8555 |     - |  221125 B |
|    FictionaryVirtualReference | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 399.5 μs |   8.11 μs |  0.44 μs |  0.98 |    0.00 | 314.4531 |  2.4414 |     - |  174722 B |
| DictionaryStandardPolymorphic | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 400.0 μs |  38.84 μs |  2.13 μs |  0.98 |    0.00 | 103.5156 | 25.8789 |     - |  221145 B |
| FictionaryStandardPolymorphic | Job-CEHWBZ | LegacyJit |      .NET 4.8 | 389.2 μs |  30.03 μs |  1.65 μs |  0.96 |    0.01 | 313.4766 |  2.9297 |     - |  174722 B |
|                               |            |           |               |          |           |          |       |         |          |         |       |           |
|       DictionaryConcreteValue | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 413.6 μs |  15.43 μs |  0.85 μs |  1.03 |    0.00 | 101.5625 | 25.3906 |     - |  221169 B |
|       FictionaryConcreteValue | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 364.3 μs |  32.37 μs |  1.77 μs |  0.91 |    0.00 | 299.3164 |  4.3945 |     - |  174724 B |
|   DictionaryConcreteReference | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 401.8 μs |   9.72 μs |  0.53 μs |  1.00 |    0.00 | 104.9805 | 26.8555 |     - |  221125 B |
|   FictionaryConcreteReference | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 386.2 μs |  17.69 μs |  0.97 μs |  0.96 |    0.00 | 308.1055 |  3.4180 |     - |  174725 B |
|        DictionaryVirtualValue | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 414.8 μs |   5.99 μs |  0.33 μs |  1.03 |    0.00 | 106.4453 | 26.8555 |     - |  221150 B |
|        FictionaryVirtualValue | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 408.8 μs |  14.05 μs |  0.77 μs |  1.02 |    0.00 | 314.9414 |  1.9531 |     - |  174742 B |
|    DictionaryVirtualReference | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 400.5 μs |   3.27 μs |  0.18 μs |  1.00 |    0.00 | 104.9805 | 26.8555 |     - |  221125 B |
|    FictionaryVirtualReference | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 442.9 μs | 108.10 μs |  5.93 μs |  1.10 |    0.01 | 308.1055 |  3.4180 |     - |  174725 B |
| DictionaryStandardPolymorphic | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 460.0 μs | 146.87 μs |  8.05 μs |  1.14 |    0.02 | 100.5859 | 25.3906 |     - |  221151 B |
| FictionaryStandardPolymorphic | Job-PUGUYQ |    RyuJit |    .NET 4.6.1 | 463.3 μs | 322.95 μs | 17.70 μs |  1.15 |    0.04 | 312.0117 |  2.9297 |     - |  174724 B |
|                               |            |           |               |          |           |          |       |         |          |         |       |           |
|       DictionaryConcreteValue | Job-ORHABV |    RyuJit |      .NET 4.8 | 495.4 μs | 614.55 μs | 33.69 μs |  1.07 |    0.07 | 106.4453 | 25.3906 |     - |  221159 B |
|       FictionaryConcreteValue | Job-ORHABV |    RyuJit |      .NET 4.8 | 441.4 μs | 556.40 μs | 30.50 μs |  0.95 |    0.07 | 305.6641 |  3.9063 |     - |  174724 B |
|   DictionaryConcreteReference | Job-ORHABV |    RyuJit |      .NET 4.8 | 463.9 μs | 255.54 μs | 14.01 μs |  1.00 |    0.00 | 109.3750 | 27.3438 |     - |  221134 B |
|   FictionaryConcreteReference | Job-ORHABV |    RyuJit |      .NET 4.8 | 461.4 μs | 157.54 μs |  8.64 μs |  1.00 |    0.03 | 310.0586 |  3.4180 |     - |  174725 B |
|        DictionaryVirtualValue | Job-ORHABV |    RyuJit |      .NET 4.8 | 470.6 μs | 258.92 μs | 14.19 μs |  1.01 |    0.01 | 104.0039 | 25.8789 |     - |  221158 B |
|        FictionaryVirtualValue | Job-ORHABV |    RyuJit |      .NET 4.8 | 475.3 μs | 292.31 μs | 16.02 μs |  1.03 |    0.05 | 326.6602 |  0.4883 |     - |  174741 B |
|    DictionaryVirtualReference | Job-ORHABV |    RyuJit |      .NET 4.8 | 462.2 μs | 350.94 μs | 19.24 μs |  1.00 |    0.05 | 106.9336 | 26.3672 |     - |  221132 B |
|    FictionaryVirtualReference | Job-ORHABV |    RyuJit |      .NET 4.8 | 463.4 μs | 314.91 μs | 17.26 μs |  1.00 |    0.06 | 320.3125 |  0.9766 |     - |  174729 B |
| DictionaryStandardPolymorphic | Job-ORHABV |    RyuJit |      .NET 4.8 | 461.4 μs |  55.24 μs |  3.03 μs |  1.00 |    0.03 | 103.5156 | 25.8789 |     - |  221149 B |
| FictionaryStandardPolymorphic | Job-ORHABV |    RyuJit |      .NET 4.8 | 439.6 μs |  66.86 μs |  3.66 μs |  0.95 |    0.02 | 300.7813 |  4.3945 |     - |  174724 B |
|                               |            |           |               |          |           |          |       |         |          |         |       |           |
|       DictionaryConcreteValue | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
|       FictionaryConcreteValue | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
|   DictionaryConcreteReference | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
|   FictionaryConcreteReference | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
|        DictionaryVirtualValue | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
|        FictionaryVirtualValue | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
|    DictionaryVirtualReference | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
|    FictionaryVirtualReference | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
| DictionaryStandardPolymorphic | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
| FictionaryStandardPolymorphic | Job-IDXOEF |    RyuJit | .NET Core 2.1 |       NA |        NA |       NA |     ? |       ? |        - |       - |     - |         - |
|                               |            |           |               |          |           |          |       |         |          |         |       |           |
|       DictionaryConcreteValue | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 431.1 μs | 733.49 μs | 40.21 μs |  1.07 |    0.11 |  90.8203 |       - |     - |  192856 B |
|       FictionaryConcreteValue | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 364.8 μs | 187.36 μs | 10.27 μs |  0.90 |    0.01 |  69.8242 |       - |     - |  146464 B |
|   DictionaryConcreteReference | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 403.6 μs | 160.23 μs |  8.78 μs |  1.00 |    0.00 |  90.8203 |       - |     - |  192832 B |
|   FictionaryConcreteReference | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 409.6 μs |  79.89 μs |  4.38 μs |  1.02 |    0.02 |  69.8242 |       - |     - |  146464 B |
|        DictionaryVirtualValue | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 409.1 μs | 410.46 μs | 22.50 μs |  1.01 |    0.08 |  90.8203 |       - |     - |  192856 B |
|        FictionaryVirtualValue | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 421.0 μs | 233.54 μs | 12.80 μs |  1.04 |    0.01 |  69.8242 |       - |     - |  146488 B |
|    DictionaryVirtualReference | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 404.3 μs | 135.16 μs |  7.41 μs |  1.00 |    0.02 |  90.8203 |       - |     - |  192832 B |
|    FictionaryVirtualReference | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 394.3 μs | 160.88 μs |  8.82 μs |  0.98 |    0.01 |  69.8242 |       - |     - |  146464 B |
| DictionaryStandardPolymorphic | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 390.2 μs | 280.49 μs | 15.37 μs |  0.97 |    0.06 |  90.8203 |       - |     - |  192832 B |
| FictionaryStandardPolymorphic | Job-UWMFBT |    RyuJit | .NET Core 3.1 | 377.5 μs |  24.59 μs |  1.35 μs |  0.94 |    0.02 |  69.8242 |       - |     - |  146464 B |
|                               |            |           |               |          |           |          |       |         |          |         |       |           |
|       DictionaryConcreteValue | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 371.4 μs |  80.12 μs |  4.39 μs |  1.09 |    0.02 |  90.8203 |       - |     - |  192864 B |
|       FictionaryConcreteValue | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 332.8 μs |  68.93 μs |  3.78 μs |  0.98 |    0.01 |  69.8242 |       - |     - |  146464 B |
|   DictionaryConcreteReference | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 339.7 μs |  22.32 μs |  1.22 μs |  1.00 |    0.00 |  90.8203 |       - |     - |  192840 B |
|   FictionaryConcreteReference | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 360.1 μs |  93.53 μs |  5.13 μs |  1.06 |    0.01 |  69.8242 |       - |     - |  146464 B |
|        DictionaryVirtualValue | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 364.8 μs | 104.91 μs |  5.75 μs |  1.07 |    0.02 |  90.8203 |       - |     - |  192864 B |
|        FictionaryVirtualValue | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 427.3 μs | 351.07 μs | 19.24 μs |  1.26 |    0.05 |  69.8242 |       - |     - |  146488 B |
|    DictionaryVirtualReference | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 341.6 μs | 131.41 μs |  7.20 μs |  1.01 |    0.02 |  90.8203 |       - |     - |  192840 B |
|    FictionaryVirtualReference | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 368.2 μs |  32.12 μs |  1.76 μs |  1.08 |    0.01 |  69.8242 |       - |     - |  146464 B |
| DictionaryStandardPolymorphic | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 298.3 μs |  77.67 μs |  4.26 μs |  0.88 |    0.02 |  90.8203 |       - |     - |  192840 B |
| FictionaryStandardPolymorphic | Job-SMMFFY |    RyuJit | .NET Core 5.0 | 332.7 μs | 109.45 μs |  6.00 μs |  0.98 |    0.02 |  69.8242 |       - |     - |  146464 B |

Benchmarks with issues:
  StringPutBenchmark.DictionaryConcreteValue: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringPutBenchmark.FictionaryConcreteValue: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringPutBenchmark.DictionaryConcreteReference: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringPutBenchmark.FictionaryConcreteReference: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringPutBenchmark.DictionaryVirtualValue: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringPutBenchmark.FictionaryVirtualValue: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringPutBenchmark.DictionaryVirtualReference: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringPutBenchmark.FictionaryVirtualReference: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringPutBenchmark.DictionaryStandardPolymorphic: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  StringPutBenchmark.FictionaryStandardPolymorphic: Job-IDXOEF(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
