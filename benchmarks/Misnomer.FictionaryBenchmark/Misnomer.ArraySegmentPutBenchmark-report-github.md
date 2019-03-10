``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-FOCSNJ : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-ETGCWR : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-JCWLIC : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-YZMMEH : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |       Mean |       Error |     StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |-----------:|------------:|-----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr |   177.6 us |   9.7951 us |  0.5369 us |  1.02 |    0.00 |     41.5039 |           - |           - |           128.23 KB |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr |   165.7 us |   6.8910 us |  0.3777 us |  0.95 |    0.00 |     41.5039 |     41.5039 |     41.5039 |           140.19 KB |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr |   174.9 us |   1.4544 us |  0.0797 us |  1.00 |    0.00 |     41.5039 |           - |           - |           128.23 KB |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr |   213.9 us |   4.7364 us |  0.2596 us |  1.22 |    0.00 |     41.5039 |     41.5039 |     41.5039 |           140.19 KB |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr |   176.8 us |   2.0009 us |  0.1097 us |  1.01 |    0.00 |     41.5039 |           - |           - |           128.23 KB |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr |   222.8 us |   3.9543 us |  0.2167 us |  1.27 |    0.00 |     41.5039 |     41.5039 |     41.5039 |           140.52 KB |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr |   177.8 us |  75.6156 us |  4.1447 us |  1.02 |    0.02 |     41.5039 |           - |           - |           128.23 KB |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr |   215.2 us |   3.5465 us |  0.1944 us |  1.23 |    0.00 |     41.5039 |     41.5039 |     41.5039 |           140.19 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 1,334.8 us |  41.2732 us |  2.2623 us |  7.63 |    0.01 |   1039.0625 |           - |           - |          3197.13 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 1,426.3 us |  31.0547 us |  1.7022 us |  8.16 |    0.01 |   1000.0000 |     41.0156 |     41.0156 |          3209.13 KB |
|             DictionaryDefault | LegacyJit |      X64 |     Clr | 1,301.2 us |  51.9120 us |  2.8455 us |  7.44 |    0.01 |   1039.0625 |           - |           - |          3197.13 KB |
|                               |           |          |         |            |             |            |       |         |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr |   155.3 us |   8.6941 us |  0.4766 us |  1.00 |    0.00 |     32.2266 |           - |           - |            99.58 KB |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr |   178.8 us |  10.2999 us |  0.5646 us |  1.16 |    0.01 |     31.0059 |     31.0059 |     31.0059 |           108.15 KB |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr |   154.6 us |   5.6595 us |  0.3102 us |  1.00 |    0.00 |     32.2266 |           - |           - |            99.55 KB |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr |   190.4 us |  10.2159 us |  0.5600 us |  1.23 |    0.01 |     31.0059 |     31.0059 |     31.0059 |           108.15 KB |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr |   156.5 us |  11.9188 us |  0.6533 us |  1.01 |    0.00 |     32.2266 |           - |           - |            99.58 KB |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr |   198.6 us |   8.1525 us |  0.4469 us |  1.28 |    0.00 |     31.0059 |     31.0059 |     31.0059 |           108.15 KB |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr |   154.6 us |   4.5864 us |  0.2514 us |  1.00 |    0.00 |     32.2266 |           - |           - |            99.55 KB |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr |   197.8 us |   0.7703 us |  0.0422 us |  1.28 |    0.00 |     31.0059 |     31.0059 |     31.0059 |           108.15 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 1,138.4 us |  27.6645 us |  1.5164 us |  7.36 |    0.01 |    656.2500 |           - |           - |          2017.67 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 1,104.8 us |  17.7621 us |  0.9736 us |  7.15 |    0.02 |    628.9063 |     31.2500 |     31.2500 |          2026.02 KB |
|             DictionaryDefault | LegacyJit |      X86 |     Clr | 1,087.0 us |  47.0903 us |  2.5812 us |  7.03 |    0.03 |    656.2500 |           - |           - |          2017.67 KB |
|                               |           |          |         |            |             |            |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr |   177.2 us |   4.9017 us |  0.2687 us |  1.01 |    0.00 |     41.5039 |           - |           - |           128.23 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr |   166.5 us |   2.5442 us |  0.1395 us |  0.95 |    0.00 |     41.5039 |     41.5039 |     41.5039 |           140.19 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr |   174.9 us |  10.1464 us |  0.5562 us |  1.00 |    0.00 |     41.5039 |           - |           - |           128.23 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr |   221.0 us |  98.1315 us |  5.3789 us |  1.26 |    0.03 |     41.5039 |     41.5039 |     41.5039 |           140.19 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr |   178.3 us |  14.8380 us |  0.8133 us |  1.02 |    0.00 |     41.5039 |           - |           - |           128.23 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr |   224.1 us |  30.6249 us |  1.6787 us |  1.28 |    0.01 |     41.5039 |     41.5039 |     41.5039 |           140.52 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr |   175.9 us |  20.3628 us |  1.1162 us |  1.01 |    0.00 |     41.5039 |           - |           - |           128.23 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr |   217.5 us |  39.7586 us |  2.1793 us |  1.24 |    0.01 |     41.5039 |     41.5039 |     41.5039 |           140.19 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 1,342.3 us | 197.8756 us | 10.8462 us |  7.68 |    0.04 |   1039.0625 |           - |           - |          3197.13 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 1,462.6 us | 275.3303 us | 15.0918 us |  8.36 |    0.10 |   1000.0000 |     41.0156 |     41.0156 |          3209.13 KB |
|             DictionaryDefault |    RyuJit |      X64 |     Clr | 1,301.5 us | 243.4988 us | 13.3470 us |  7.44 |    0.09 |   1039.0625 |           - |           - |          3197.13 KB |
|                               |           |          |         |            |             |            |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core |   172.5 us |  32.7527 us |  1.7953 us |  1.03 |    0.00 |     41.5039 |           - |           - |           128.21 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core |   132.5 us |   7.2653 us |  0.3982 us |  0.79 |    0.01 |     41.5039 |     41.5039 |     41.5039 |           140.05 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core |   167.0 us |  21.8915 us |  1.1999 us |  1.00 |    0.00 |     41.5039 |           - |           - |           128.19 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core |   189.5 us |  42.2816 us |  2.3176 us |  1.13 |    0.01 |     41.5039 |     41.5039 |     41.5039 |           140.05 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core |   171.7 us |  30.6677 us |  1.6810 us |  1.03 |    0.00 |     41.5039 |           - |           - |           128.21 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core |   189.6 us |  17.6870 us |  0.9695 us |  1.14 |    0.00 |     41.5039 |     41.5039 |     41.5039 |           140.07 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core |   166.6 us |  20.7538 us |  1.1376 us |  1.00 |    0.01 |     41.5039 |           - |           - |           128.19 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core |   189.0 us |  37.7465 us |  2.0690 us |  1.13 |    0.02 |     41.5039 |     41.5039 |     41.5039 |           140.05 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |   165.1 us |   4.3160 us |  0.2366 us |  0.99 |    0.01 |     59.5703 |           - |           - |           184.34 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |   210.1 us |   9.0527 us |  0.4962 us |  1.26 |    0.01 |     41.5039 |     41.5039 |     41.5039 |            196.2 KB |
|             DictionaryDefault |    RyuJit |      X64 |    Core |   165.7 us |   1.4442 us |  0.0792 us |  0.99 |    0.01 |     59.5703 |           - |           - |           184.34 KB |
