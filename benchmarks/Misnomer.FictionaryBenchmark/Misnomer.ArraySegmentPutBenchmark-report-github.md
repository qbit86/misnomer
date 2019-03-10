``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-TVCDOZ : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-IFXJKX : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-QTVYHY : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-QAKUQY : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |        Mean |       Error |     StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |------------:|------------:|-----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr |   186.14 us |  22.6043 us |  1.2390 us |  1.19 |    0.01 |     21.7285 |           - |           - |            68.04 KB |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr |   105.27 us |  17.7096 us |  0.9707 us |  0.67 |    0.00 |     23.1934 |           - |           - |            71.67 KB |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr |   155.98 us |  19.4114 us |  1.0640 us |  1.00 |    0.00 |     21.7285 |           - |           - |            68.04 KB |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr |   154.94 us |   9.9714 us |  0.5466 us |  0.99 |    0.00 |     23.1934 |           - |           - |            71.68 KB |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr |   158.36 us |   5.6729 us |  0.3110 us |  1.02 |    0.01 |     21.7285 |           - |           - |            68.04 KB |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr |   158.00 us |   4.6316 us |  0.2539 us |  1.01 |    0.01 |     23.1934 |           - |           - |            71.86 KB |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr |   153.93 us |   7.1673 us |  0.3929 us |  0.99 |    0.00 |     21.7285 |           - |           - |            68.04 KB |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr |   152.37 us |   2.2134 us |  0.1213 us |  0.98 |    0.01 |     23.1934 |           - |           - |            71.68 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 1,290.53 us |  20.0743 us |  1.1003 us |  8.27 |    0.05 |   1019.5313 |           - |           - |          3137.04 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 1,357.88 us |  48.9877 us |  2.6852 us |  8.71 |    0.07 |   1021.4844 |           - |           - |          3140.75 KB |
|             DictionaryDefault | LegacyJit |      X64 |     Clr | 1,307.99 us | 190.6574 us | 10.4506 us |  8.39 |    0.04 |   1019.5313 |           - |           - |          3137.04 KB |
|                               |           |          |         |             |             |            |       |         |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr |   136.24 us |   4.9382 us |  0.2707 us |  1.02 |    0.01 |     17.0898 |           - |           - |            53.01 KB |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr |   113.72 us |   6.2395 us |  0.3420 us |  0.85 |    0.01 |     17.9443 |           - |           - |            55.73 KB |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr |   134.06 us |  27.7420 us |  1.5206 us |  1.00 |    0.00 |     17.0898 |           - |           - |               53 KB |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr |   135.35 us |  49.0213 us |  2.6870 us |  1.01 |    0.01 |     17.8223 |           - |           - |            55.73 KB |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr |   136.67 us |  23.7425 us |  1.3014 us |  1.02 |    0.01 |     17.0898 |           - |           - |            53.01 KB |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr |   135.01 us |  24.9682 us |  1.3686 us |  1.01 |    0.01 |     17.8223 |           - |           - |            55.73 KB |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr |   133.81 us |  28.8717 us |  1.5826 us |  1.00 |    0.02 |     17.0898 |           - |           - |               53 KB |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr |   133.72 us |  18.7823 us |  1.0295 us |  1.00 |    0.02 |     17.8223 |           - |           - |            55.73 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 1,107.12 us | 179.0231 us |  9.8129 us |  8.26 |    0.16 |    640.6250 |           - |           - |          1970.96 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 1,090.58 us | 221.7580 us | 12.1553 us |  8.14 |    0.18 |    640.6250 |           - |           - |          1973.69 KB |
|             DictionaryDefault | LegacyJit |      X86 |     Clr | 1,071.52 us | 175.7390 us |  9.6328 us |  7.99 |    0.04 |    640.6250 |           - |           - |          1970.96 KB |
|                               |           |          |         |             |             |            |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr |   161.60 us |  28.4170 us |  1.5576 us |  1.04 |    0.01 |     21.7285 |           - |           - |            68.04 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr |   104.25 us |  30.1597 us |  1.6532 us |  0.67 |    0.01 |     23.1934 |           - |           - |            71.67 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr |   155.97 us |   9.4143 us |  0.5160 us |  1.00 |    0.00 |     21.7285 |           - |           - |            68.04 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr |   153.73 us |  12.0887 us |  0.6626 us |  0.99 |    0.01 |     23.1934 |           - |           - |            71.68 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr |   159.51 us |  25.4327 us |  1.3941 us |  1.02 |    0.01 |     21.7285 |           - |           - |            68.04 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr |   159.68 us |  16.9988 us |  0.9318 us |  1.02 |    0.01 |     23.1934 |           - |           - |            71.86 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr |   153.70 us |   3.4283 us |  0.1879 us |  0.99 |    0.00 |     21.7285 |           - |           - |            68.04 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr |   152.00 us |   1.3076 us |  0.0717 us |  0.97 |    0.00 |     23.1934 |           - |           - |            71.68 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 1,283.76 us |  42.5274 us |  2.3311 us |  8.23 |    0.04 |   1019.5313 |           - |           - |          3137.04 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 1,370.40 us |  96.4697 us |  5.2878 us |  8.79 |    0.06 |   1021.4844 |           - |           - |          3140.75 KB |
|             DictionaryDefault |    RyuJit |      X64 |     Clr | 1,249.99 us |  21.6947 us |  1.1892 us |  8.01 |    0.03 |   1019.5313 |           - |           - |          3137.04 KB |
|                               |           |          |         |             |             |            |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core |   148.21 us |   2.0271 us |  0.1111 us |  1.01 |    0.00 |     21.7285 |           - |           - |            68.04 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core |    89.44 us |   1.8378 us |  0.1007 us |  0.61 |    0.00 |     23.1934 |           - |           - |            71.66 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core |   146.65 us |   3.9348 us |  0.2157 us |  1.00 |    0.00 |     21.7285 |           - |           - |            68.02 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core |   141.33 us |   1.5955 us |  0.0875 us |  0.96 |    0.00 |     23.1934 |           - |           - |            71.66 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core |   148.44 us |   3.1039 us |  0.1701 us |  1.01 |    0.00 |     21.7285 |           - |           - |            68.04 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core |   143.90 us |   2.4010 us |  0.1316 us |  0.98 |    0.00 |     23.1934 |           - |           - |            71.69 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core |   154.13 us |  34.6282 us |  1.8981 us |  1.05 |    0.01 |     21.7285 |           - |           - |            68.02 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core |   144.23 us |  89.6366 us |  4.9133 us |  0.98 |    0.03 |     23.1934 |           - |           - |            71.66 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |   145.10 us |   0.5786 us |  0.0317 us |  0.99 |    0.00 |     39.7949 |           - |           - |           124.17 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |   158.18 us |   3.8882 us |  0.2131 us |  1.08 |    0.00 |     41.5039 |           - |           - |           127.82 KB |
|             DictionaryDefault |    RyuJit |      X64 |    Core |   145.37 us |   1.8228 us |  0.0999 us |  0.99 |    0.00 |     39.7949 |           - |           - |           124.17 KB |
