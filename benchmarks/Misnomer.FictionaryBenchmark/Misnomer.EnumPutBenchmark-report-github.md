``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-ECGUWK : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-KQYKSA : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-SULTOC : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-OVQJQJ : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |     Mean |      Error |    StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |---------:|-----------:|----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 68.17 us |  5.9363 us | 0.3254 us |  1.06 |    0.00 |     12.2070 |           - |           - |            37.92 KB |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr | 46.39 us |  3.5473 us | 0.1944 us |  0.72 |    0.00 |     12.8174 |           - |           - |            39.74 KB |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 64.04 us |  1.7277 us | 0.0947 us |  1.00 |    0.00 |     12.2070 |           - |           - |            37.92 KB |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 61.59 us |  5.1461 us | 0.2821 us |  0.96 |    0.01 |     12.8174 |           - |           - |            39.74 KB |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 67.62 us |  4.7398 us | 0.2598 us |  1.06 |    0.00 |     12.2070 |           - |           - |            37.92 KB |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 65.79 us |  2.6796 us | 0.1469 us |  1.03 |    0.00 |     12.8174 |           - |           - |            39.74 KB |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 64.08 us |  4.8815 us | 0.2676 us |  1.00 |    0.01 |     12.2070 |           - |           - |            37.92 KB |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 61.99 us |  0.1272 us | 0.0070 us |  0.97 |    0.00 |     12.8174 |           - |           - |            39.74 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 59.60 us |  0.8479 us | 0.0465 us |  0.93 |    0.00 |     12.2681 |           - |           - |            37.92 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 63.40 us |  4.4408 us | 0.2434 us |  0.99 |    0.00 |     12.8174 |           - |           - |            39.74 KB |
|             DictionaryDefault | LegacyJit |      X64 |     Clr | 60.68 us |  1.5678 us | 0.0859 us |  0.95 |    0.00 |     12.2681 |           - |           - |            37.92 KB |
|                               |           |          |         |          |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 71.95 us |  7.4884 us | 0.4105 us |  1.00 |    0.01 |     12.0850 |           - |           - |            37.81 KB |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 58.01 us |  0.7656 us | 0.0420 us |  0.81 |    0.00 |     12.8174 |           - |           - |            39.61 KB |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 71.64 us |  1.2934 us | 0.0709 us |  1.00 |    0.00 |     12.0850 |           - |           - |            37.81 KB |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 69.85 us | 21.8951 us | 1.2001 us |  0.97 |    0.02 |     12.8174 |           - |           - |            39.61 KB |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 71.50 us |  2.8202 us | 0.1546 us |  1.00 |    0.00 |     12.0850 |           - |           - |            37.81 KB |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 70.17 us |  5.1416 us | 0.2818 us |  0.98 |    0.00 |     12.8174 |           - |           - |            39.72 KB |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 71.25 us |  6.0880 us | 0.3337 us |  0.99 |    0.00 |     12.0850 |           - |           - |            37.81 KB |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 68.82 us |  2.0763 us | 0.1138 us |  0.96 |    0.00 |     12.8174 |           - |           - |            39.61 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 62.43 us |  5.6779 us | 0.3112 us |  0.87 |    0.00 |     12.0850 |           - |           - |            37.81 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 68.70 us |  1.5115 us | 0.0828 us |  0.96 |    0.00 |     12.8174 |           - |           - |            39.61 KB |
|             DictionaryDefault | LegacyJit |      X86 |     Clr | 62.86 us |  2.3999 us | 0.1315 us |  0.88 |    0.00 |     12.0850 |           - |           - |            37.81 KB |
|                               |           |          |         |          |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 67.90 us |  1.5619 us | 0.0856 us |  1.05 |    0.00 |     12.2070 |           - |           - |            37.92 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr | 46.56 us |  0.7892 us | 0.0433 us |  0.72 |    0.00 |     12.8174 |           - |           - |            39.74 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 64.59 us |  0.7738 us | 0.0424 us |  1.00 |    0.00 |     12.2070 |           - |           - |            37.92 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 61.77 us |  1.9570 us | 0.1073 us |  0.96 |    0.00 |     12.8174 |           - |           - |            39.74 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 68.13 us |  4.5667 us | 0.2503 us |  1.05 |    0.00 |     12.2070 |           - |           - |            37.92 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 65.43 us |  3.3530 us | 0.1838 us |  1.01 |    0.00 |     12.8174 |           - |           - |            39.74 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 64.26 us |  1.9520 us | 0.1070 us |  0.99 |    0.00 |     12.2070 |           - |           - |            37.92 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 61.82 us |  0.8921 us | 0.0489 us |  0.96 |    0.00 |     12.8174 |           - |           - |            39.74 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 59.53 us |  5.0145 us | 0.2749 us |  0.92 |    0.00 |     12.2681 |           - |           - |            37.92 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 63.12 us |  1.9667 us | 0.1078 us |  0.98 |    0.00 |     12.8174 |           - |           - |            39.74 KB |
|             DictionaryDefault |    RyuJit |      X64 |     Clr | 60.90 us |  2.4283 us | 0.1331 us |  0.94 |    0.00 |     12.2681 |           - |           - |            37.92 KB |
|                               |           |          |         |          |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core | 68.96 us |  1.7361 us | 0.0952 us |  1.04 |    0.00 |     12.2070 |           - |           - |            37.87 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core | 47.77 us |  0.8053 us | 0.0441 us |  0.72 |    0.00 |     12.8174 |           - |           - |            39.66 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core | 66.29 us |  2.3211 us | 0.1272 us |  1.00 |    0.00 |     12.2070 |           - |           - |            37.84 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core | 64.75 us |  0.5606 us | 0.0307 us |  0.98 |    0.00 |     12.8174 |           - |           - |            39.66 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core | 68.84 us |  0.9642 us | 0.0529 us |  1.04 |    0.00 |     12.2070 |           - |           - |            37.87 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core | 68.64 us |  7.2706 us | 0.3985 us |  1.04 |    0.00 |     12.8174 |           - |           - |            39.69 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core | 66.48 us |  8.5369 us | 0.4679 us |  1.00 |    0.01 |     12.2070 |           - |           - |            37.84 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core | 65.64 us |  0.3201 us | 0.0175 us |  0.99 |    0.00 |     12.8174 |           - |           - |            39.66 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 50.73 us |  2.1228 us | 0.1164 us |  0.77 |    0.00 |     12.2681 |           - |           - |            37.84 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 65.38 us | 15.0154 us | 0.8230 us |  0.99 |    0.01 |     12.8174 |           - |           - |            39.66 KB |
|             DictionaryDefault |    RyuJit |      X64 |    Core | 49.89 us |  0.7096 us | 0.0389 us |  0.75 |    0.00 |     12.2681 |           - |           - |            37.84 KB |
