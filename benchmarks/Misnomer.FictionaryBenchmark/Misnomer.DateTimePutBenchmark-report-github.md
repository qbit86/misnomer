``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-RSQCDW : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-DVMMIW : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-LCNELM : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-IAQHNB : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |      Mean |      Error |    StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |----------:|-----------:|----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr |  96.19 us |  6.7817 us | 0.3717 us |  1.01 |    0.01 |           - |           - |           - |                   - |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr |  74.21 us |  7.9578 us | 0.4362 us |  0.78 |    0.01 |           - |           - |           - |                   - |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr |  95.66 us | 14.0413 us | 0.7697 us |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr |  88.64 us |  1.5777 us | 0.0865 us |  0.93 |    0.01 |           - |           - |           - |                   - |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr |  97.72 us |  0.6843 us | 0.0375 us |  1.02 |    0.01 |           - |           - |           - |                   - |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr |  95.15 us |  1.5108 us | 0.0828 us |  0.99 |    0.01 |           - |           - |           - |                   - |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr |  92.99 us |  2.3953 us | 0.1313 us |  0.97 |    0.01 |           - |           - |           - |                   - |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr |  88.48 us |  1.6146 us | 0.0885 us |  0.92 |    0.01 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr |  89.29 us |  8.1287 us | 0.4456 us |  0.93 |    0.01 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr |  91.34 us |  9.2463 us | 0.5068 us |  0.95 |    0.01 |           - |           - |           - |                   - |
|             DictionaryDefault | LegacyJit |      X64 |     Clr |  88.27 us |  7.9211 us | 0.4342 us |  0.92 |    0.01 |           - |           - |           - |                   - |
|                               |           |          |         |           |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 128.48 us |  2.1146 us | 0.1159 us |  1.01 |    0.00 |           - |           - |           - |                   - |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 123.80 us | 16.9839 us | 0.9309 us |  0.97 |    0.01 |           - |           - |           - |                   - |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 127.36 us | 12.1082 us | 0.6637 us |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 128.58 us |  2.3008 us | 0.1261 us |  1.01 |    0.01 |           - |           - |           - |                   - |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 132.22 us | 38.3621 us | 2.1028 us |  1.04 |    0.02 |           - |           - |           - |                   - |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 129.69 us | 14.3816 us | 0.7883 us |  1.02 |    0.00 |           - |           - |           - |                   - |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 127.85 us |  6.5183 us | 0.3573 us |  1.00 |    0.01 |           - |           - |           - |                   - |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 128.60 us | 17.9407 us | 0.9834 us |  1.01 |    0.01 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 126.10 us | 12.1086 us | 0.6637 us |  0.99 |    0.00 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 128.19 us | 21.3791 us | 1.1719 us |  1.01 |    0.01 |           - |           - |           - |                   - |
|             DictionaryDefault | LegacyJit |      X86 |     Clr | 127.35 us | 14.2222 us | 0.7796 us |  1.00 |    0.01 |           - |           - |           - |                   - |
|                               |           |          |         |           |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr |  96.94 us |  3.6478 us | 0.1999 us |  1.03 |    0.00 |           - |           - |           - |                   - |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr |  74.18 us | 10.8558 us | 0.5950 us |  0.79 |    0.00 |           - |           - |           - |                   - |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr |  94.30 us |  6.7268 us | 0.3687 us |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr |  88.49 us |  8.5364 us | 0.4679 us |  0.94 |    0.00 |           - |           - |           - |                   - |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr |  97.68 us | 12.7509 us | 0.6989 us |  1.04 |    0.01 |           - |           - |           - |                   - |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr |  95.47 us |  4.2451 us | 0.2327 us |  1.01 |    0.01 |           - |           - |           - |                   - |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr |  93.34 us |  6.4764 us | 0.3550 us |  0.99 |    0.00 |           - |           - |           - |                   - |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr |  89.45 us | 10.0596 us | 0.5514 us |  0.95 |    0.01 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr |  89.17 us |  4.6910 us | 0.2571 us |  0.95 |    0.01 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr |  90.92 us | 11.9071 us | 0.6527 us |  0.96 |    0.01 |           - |           - |           - |                   - |
|             DictionaryDefault |    RyuJit |      X64 |     Clr |  87.94 us |  1.4799 us | 0.0811 us |  0.93 |    0.00 |           - |           - |           - |                   - |
|                               |           |          |         |           |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core |  75.24 us |  4.1565 us | 0.2278 us |  1.09 |    0.01 |           - |           - |           - |                   - |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core |  48.04 us |  2.4702 us | 0.1354 us |  0.69 |    0.00 |           - |           - |           - |                   - |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core |  69.14 us |  7.5913 us | 0.4161 us |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core |  65.62 us |  4.7080 us | 0.2581 us |  0.95 |    0.00 |           - |           - |           - |                   - |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core |  75.32 us |  1.4440 us | 0.0791 us |  1.09 |    0.01 |           - |           - |           - |                   - |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core |  71.26 us |  3.4345 us | 0.1883 us |  1.03 |    0.01 |           - |           - |           - |                   - |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core |  69.28 us |  3.0004 us | 0.1645 us |  1.00 |    0.00 |           - |           - |           - |                   - |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core |  66.99 us |  7.1861 us | 0.3939 us |  0.97 |    0.01 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |  49.59 us |  0.8918 us | 0.0489 us |  0.72 |    0.00 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |  66.58 us |  3.4903 us | 0.1913 us |  0.96 |    0.01 |           - |           - |           - |                   - |
|             DictionaryDefault |    RyuJit |      X64 |    Core |  48.88 us |  2.4249 us | 0.1329 us |  0.71 |    0.01 |           - |           - |           - |                   - |
