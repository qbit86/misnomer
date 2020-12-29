``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  Job-NJOOHK : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-JEQPMW : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-XEFIAZ : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-LZQKTZ : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-QPPMUW : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-GVDNMT : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Platform=X64  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                        Method |        Job |       Jit |       Runtime |      Mean |      Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------------ |----------- |---------- |-------------- |----------:|-----------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|       DictionaryConcreteValue | Job-NJOOHK | LegacyJit |    .NET 4.6.1 | 155.66 μs |  62.067 μs |  3.402 μs | 154.57 μs |  1.06 |    0.03 | 62.2559 | 7.5684 |     - |   54581 B |
|       FictionaryConcreteValue | Job-NJOOHK | LegacyJit |    .NET 4.6.1 | 124.36 μs |  47.167 μs |  2.585 μs | 123.08 μs |  0.85 |    0.01 | 14.8926 |      - |     - |    7942 B |
|   DictionaryConcreteReference | Job-NJOOHK | LegacyJit |    .NET 4.6.1 | 147.03 μs |  41.022 μs |  2.249 μs | 147.67 μs |  1.00 |    0.00 | 62.2559 | 7.5684 |     - |   54581 B |
|   FictionaryConcreteReference | Job-NJOOHK | LegacyJit |    .NET 4.6.1 | 103.49 μs |  45.705 μs |  2.505 μs | 102.52 μs |  0.70 |    0.03 | 14.8926 |      - |     - |    7942 B |
|        DictionaryVirtualValue | Job-NJOOHK | LegacyJit |    .NET 4.6.1 |  99.36 μs |  39.943 μs |  2.189 μs |  98.18 μs |  0.68 |    0.03 | 62.3779 | 7.6904 |     - |   54581 B |
|        FictionaryVirtualValue | Job-NJOOHK | LegacyJit |    .NET 4.6.1 | 129.35 μs | 569.349 μs | 31.208 μs | 111.64 μs |  0.88 |    0.21 | 14.8926 |      - |     - |    7942 B |
|    DictionaryVirtualReference | Job-NJOOHK | LegacyJit |    .NET 4.6.1 |  92.43 μs |  34.275 μs |  1.879 μs |  91.91 μs |  0.63 |    0.01 | 62.3779 | 7.6904 |     - |   54581 B |
|    FictionaryVirtualReference | Job-NJOOHK | LegacyJit |    .NET 4.6.1 |  99.93 μs |   5.449 μs |  0.299 μs |  99.99 μs |  0.68 |    0.01 | 14.8926 |      - |     - |    7942 B |
| DictionaryStandardPolymorphic | Job-NJOOHK | LegacyJit |    .NET 4.6.1 |  87.74 μs |   2.346 μs |  0.129 μs |  87.69 μs |  0.60 |    0.01 | 62.3779 | 7.6904 |     - |   54581 B |
| FictionaryStandardPolymorphic | Job-NJOOHK | LegacyJit |    .NET 4.6.1 | 104.20 μs |   2.143 μs |  0.117 μs | 104.13 μs |  0.71 |    0.01 | 14.8926 |      - |     - |    7942 B |
|             DictionaryDefault | Job-NJOOHK | LegacyJit |    .NET 4.6.1 |  89.28 μs |  71.185 μs |  3.902 μs |  87.62 μs |  0.61 |    0.04 | 62.2559 | 7.5684 |     - |   54581 B |
|                               |            |           |               |           |            |           |           |       |         |         |        |       |           |
|       DictionaryConcreteValue | Job-JEQPMW | LegacyJit |      .NET 4.8 |  98.47 μs |  24.775 μs |  1.358 μs |  98.28 μs |  1.08 |    0.01 | 62.3779 | 7.6904 |     - |   54581 B |
|       FictionaryConcreteValue | Job-JEQPMW | LegacyJit |      .NET 4.8 |  79.74 μs |  10.177 μs |  0.558 μs |  79.91 μs |  0.87 |    0.01 | 14.8926 |      - |     - |    7942 B |
|   DictionaryConcreteReference | Job-JEQPMW | LegacyJit |      .NET 4.8 |  91.26 μs |   5.411 μs |  0.297 μs |  91.26 μs |  1.00 |    0.00 | 62.3779 | 7.6904 |     - |   54581 B |
|   FictionaryConcreteReference | Job-JEQPMW | LegacyJit |      .NET 4.8 | 104.35 μs |   0.890 μs |  0.049 μs | 104.36 μs |  1.14 |    0.00 | 14.8926 |      - |     - |    7942 B |
|        DictionaryVirtualValue | Job-JEQPMW | LegacyJit |      .NET 4.8 |  97.04 μs |   3.496 μs |  0.192 μs |  97.01 μs |  1.06 |    0.01 | 62.3779 | 7.6904 |     - |   54581 B |
|        FictionaryVirtualValue | Job-JEQPMW | LegacyJit |      .NET 4.8 | 115.49 μs |  39.520 μs |  2.166 μs | 114.38 μs |  1.27 |    0.03 | 14.8926 |      - |     - |    7942 B |
|    DictionaryVirtualReference | Job-JEQPMW | LegacyJit |      .NET 4.8 | 114.73 μs | 729.582 μs | 39.991 μs |  91.86 μs |  1.26 |    0.44 | 62.3779 | 7.6904 |     - |   54581 B |
|    FictionaryVirtualReference | Job-JEQPMW | LegacyJit |      .NET 4.8 | 100.12 μs |  15.136 μs |  0.830 μs | 100.22 μs |  1.10 |    0.01 | 14.8926 |      - |     - |    7942 B |
| DictionaryStandardPolymorphic | Job-JEQPMW | LegacyJit |      .NET 4.8 |  86.17 μs |   4.009 μs |  0.220 μs |  86.29 μs |  0.94 |    0.00 | 62.3779 | 7.6904 |     - |   54581 B |
| FictionaryStandardPolymorphic | Job-JEQPMW | LegacyJit |      .NET 4.8 | 104.40 μs |  42.123 μs |  2.309 μs | 103.10 μs |  1.14 |    0.03 | 14.8926 |      - |     - |    7942 B |
|             DictionaryDefault | Job-JEQPMW | LegacyJit |      .NET 4.8 |  87.37 μs |  10.944 μs |  0.600 μs |  87.15 μs |  0.96 |    0.00 | 62.3779 | 7.6904 |     - |   54581 B |
|                               |            |           |               |           |            |           |           |       |         |         |        |       |           |
|       DictionaryConcreteValue | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 | 122.41 μs | 810.590 μs | 44.431 μs |  96.78 μs |  1.34 |    0.49 | 62.3779 | 7.6904 |     - |   54581 B |
|       FictionaryConcreteValue | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 |  94.16 μs | 417.954 μs | 22.909 μs |  81.12 μs |  1.03 |    0.25 | 14.8926 |      - |     - |    7942 B |
|   DictionaryConcreteReference | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 |  91.07 μs |   6.644 μs |  0.364 μs |  90.99 μs |  1.00 |    0.00 | 62.3779 | 7.6904 |     - |   54581 B |
|   FictionaryConcreteReference | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 |  99.53 μs |   0.720 μs |  0.039 μs |  99.52 μs |  1.09 |    0.00 | 14.8926 |      - |     - |    7942 B |
|        DictionaryVirtualValue | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 |  96.54 μs |   3.013 μs |  0.165 μs |  96.62 μs |  1.06 |    0.00 | 62.3779 | 7.6904 |     - |   54581 B |
|        FictionaryVirtualValue | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 | 109.39 μs |   7.169 μs |  0.393 μs | 109.30 μs |  1.20 |    0.01 | 14.8926 |      - |     - |    7942 B |
|    DictionaryVirtualReference | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 |  95.34 μs |  65.075 μs |  3.567 μs |  95.86 μs |  1.05 |    0.04 | 62.3779 | 7.6904 |     - |   54581 B |
|    FictionaryVirtualReference | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 | 101.91 μs |  19.139 μs |  1.049 μs | 102.24 μs |  1.12 |    0.01 | 14.8926 |      - |     - |    7942 B |
| DictionaryStandardPolymorphic | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 |  89.34 μs |  15.099 μs |  0.828 μs |  89.25 μs |  0.98 |    0.01 | 62.3779 | 7.6904 |     - |   54581 B |
| FictionaryStandardPolymorphic | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 | 103.76 μs |   3.506 μs |  0.192 μs | 103.79 μs |  1.14 |    0.01 | 14.8926 |      - |     - |    7942 B |
|             DictionaryDefault | Job-XEFIAZ |    RyuJit |    .NET 4.6.1 |  87.14 μs |   2.391 μs |  0.131 μs |  87.18 μs |  0.96 |    0.01 | 62.3779 | 7.6904 |     - |   54581 B |
|                               |            |           |               |           |            |           |           |       |         |         |        |       |           |
|       DictionaryConcreteValue | Job-LZQKTZ |    RyuJit |      .NET 4.8 |  97.25 μs |   8.691 μs |  0.476 μs |  97.18 μs |  1.07 |    0.01 | 62.3779 | 7.6904 |     - |   54581 B |
|       FictionaryConcreteValue | Job-LZQKTZ |    RyuJit |      .NET 4.8 |  87.83 μs | 244.257 μs | 13.389 μs |  80.64 μs |  0.96 |    0.15 | 14.8926 |      - |     - |    7942 B |
|   DictionaryConcreteReference | Job-LZQKTZ |    RyuJit |      .NET 4.8 |  91.17 μs |   3.684 μs |  0.202 μs |  91.23 μs |  1.00 |    0.00 | 62.3779 | 7.6904 |     - |   54581 B |
|   FictionaryConcreteReference | Job-LZQKTZ |    RyuJit |      .NET 4.8 | 104.18 μs |   0.221 μs |  0.012 μs | 104.18 μs |  1.14 |    0.00 | 14.8926 |      - |     - |    7942 B |
|        DictionaryVirtualValue | Job-LZQKTZ |    RyuJit |      .NET 4.8 |  96.98 μs |   9.767 μs |  0.535 μs |  96.67 μs |  1.06 |    0.00 | 62.3779 | 7.6904 |     - |   54581 B |
|        FictionaryVirtualValue | Job-LZQKTZ |    RyuJit |      .NET 4.8 | 114.47 μs |   2.277 μs |  0.125 μs | 114.50 μs |  1.26 |    0.00 | 14.8926 |      - |     - |    7942 B |
|    DictionaryVirtualReference | Job-LZQKTZ |    RyuJit |      .NET 4.8 |  92.07 μs |  26.868 μs |  1.473 μs |  91.41 μs |  1.01 |    0.01 | 62.3779 | 7.6904 |     - |   54581 B |
|    FictionaryVirtualReference | Job-LZQKTZ |    RyuJit |      .NET 4.8 | 100.11 μs |   0.357 μs |  0.020 μs | 100.12 μs |  1.10 |    0.00 | 14.8926 |      - |     - |    7942 B |
| DictionaryStandardPolymorphic | Job-LZQKTZ |    RyuJit |      .NET 4.8 |  86.25 μs |   6.470 μs |  0.355 μs |  86.44 μs |  0.95 |    0.00 | 62.3779 | 7.6904 |     - |   54581 B |
| FictionaryStandardPolymorphic | Job-LZQKTZ |    RyuJit |      .NET 4.8 | 106.81 μs |  12.593 μs |  0.690 μs | 106.42 μs |  1.17 |    0.01 | 14.8926 |      - |     - |    7942 B |
|             DictionaryDefault | Job-LZQKTZ |    RyuJit |      .NET 4.8 |  87.12 μs |   2.344 μs |  0.128 μs |  87.18 μs |  0.96 |    0.00 | 62.3779 | 7.6904 |     - |   54581 B |
|                               |            |           |               |           |            |           |           |       |         |         |        |       |           |
|       DictionaryConcreteValue | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
|       FictionaryConcreteValue | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
|   DictionaryConcreteReference | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
|   FictionaryConcreteReference | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
|        DictionaryVirtualValue | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
|        FictionaryVirtualValue | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
|    DictionaryVirtualReference | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
|    FictionaryVirtualReference | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
| DictionaryStandardPolymorphic | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
| FictionaryStandardPolymorphic | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
|             DictionaryDefault | Job-XBPETB |    RyuJit | .NET Core 2.1 |        NA |         NA |        NA |        NA |     ? |       ? |       - |      - |     - |         - |
|                               |            |           |               |           |            |           |           |       |         |         |        |       |           |
|       DictionaryConcreteValue | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  81.57 μs |  52.965 μs |  2.903 μs |  80.19 μs |  1.16 |    0.05 | 25.6348 |      - |     - |   54216 B |
|       FictionaryConcreteValue | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  57.88 μs | 176.960 μs |  9.700 μs |  52.46 μs |  0.82 |    0.15 |  3.7231 |      - |     - |    7824 B |
|   DictionaryConcreteReference | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  70.40 μs |  18.501 μs |  1.014 μs |  70.10 μs |  1.00 |    0.00 | 25.6348 |      - |     - |   54192 B |
|   FictionaryConcreteReference | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  76.35 μs |  10.030 μs |  0.550 μs |  76.41 μs |  1.08 |    0.01 |  3.6621 |      - |     - |    7824 B |
|        DictionaryVirtualValue | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  85.03 μs |  39.897 μs |  2.187 μs |  83.99 μs |  1.21 |    0.05 | 25.6348 |      - |     - |   54216 B |
|        FictionaryVirtualValue | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  91.59 μs |   6.962 μs |  0.382 μs |  91.61 μs |  1.30 |    0.02 |  3.6621 |      - |     - |    7848 B |
|    DictionaryVirtualReference | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  70.51 μs |   7.791 μs |  0.427 μs |  70.39 μs |  1.00 |    0.02 | 25.6348 |      - |     - |   54192 B |
|    FictionaryVirtualReference | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  87.25 μs | 256.778 μs | 14.075 μs |  81.24 μs |  1.24 |    0.20 |  3.6621 |      - |     - |    7824 B |
| DictionaryStandardPolymorphic | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  55.80 μs |   8.563 μs |  0.469 μs |  55.57 μs |  0.79 |    0.01 | 25.6348 |      - |     - |   54192 B |
| FictionaryStandardPolymorphic | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  75.75 μs |   2.947 μs |  0.162 μs |  75.78 μs |  1.08 |    0.02 |  3.6621 |      - |     - |    7824 B |
|             DictionaryDefault | Job-QPPMUW |    RyuJit | .NET Core 3.1 |  55.47 μs |   2.091 μs |  0.115 μs |  55.52 μs |  0.79 |    0.01 | 25.6348 |      - |     - |   54192 B |
|                               |            |           |               |           |            |           |           |       |         |         |        |       |           |
|       DictionaryConcreteValue | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  80.55 μs |  51.878 μs |  2.844 μs |  79.16 μs |  1.00 |    0.25 | 25.6348 |      - |     - |   54224 B |
|       FictionaryConcreteValue | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  58.82 μs |  13.366 μs |  0.733 μs |  59.13 μs |  0.73 |    0.16 |  3.7231 |      - |     - |    7824 B |
|   DictionaryConcreteReference | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  83.73 μs | 397.285 μs | 21.777 μs |  71.60 μs |  1.00 |    0.00 | 25.6348 |      - |     - |   54200 B |
|   FictionaryConcreteReference | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  74.75 μs |   8.601 μs |  0.471 μs |  74.62 μs |  0.93 |    0.21 |  3.6621 |      - |     - |    7824 B |
|        DictionaryVirtualValue | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  77.87 μs |   3.219 μs |  0.176 μs |  77.92 μs |  0.97 |    0.22 | 25.6348 |      - |     - |   54224 B |
|        FictionaryVirtualValue | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  84.66 μs |  10.804 μs |  0.592 μs |  84.63 μs |  1.05 |    0.24 |  3.6621 |      - |     - |    7848 B |
|    DictionaryVirtualReference | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  69.32 μs |  10.203 μs |  0.559 μs |  69.46 μs |  0.86 |    0.20 | 25.6348 |      - |     - |   54200 B |
|    FictionaryVirtualReference | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  76.72 μs |   6.938 μs |  0.380 μs |  76.94 μs |  0.95 |    0.21 |  3.6621 |      - |     - |    7824 B |
| DictionaryStandardPolymorphic | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  54.94 μs |  17.943 μs |  0.983 μs |  54.37 μs |  0.68 |    0.14 | 25.6348 |      - |     - |   54200 B |
| FictionaryStandardPolymorphic | Job-GVDNMT |    RyuJit | .NET Core 5.0 |  76.80 μs |  35.484 μs |  1.945 μs |  76.05 μs |  0.96 |    0.23 |  3.6621 |      - |     - |    7824 B |
|             DictionaryDefault | Job-GVDNMT |    RyuJit | .NET Core 5.0 | 104.06 μs |  55.012 μs |  3.015 μs | 105.78 μs |  1.29 |    0.28 | 25.6348 |      - |     - |   54200 B |

Benchmarks with issues:
  DateTimePutBenchmark.DictionaryConcreteValue: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.FictionaryConcreteValue: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.DictionaryConcreteReference: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.FictionaryConcreteReference: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.DictionaryVirtualValue: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.FictionaryVirtualValue: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.DictionaryVirtualReference: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.FictionaryVirtualReference: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.DictionaryStandardPolymorphic: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.FictionaryStandardPolymorphic: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
  DateTimePutBenchmark.DictionaryDefault: Job-XBPETB(Jit=RyuJit, Platform=X64, Runtime=.NET Core 2.1, IterationCount=3, LaunchCount=1, WarmupCount=3)
