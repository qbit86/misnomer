``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 2.1.23 (CoreCLR 4.6.29321.03, CoreFX 4.6.29321.01), X64 RyuJIT
  Job-DDEYNG : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-ZFRBSS : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-UKNJYN : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-JYIBDQ : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-QXQNSA : .NET Core 2.1.23 (CoreCLR 4.6.29321.03, CoreFX 4.6.29321.01), X64 RyuJIT
  Job-GIIYJK : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  Job-MCIPQK : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT

Platform=X64  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                        Method |        Job |       Jit |       Runtime |       Mean |       Error |    StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 |  Allocated |
|------------------------------ |----------- |---------- |-------------- |-----------:|------------:|----------:|------:|--------:|----------:|------:|------:|-----------:|
|       DictionaryConcreteValue | Job-DDEYNG | LegacyJit |    .NET 4.6.1 |   187.3 μs |    23.47 μs |   1.29 μs |  1.01 |    0.00 |   21.9727 |     - |     - |   68.21 KB |
|       FictionaryConcreteValue | Job-DDEYNG | LegacyJit |    .NET 4.6.1 |   140.7 μs |    41.22 μs |   2.26 μs |  0.76 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
|   DictionaryConcreteReference | Job-DDEYNG | LegacyJit |    .NET 4.6.1 |   184.6 μs |    27.13 μs |   1.49 μs |  1.00 |    0.00 |   21.9727 |     - |     - |   68.21 KB |
|   FictionaryConcreteReference | Job-DDEYNG | LegacyJit |    .NET 4.6.1 |   196.0 μs |    38.08 μs |   2.09 μs |  1.06 |    0.02 |    2.4414 |     - |     - |    7.68 KB |
|        DictionaryVirtualValue | Job-DDEYNG | LegacyJit |    .NET 4.6.1 |   186.5 μs |    12.78 μs |   0.70 μs |  1.01 |    0.01 |   21.9727 |     - |     - |   68.21 KB |
|        FictionaryVirtualValue | Job-DDEYNG | LegacyJit |    .NET 4.6.1 |   198.0 μs |    19.18 μs |   1.05 μs |  1.07 |    0.01 |    2.4414 |     - |     - |     7.7 KB |
|    DictionaryVirtualReference | Job-DDEYNG | LegacyJit |    .NET 4.6.1 |   185.3 μs |    23.65 μs |   1.30 μs |  1.00 |    0.01 |   21.9727 |     - |     - |   68.21 KB |
|    FictionaryVirtualReference | Job-DDEYNG | LegacyJit |    .NET 4.6.1 |   197.5 μs |    34.63 μs |   1.90 μs |  1.07 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
| DictionaryStandardPolymorphic | Job-DDEYNG | LegacyJit |    .NET 4.6.1 | 1,516.1 μs | 2,163.37 μs | 118.58 μs |  8.22 |    0.70 | 1023.4375 |     - |     - | 3146.07 KB |
| FictionaryStandardPolymorphic | Job-DDEYNG | LegacyJit |    .NET 4.6.1 | 1,627.0 μs |   277.03 μs |  15.18 μs |  8.81 |    0.15 | 1003.9063 |     - |     - | 3085.63 KB |
|             DictionaryDefault | Job-DDEYNG | LegacyJit |    .NET 4.6.1 | 1,483.9 μs | 1,779.25 μs |  97.53 μs |  8.04 |    0.58 | 1023.4375 |     - |     - | 3146.07 KB |
|                               |            |           |               |            |             |           |       |         |           |       |       |            |
|       DictionaryConcreteValue | Job-ZFRBSS | LegacyJit |      .NET 4.8 |   186.5 μs |    25.08 μs |   1.37 μs |  1.01 |    0.01 |   21.9727 |     - |     - |   68.21 KB |
|       FictionaryConcreteValue | Job-ZFRBSS | LegacyJit |      .NET 4.8 |   138.3 μs |    31.80 μs |   1.74 μs |  0.75 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
|   DictionaryConcreteReference | Job-ZFRBSS | LegacyJit |      .NET 4.8 |   184.8 μs |     7.77 μs |   0.43 μs |  1.00 |    0.00 |   21.9727 |     - |     - |   68.21 KB |
|   FictionaryConcreteReference | Job-ZFRBSS | LegacyJit |      .NET 4.8 |   198.2 μs |    35.10 μs |   1.92 μs |  1.07 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
|        DictionaryVirtualValue | Job-ZFRBSS | LegacyJit |      .NET 4.8 |   186.7 μs |    25.55 μs |   1.40 μs |  1.01 |    0.01 |   21.9727 |     - |     - |   68.21 KB |
|        FictionaryVirtualValue | Job-ZFRBSS | LegacyJit |      .NET 4.8 |   197.8 μs |    10.49 μs |   0.58 μs |  1.07 |    0.00 |    2.4414 |     - |     - |     7.7 KB |
|    DictionaryVirtualReference | Job-ZFRBSS | LegacyJit |      .NET 4.8 |   184.1 μs |    16.39 μs |   0.90 μs |  1.00 |    0.00 |   21.9727 |     - |     - |   68.21 KB |
|    FictionaryVirtualReference | Job-ZFRBSS | LegacyJit |      .NET 4.8 |   195.6 μs |    24.96 μs |   1.37 μs |  1.06 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
| DictionaryStandardPolymorphic | Job-ZFRBSS | LegacyJit |      .NET 4.8 | 1,541.6 μs |   848.95 μs |  46.53 μs |  8.34 |    0.27 | 1023.4375 |     - |     - | 3146.07 KB |
| FictionaryStandardPolymorphic | Job-ZFRBSS | LegacyJit |      .NET 4.8 | 1,430.2 μs |   512.36 μs |  28.08 μs |  7.74 |    0.17 | 1003.9063 |     - |     - | 3085.63 KB |
|             DictionaryDefault | Job-ZFRBSS | LegacyJit |      .NET 4.8 | 1,395.7 μs | 2,517.15 μs | 137.97 μs |  7.55 |    0.77 | 1023.4375 |     - |     - | 3146.07 KB |
|                               |            |           |               |            |             |           |       |         |           |       |       |            |
|       DictionaryConcreteValue | Job-UKNJYN |    RyuJit |    .NET 4.6.1 |   187.0 μs |     8.43 μs |   0.46 μs |  1.01 |    0.01 |   21.9727 |     - |     - |   68.21 KB |
|       FictionaryConcreteValue | Job-UKNJYN |    RyuJit |    .NET 4.6.1 |   139.7 μs |    26.41 μs |   1.45 μs |  0.75 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
|   DictionaryConcreteReference | Job-UKNJYN |    RyuJit |    .NET 4.6.1 |   185.4 μs |    17.11 μs |   0.94 μs |  1.00 |    0.00 |   21.9727 |     - |     - |   68.21 KB |
|   FictionaryConcreteReference | Job-UKNJYN |    RyuJit |    .NET 4.6.1 |   193.2 μs |     9.42 μs |   0.52 μs |  1.04 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
|        DictionaryVirtualValue | Job-UKNJYN |    RyuJit |    .NET 4.6.1 |   186.9 μs |    27.78 μs |   1.52 μs |  1.01 |    0.01 |   21.9727 |     - |     - |   68.21 KB |
|        FictionaryVirtualValue | Job-UKNJYN |    RyuJit |    .NET 4.6.1 |   197.0 μs |    20.23 μs |   1.11 μs |  1.06 |    0.01 |    2.4414 |     - |     - |     7.7 KB |
|    DictionaryVirtualReference | Job-UKNJYN |    RyuJit |    .NET 4.6.1 |   186.4 μs |    22.66 μs |   1.24 μs |  1.01 |    0.01 |   21.9727 |     - |     - |   68.21 KB |
|    FictionaryVirtualReference | Job-UKNJYN |    RyuJit |    .NET 4.6.1 |   195.0 μs |    21.90 μs |   1.20 μs |  1.05 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
| DictionaryStandardPolymorphic | Job-UKNJYN |    RyuJit |    .NET 4.6.1 | 1,489.4 μs | 2,041.16 μs | 111.88 μs |  8.03 |    0.63 | 1023.4375 |     - |     - | 3146.07 KB |
| FictionaryStandardPolymorphic | Job-UKNJYN |    RyuJit |    .NET 4.6.1 | 1,638.4 μs |   250.49 μs |  13.73 μs |  8.84 |    0.08 | 1003.9063 |     - |     - | 3085.63 KB |
|             DictionaryDefault | Job-UKNJYN |    RyuJit |    .NET 4.6.1 | 1,554.4 μs |   264.43 μs |  14.49 μs |  8.38 |    0.11 | 1023.4375 |     - |     - | 3146.07 KB |
|                               |            |           |               |            |             |           |       |         |           |       |       |            |
|       DictionaryConcreteValue | Job-JYIBDQ |    RyuJit |      .NET 4.8 |   187.1 μs |     5.01 μs |   0.27 μs |  1.02 |    0.02 |   21.9727 |     - |     - |   68.21 KB |
|       FictionaryConcreteValue | Job-JYIBDQ |    RyuJit |      .NET 4.8 |   139.9 μs |    26.59 μs |   1.46 μs |  0.76 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
|   DictionaryConcreteReference | Job-JYIBDQ |    RyuJit |      .NET 4.8 |   183.9 μs |    69.19 μs |   3.79 μs |  1.00 |    0.00 |   21.9727 |     - |     - |   68.21 KB |
|   FictionaryConcreteReference | Job-JYIBDQ |    RyuJit |      .NET 4.8 |   198.6 μs |    12.27 μs |   0.67 μs |  1.08 |    0.02 |    2.4414 |     - |     - |    7.68 KB |
|        DictionaryVirtualValue | Job-JYIBDQ |    RyuJit |      .NET 4.8 |   186.4 μs |    35.47 μs |   1.94 μs |  1.01 |    0.03 |   21.9727 |     - |     - |   68.21 KB |
|        FictionaryVirtualValue | Job-JYIBDQ |    RyuJit |      .NET 4.8 |   197.9 μs |    22.28 μs |   1.22 μs |  1.08 |    0.03 |    2.4414 |     - |     - |     7.7 KB |
|    DictionaryVirtualReference | Job-JYIBDQ |    RyuJit |      .NET 4.8 |   186.3 μs |     8.04 μs |   0.44 μs |  1.01 |    0.02 |   21.9727 |     - |     - |   68.21 KB |
|    FictionaryVirtualReference | Job-JYIBDQ |    RyuJit |      .NET 4.8 |   199.7 μs |    40.59 μs |   2.22 μs |  1.09 |    0.01 |    2.4414 |     - |     - |    7.68 KB |
| DictionaryStandardPolymorphic | Job-JYIBDQ |    RyuJit |      .NET 4.8 | 1,538.8 μs | 1,137.07 μs |  62.33 μs |  8.36 |    0.17 | 1023.4375 |     - |     - | 3146.07 KB |
| FictionaryStandardPolymorphic | Job-JYIBDQ |    RyuJit |      .NET 4.8 | 1,617.0 μs |   465.55 μs |  25.52 μs |  8.79 |    0.06 | 1003.9063 |     - |     - | 3085.63 KB |
|             DictionaryDefault | Job-JYIBDQ |    RyuJit |      .NET 4.8 | 1,494.0 μs | 1,699.32 μs |  93.15 μs |  8.12 |    0.34 | 1023.4375 |     - |     - | 3146.07 KB |
|                               |            |           |               |            |             |           |       |         |           |       |       |            |
|       DictionaryConcreteValue | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   182.0 μs |     8.79 μs |   0.48 μs |  1.02 |    0.01 |   21.7285 |     - |     - |   68.04 KB |
|       FictionaryConcreteValue | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   123.7 μs |    11.61 μs |   0.64 μs |  0.69 |    0.01 |    2.4414 |     - |     - |    7.64 KB |
|   DictionaryConcreteReference | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   178.4 μs |    37.00 μs |   2.03 μs |  1.00 |    0.00 |   21.7285 |     - |     - |   68.02 KB |
|   FictionaryConcreteReference | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   181.9 μs |    13.17 μs |   0.72 μs |  1.02 |    0.02 |    2.4414 |     - |     - |    7.64 KB |
|        DictionaryVirtualValue | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   184.7 μs |     5.31 μs |   0.29 μs |  1.04 |    0.01 |   21.7285 |     - |     - |   68.04 KB |
|        FictionaryVirtualValue | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   183.7 μs |    24.53 μs |   1.34 μs |  1.03 |    0.02 |    2.4414 |     - |     - |    7.66 KB |
|    DictionaryVirtualReference | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   180.4 μs |    16.24 μs |   0.89 μs |  1.01 |    0.01 |   21.7285 |     - |     - |   68.02 KB |
|    FictionaryVirtualReference | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   183.7 μs |    31.93 μs |   1.75 μs |  1.03 |    0.01 |    2.4414 |     - |     - |    7.64 KB |
| DictionaryStandardPolymorphic | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   150.4 μs |    99.84 μs |   5.47 μs |  0.84 |    0.02 |   39.7949 |     - |     - |  124.17 KB |
| FictionaryStandardPolymorphic | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   177.0 μs |    27.15 μs |   1.49 μs |  0.99 |    0.02 |   20.7520 |     - |     - |    63.8 KB |
|             DictionaryDefault | Job-QXQNSA |    RyuJit | .NET Core 2.1 |   149.7 μs |   103.49 μs |   5.67 μs |  0.84 |    0.02 |   39.7949 |     - |     - |  124.17 KB |
|                               |            |           |               |            |             |           |       |         |           |       |       |            |
|       DictionaryConcreteValue | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   167.9 μs |    17.63 μs |   0.97 μs |  0.99 |    0.01 |   21.9727 |     - |     - |   68.03 KB |
|       FictionaryConcreteValue | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   110.5 μs |    13.99 μs |   0.77 μs |  0.65 |    0.00 |    2.4414 |     - |     - |    7.64 KB |
|   DictionaryConcreteReference | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   169.0 μs |     1.45 μs |   0.08 μs |  1.00 |    0.00 |   21.9727 |     - |     - |   68.01 KB |
|   FictionaryConcreteReference | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   166.6 μs |    37.40 μs |   2.05 μs |  0.99 |    0.01 |    2.4414 |     - |     - |    7.64 KB |
|        DictionaryVirtualValue | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   170.4 μs |    21.26 μs |   1.17 μs |  1.01 |    0.01 |   21.9727 |     - |     - |   68.03 KB |
|        FictionaryVirtualValue | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   168.7 μs |    19.25 μs |   1.05 μs |  1.00 |    0.01 |    2.4414 |     - |     - |    7.66 KB |
|    DictionaryVirtualReference | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   167.7 μs |    20.08 μs |   1.10 μs |  0.99 |    0.01 |   21.9727 |     - |     - |   68.01 KB |
|    FictionaryVirtualReference | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   167.8 μs |     2.75 μs |   0.15 μs |  0.99 |    0.00 |    2.4414 |     - |     - |    7.64 KB |
| DictionaryStandardPolymorphic | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   125.2 μs |     7.83 μs |   0.43 μs |  0.74 |    0.00 |   39.9170 |     - |     - |  124.16 KB |
| FictionaryStandardPolymorphic | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   156.1 μs |    51.91 μs |   2.85 μs |  0.92 |    0.02 |   20.7520 |     - |     - |    63.8 KB |
|             DictionaryDefault | Job-GIIYJK |    RyuJit | .NET Core 3.1 |   126.9 μs |    12.18 μs |   0.67 μs |  0.75 |    0.00 |   39.9170 |     - |     - |  124.16 KB |
|                               |            |           |               |            |             |           |       |         |           |       |       |            |
|       DictionaryConcreteValue | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   127.7 μs |    50.15 μs |   2.75 μs |  1.08 |    0.03 |   21.9727 |     - |     - |   68.04 KB |
|       FictionaryConcreteValue | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   115.5 μs |     5.01 μs |   0.27 μs |  0.97 |    0.00 |    2.4414 |     - |     - |    7.64 KB |
|   DictionaryConcreteReference | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   118.5 μs |    11.73 μs |   0.64 μs |  1.00 |    0.00 |   21.9727 |     - |     - |   68.02 KB |
|   FictionaryConcreteReference | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   134.8 μs |    13.74 μs |   0.75 μs |  1.14 |    0.01 |    2.4414 |     - |     - |    7.64 KB |
|        DictionaryVirtualValue | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   125.4 μs |    15.74 μs |   0.86 μs |  1.06 |    0.01 |   21.9727 |     - |     - |   68.04 KB |
|        FictionaryVirtualValue | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   139.1 μs |    37.92 μs |   2.08 μs |  1.17 |    0.01 |    2.4414 |     - |     - |    7.66 KB |
|    DictionaryVirtualReference | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   122.5 μs |    28.03 μs |   1.54 μs |  1.03 |    0.02 |   21.9727 |     - |     - |   68.02 KB |
|    FictionaryVirtualReference | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   135.4 μs |    11.96 μs |   0.66 μs |  1.14 |    0.01 |    2.4414 |     - |     - |    7.64 KB |
| DictionaryStandardPolymorphic | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   127.0 μs |    23.78 μs |   1.30 μs |  1.07 |    0.01 |   39.6729 |     - |     - |  122.17 KB |
| FictionaryStandardPolymorphic | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   154.1 μs |    52.33 μs |   2.87 μs |  1.30 |    0.03 |   20.0195 |     - |     - |    61.8 KB |
|             DictionaryDefault | Job-MCIPQK |    RyuJit | .NET Core 5.0 |   128.1 μs |    16.61 μs |   0.91 μs |  1.08 |    0.00 |   39.6729 |     - |     - |  122.17 KB |
