``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-DGKXIE : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-XYCHFS : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-SISMWF : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-PILPTY : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |      Mean |      Error |    StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |----------:|-----------:|----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 108.94 us | 13.4315 us | 0.7362 us |  1.04 |    0.01 |     17.2119 |           - |           - |            53.03 KB |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr |  88.94 us |  1.4333 us | 0.0786 us |  0.85 |    0.00 |     17.9443 |           - |           - |            55.75 KB |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 104.98 us |  2.1364 us | 0.1171 us |  1.00 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 101.84 us |  2.3107 us | 0.1267 us |  0.97 |    0.00 |     17.9443 |           - |           - |            55.75 KB |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 107.89 us |  1.6698 us | 0.0915 us |  1.03 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 105.79 us |  5.8190 us | 0.3190 us |  1.01 |    0.00 |     17.9443 |           - |           - |            55.75 KB |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 105.48 us |  4.8294 us | 0.2647 us |  1.00 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 102.04 us |  4.6245 us | 0.2535 us |  0.97 |    0.00 |     17.9443 |           - |           - |            55.75 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 101.30 us |  0.7703 us | 0.0422 us |  0.96 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 102.23 us |  2.4475 us | 0.1342 us |  0.97 |    0.00 |     17.9443 |           - |           - |            55.75 KB |
|             DictionaryDefault | LegacyJit |      X64 |     Clr | 102.38 us |  1.8521 us | 0.1015 us |  0.98 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
|                               |           |          |         |           |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 134.70 us |  6.0726 us | 0.3329 us |  0.99 |    0.00 |     14.6484 |           - |           - |            45.39 KB |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 134.28 us | 11.8885 us | 0.6516 us |  0.99 |    0.01 |     15.3809 |           - |           - |            47.65 KB |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 135.66 us |  1.7660 us | 0.0968 us |  1.00 |    0.00 |     14.6484 |           - |           - |            45.39 KB |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 137.99 us |  2.9038 us | 0.1592 us |  1.02 |    0.00 |     15.3809 |           - |           - |            47.65 KB |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 135.70 us |  9.4037 us | 0.5154 us |  1.00 |    0.00 |     14.6484 |           - |           - |            45.39 KB |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 139.01 us |  4.1608 us | 0.2281 us |  1.02 |    0.00 |     15.3809 |           - |           - |            47.65 KB |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 134.09 us |  4.6610 us | 0.2555 us |  0.99 |    0.00 |     14.6484 |           - |           - |            45.39 KB |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 136.56 us |  4.0965 us | 0.2245 us |  1.01 |    0.00 |     15.3809 |           - |           - |            47.65 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 133.11 us |  7.8951 us | 0.4328 us |  0.98 |    0.00 |     14.6484 |           - |           - |            45.39 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 137.39 us |  2.4111 us | 0.1322 us |  1.01 |    0.00 |     15.3809 |           - |           - |            47.65 KB |
|             DictionaryDefault | LegacyJit |      X86 |     Clr | 133.87 us |  0.5052 us | 0.0277 us |  0.99 |    0.00 |     14.6484 |           - |           - |            45.39 KB |
|                               |           |          |         |           |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 108.34 us |  2.5311 us | 0.1387 us |  1.03 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr |  89.35 us |  1.9736 us | 0.1082 us |  0.85 |    0.00 |     17.9443 |           - |           - |            55.75 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 104.86 us |  2.4383 us | 0.1336 us |  1.00 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 102.63 us |  0.2716 us | 0.0149 us |  0.98 |    0.00 |     17.9443 |           - |           - |            55.75 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 108.45 us |  1.9546 us | 0.1071 us |  1.03 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 106.07 us |  5.4364 us | 0.2980 us |  1.01 |    0.00 |     17.9443 |           - |           - |            55.75 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 105.84 us | 23.3198 us | 1.2782 us |  1.01 |    0.01 |     17.2119 |           - |           - |            53.03 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 102.73 us |  4.4232 us | 0.2425 us |  0.98 |    0.00 |     17.9443 |           - |           - |            55.75 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 101.49 us |  5.8219 us | 0.3191 us |  0.97 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 103.78 us | 26.1564 us | 1.4337 us |  0.99 |    0.01 |     17.9443 |           - |           - |            55.75 KB |
|             DictionaryDefault |    RyuJit |      X64 |     Clr | 102.36 us |  0.7272 us | 0.0399 us |  0.98 |    0.00 |     17.2119 |           - |           - |            53.03 KB |
|                               |           |          |         |           |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core |  87.21 us |  3.4035 us | 0.1866 us |  1.05 |    0.00 |     17.2119 |           - |           - |            52.95 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core |  63.77 us |  6.3381 us | 0.3474 us |  0.77 |    0.01 |     17.9443 |           - |           - |            55.66 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core |  83.00 us |  3.5323 us | 0.1936 us |  1.00 |    0.00 |     17.2119 |           - |           - |            52.93 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core |  80.14 us | 23.6574 us | 1.2967 us |  0.97 |    0.02 |     17.9443 |           - |           - |            55.66 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core |  87.22 us |  4.3744 us | 0.2398 us |  1.05 |    0.00 |     17.2119 |           - |           - |            52.95 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core |  83.41 us |  6.6880 us | 0.3666 us |  1.00 |    0.01 |     17.9443 |           - |           - |            55.69 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core |  82.63 us |  2.0071 us | 0.1100 us |  1.00 |    0.00 |     17.2119 |           - |           - |            52.93 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core |  79.03 us |  3.3488 us | 0.1836 us |  0.95 |    0.00 |     17.9443 |           - |           - |            55.66 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |  65.22 us |  0.3511 us | 0.0192 us |  0.79 |    0.00 |     17.2119 |           - |           - |            52.93 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |  79.73 us |  5.8952 us | 0.3231 us |  0.96 |    0.00 |     17.9443 |           - |           - |            55.66 KB |
|             DictionaryDefault |    RyuJit |      X64 |    Core |  65.53 us |  0.6746 us | 0.0370 us |  0.79 |    0.00 |     17.2119 |           - |           - |            52.93 KB |
