``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 2.1.23 (CoreCLR 4.6.29321.03, CoreFX 4.6.29321.01), X64 RyuJIT
  Job-IFVTRR : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-HUTDAA : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-AGNHDA : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-JSTEFY : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-LMYOEB : .NET Core 2.1.23 (CoreCLR 4.6.29321.03, CoreFX 4.6.29321.01), X64 RyuJIT
  Job-ECSCKY : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  Job-LFQAVS : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT

Platform=X64  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                        Method |        Job |       Jit |       Runtime |     Mean |     Error |   StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------ |----------- |---------- |-------------- |---------:|----------:|---------:|------:|--------:|------:|------:|------:|----------:|
|       DictionaryConcreteValue | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 31.25 ns |  9.885 ns | 0.542 ns |  0.99 |    0.02 |     - |     - |     - |         - |
|       FictionaryConcreteValue | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 21.43 ns |  2.336 ns | 0.128 ns |  0.68 |    0.02 |     - |     - |     - |         - |
|   DictionaryConcreteReference | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 31.52 ns | 13.006 ns | 0.713 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|   FictionaryConcreteReference | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 35.84 ns |  3.391 ns | 0.186 ns |  1.14 |    0.02 |     - |     - |     - |         - |
|        DictionaryVirtualValue | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 31.35 ns |  4.189 ns | 0.230 ns |  0.99 |    0.02 |     - |     - |     - |         - |
|        FictionaryVirtualValue | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 35.97 ns |  6.121 ns | 0.336 ns |  1.14 |    0.03 |     - |     - |     - |         - |
|    DictionaryVirtualReference | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 30.87 ns |  1.064 ns | 0.058 ns |  0.98 |    0.02 |     - |     - |     - |         - |
|    FictionaryVirtualReference | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 35.90 ns |  7.528 ns | 0.413 ns |  1.14 |    0.04 |     - |     - |     - |         - |
| DictionaryStandardPolymorphic | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 25.98 ns |  1.818 ns | 0.100 ns |  0.82 |    0.02 |     - |     - |     - |         - |
| FictionaryStandardPolymorphic | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 29.40 ns |  2.635 ns | 0.144 ns |  0.93 |    0.02 |     - |     - |     - |         - |
|             DictionaryDefault | Job-IFVTRR | LegacyJit |    .NET 4.6.1 | 25.72 ns |  1.797 ns | 0.099 ns |  0.82 |    0.02 |     - |     - |     - |         - |
|                               |            |           |               |          |           |          |       |         |       |       |       |           |
|       DictionaryConcreteValue | Job-HUTDAA | LegacyJit |      .NET 4.8 | 31.01 ns |  2.377 ns | 0.130 ns |  0.97 |    0.01 |     - |     - |     - |         - |
|       FictionaryConcreteValue | Job-HUTDAA | LegacyJit |      .NET 4.8 | 21.91 ns | 11.705 ns | 0.642 ns |  0.69 |    0.02 |     - |     - |     - |         - |
|   DictionaryConcreteReference | Job-HUTDAA | LegacyJit |      .NET 4.8 | 31.96 ns |  4.292 ns | 0.235 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|   FictionaryConcreteReference | Job-HUTDAA | LegacyJit |      .NET 4.8 | 35.45 ns |  1.051 ns | 0.058 ns |  1.11 |    0.01 |     - |     - |     - |         - |
|        DictionaryVirtualValue | Job-HUTDAA | LegacyJit |      .NET 4.8 | 31.25 ns |  2.978 ns | 0.163 ns |  0.98 |    0.01 |     - |     - |     - |         - |
|        FictionaryVirtualValue | Job-HUTDAA | LegacyJit |      .NET 4.8 | 36.12 ns |  1.891 ns | 0.104 ns |  1.13 |    0.01 |     - |     - |     - |         - |
|    DictionaryVirtualReference | Job-HUTDAA | LegacyJit |      .NET 4.8 | 30.89 ns |  4.494 ns | 0.246 ns |  0.97 |    0.01 |     - |     - |     - |         - |
|    FictionaryVirtualReference | Job-HUTDAA | LegacyJit |      .NET 4.8 | 36.30 ns |  2.040 ns | 0.112 ns |  1.14 |    0.01 |     - |     - |     - |         - |
| DictionaryStandardPolymorphic | Job-HUTDAA | LegacyJit |      .NET 4.8 | 25.79 ns |  2.745 ns | 0.150 ns |  0.81 |    0.01 |     - |     - |     - |         - |
| FictionaryStandardPolymorphic | Job-HUTDAA | LegacyJit |      .NET 4.8 | 28.73 ns |  2.482 ns | 0.136 ns |  0.90 |    0.01 |     - |     - |     - |         - |
|             DictionaryDefault | Job-HUTDAA | LegacyJit |      .NET 4.8 | 26.03 ns |  1.703 ns | 0.093 ns |  0.81 |    0.00 |     - |     - |     - |         - |
|                               |            |           |               |          |           |          |       |         |       |       |       |           |
|       DictionaryConcreteValue | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 31.30 ns |  1.934 ns | 0.106 ns |  1.01 |    0.01 |     - |     - |     - |         - |
|       FictionaryConcreteValue | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 21.61 ns |  0.535 ns | 0.029 ns |  0.70 |    0.01 |     - |     - |     - |         - |
|   DictionaryConcreteReference | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 30.85 ns |  5.280 ns | 0.289 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|   FictionaryConcreteReference | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 35.40 ns |  2.718 ns | 0.149 ns |  1.15 |    0.01 |     - |     - |     - |         - |
|        DictionaryVirtualValue | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 30.86 ns |  8.457 ns | 0.464 ns |  1.00 |    0.01 |     - |     - |     - |         - |
|        FictionaryVirtualValue | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 36.25 ns |  6.963 ns | 0.382 ns |  1.18 |    0.02 |     - |     - |     - |         - |
|    DictionaryVirtualReference | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 30.54 ns |  5.064 ns | 0.278 ns |  0.99 |    0.01 |     - |     - |     - |         - |
|    FictionaryVirtualReference | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 36.72 ns |  5.307 ns | 0.291 ns |  1.19 |    0.02 |     - |     - |     - |         - |
| DictionaryStandardPolymorphic | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 25.79 ns |  0.195 ns | 0.011 ns |  0.84 |    0.01 |     - |     - |     - |         - |
| FictionaryStandardPolymorphic | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 29.04 ns |  6.508 ns | 0.357 ns |  0.94 |    0.01 |     - |     - |     - |         - |
|             DictionaryDefault | Job-AGNHDA |    RyuJit |    .NET 4.6.1 | 25.68 ns |  9.208 ns | 0.505 ns |  0.83 |    0.02 |     - |     - |     - |         - |
|                               |            |           |               |          |           |          |       |         |       |       |       |           |
|       DictionaryConcreteValue | Job-JSTEFY |    RyuJit |      .NET 4.8 | 31.20 ns |  5.621 ns | 0.308 ns |  1.01 |    0.01 |     - |     - |     - |         - |
|       FictionaryConcreteValue | Job-JSTEFY |    RyuJit |      .NET 4.8 | 21.32 ns |  1.646 ns | 0.090 ns |  0.69 |    0.01 |     - |     - |     - |         - |
|   DictionaryConcreteReference | Job-JSTEFY |    RyuJit |      .NET 4.8 | 30.99 ns |  4.398 ns | 0.241 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|   FictionaryConcreteReference | Job-JSTEFY |    RyuJit |      .NET 4.8 | 35.23 ns |  3.096 ns | 0.170 ns |  1.14 |    0.01 |     - |     - |     - |         - |
|        DictionaryVirtualValue | Job-JSTEFY |    RyuJit |      .NET 4.8 | 30.91 ns |  4.967 ns | 0.272 ns |  1.00 |    0.01 |     - |     - |     - |         - |
|        FictionaryVirtualValue | Job-JSTEFY |    RyuJit |      .NET 4.8 | 35.70 ns |  4.877 ns | 0.267 ns |  1.15 |    0.02 |     - |     - |     - |         - |
|    DictionaryVirtualReference | Job-JSTEFY |    RyuJit |      .NET 4.8 | 30.85 ns |  5.503 ns | 0.302 ns |  1.00 |    0.01 |     - |     - |     - |         - |
|    FictionaryVirtualReference | Job-JSTEFY |    RyuJit |      .NET 4.8 | 35.23 ns |  2.169 ns | 0.119 ns |  1.14 |    0.01 |     - |     - |     - |         - |
| DictionaryStandardPolymorphic | Job-JSTEFY |    RyuJit |      .NET 4.8 | 25.65 ns |  4.378 ns | 0.240 ns |  0.83 |    0.01 |     - |     - |     - |         - |
| FictionaryStandardPolymorphic | Job-JSTEFY |    RyuJit |      .NET 4.8 | 28.18 ns |  3.264 ns | 0.179 ns |  0.91 |    0.01 |     - |     - |     - |         - |
|             DictionaryDefault | Job-JSTEFY |    RyuJit |      .NET 4.8 | 25.54 ns |  0.784 ns | 0.043 ns |  0.82 |    0.01 |     - |     - |     - |         - |
|                               |            |           |               |          |           |          |       |         |       |       |       |           |
|       DictionaryConcreteValue | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 36.39 ns |  0.705 ns | 0.039 ns |  1.12 |    0.00 |     - |     - |     - |         - |
|       FictionaryConcreteValue | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 23.45 ns |  4.147 ns | 0.227 ns |  0.72 |    0.01 |     - |     - |     - |         - |
|   DictionaryConcreteReference | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 32.61 ns |  1.964 ns | 0.108 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|   FictionaryConcreteReference | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 40.46 ns |  6.590 ns | 0.361 ns |  1.24 |    0.01 |     - |     - |     - |         - |
|        DictionaryVirtualValue | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 33.76 ns |  2.798 ns | 0.153 ns |  1.04 |    0.00 |     - |     - |     - |         - |
|        FictionaryVirtualValue | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 34.23 ns |  3.955 ns | 0.217 ns |  1.05 |    0.00 |     - |     - |     - |         - |
|    DictionaryVirtualReference | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 37.17 ns |  1.982 ns | 0.109 ns |  1.14 |    0.00 |     - |     - |     - |         - |
|    FictionaryVirtualReference | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 35.14 ns |  6.744 ns | 0.370 ns |  1.08 |    0.01 |     - |     - |     - |         - |
| DictionaryStandardPolymorphic | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 28.95 ns |  4.949 ns | 0.271 ns |  0.89 |    0.01 |     - |     - |     - |         - |
| FictionaryStandardPolymorphic | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 33.64 ns |  3.226 ns | 0.177 ns |  1.03 |    0.01 |     - |     - |     - |         - |
|             DictionaryDefault | Job-LMYOEB |    RyuJit | .NET Core 2.1 | 28.45 ns |  1.533 ns | 0.084 ns |  0.87 |    0.01 |     - |     - |     - |         - |
|                               |            |           |               |          |           |          |       |         |       |       |       |           |
|       DictionaryConcreteValue | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 24.81 ns |  1.983 ns | 0.109 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|       FictionaryConcreteValue | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 11.34 ns |  0.701 ns | 0.038 ns |  0.45 |    0.00 |     - |     - |     - |         - |
|   DictionaryConcreteReference | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 24.92 ns |  1.509 ns | 0.083 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|   FictionaryConcreteReference | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 25.78 ns |  1.076 ns | 0.059 ns |  1.03 |    0.00 |     - |     - |     - |         - |
|        DictionaryVirtualValue | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 25.60 ns |  1.502 ns | 0.082 ns |  1.03 |    0.01 |     - |     - |     - |         - |
|        FictionaryVirtualValue | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 34.28 ns |  1.935 ns | 0.106 ns |  1.38 |    0.00 |     - |     - |     - |         - |
|    DictionaryVirtualReference | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 24.93 ns |  0.509 ns | 0.028 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|    FictionaryVirtualReference | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 28.75 ns |  1.273 ns | 0.070 ns |  1.15 |    0.01 |     - |     - |     - |         - |
| DictionaryStandardPolymorphic | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 14.53 ns |  0.585 ns | 0.032 ns |  0.58 |    0.00 |     - |     - |     - |         - |
| FictionaryStandardPolymorphic | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 25.10 ns |  0.997 ns | 0.055 ns |  1.01 |    0.00 |     - |     - |     - |         - |
|             DictionaryDefault | Job-ECSCKY |    RyuJit | .NET Core 3.1 | 15.10 ns |  0.988 ns | 0.054 ns |  0.61 |    0.00 |     - |     - |     - |         - |
|                               |            |           |               |          |           |          |       |         |       |       |       |           |
|       DictionaryConcreteValue | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 16.79 ns |  1.120 ns | 0.061 ns |  1.30 |    0.02 |     - |     - |     - |         - |
|       FictionaryConcreteValue | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 11.71 ns |  3.212 ns | 0.176 ns |  0.91 |    0.01 |     - |     - |     - |         - |
|   DictionaryConcreteReference | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 12.86 ns |  3.252 ns | 0.178 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|   FictionaryConcreteReference | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 16.87 ns |  0.829 ns | 0.045 ns |  1.31 |    0.02 |     - |     - |     - |         - |
|        DictionaryVirtualValue | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 13.08 ns |  0.532 ns | 0.029 ns |  1.02 |    0.02 |     - |     - |     - |         - |
|        FictionaryVirtualValue | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 18.79 ns |  0.407 ns | 0.022 ns |  1.46 |    0.02 |     - |     - |     - |         - |
|    DictionaryVirtualReference | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 16.34 ns |  1.338 ns | 0.073 ns |  1.27 |    0.02 |     - |     - |     - |         - |
|    FictionaryVirtualReference | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 23.28 ns |  0.720 ns | 0.039 ns |  1.81 |    0.02 |     - |     - |     - |         - |
| DictionaryStandardPolymorphic | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 14.39 ns |  0.777 ns | 0.043 ns |  1.12 |    0.01 |     - |     - |     - |         - |
| FictionaryStandardPolymorphic | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 15.24 ns |  0.877 ns | 0.048 ns |  1.19 |    0.02 |     - |     - |     - |         - |
|             DictionaryDefault | Job-LFQAVS |    RyuJit | .NET Core 5.0 | 14.23 ns |  1.075 ns | 0.059 ns |  1.11 |    0.01 |     - |     - |     - |         - |
