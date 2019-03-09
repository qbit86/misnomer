``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-LEPVGI : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-XWVYYF : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-QVJRBX : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-MJJYUK : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |        Mean |      Error |     StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |------------:|-----------:|-----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr |   140.35 us |  15.804 us |  0.8662 us |  1.04 |    0.00 |           - |           - |           - |                   - |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr |    79.26 us |   7.700 us |  0.4221 us |  0.59 |    0.01 |           - |           - |           - |                   - |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr |   135.36 us |  19.977 us |  1.0950 us |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr |   125.87 us |   8.247 us |  0.4521 us |  0.93 |    0.01 |           - |           - |           - |                   - |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr |   141.36 us |  10.186 us |  0.5583 us |  1.04 |    0.01 |           - |           - |           - |                   - |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr |   136.39 us |   2.581 us |  0.1415 us |  1.01 |    0.01 |           - |           - |           - |                   - |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr |   134.86 us |  31.417 us |  1.7221 us |  1.00 |    0.01 |           - |           - |           - |                   - |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr |   129.63 us |   9.754 us |  0.5346 us |  0.96 |    0.00 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 1,259.30 us | 254.048 us | 13.9252 us |  9.30 |    0.07 |    943.3594 |           - |           - |           2970469 B |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 1,275.80 us |  91.838 us |  5.0339 us |  9.43 |    0.06 |    943.3594 |           - |           - |           2970469 B |
|             DictionaryDefault | LegacyJit |      X64 |     Clr | 1,210.43 us |  44.148 us |  2.4199 us |  8.94 |    0.06 |    943.3594 |           - |           - |           2970469 B |
|                               |           |          |         |             |            |            |       |         |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr |   125.41 us |   4.332 us |  0.2374 us |  1.02 |    0.01 |           - |           - |           - |                   - |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr |    93.31 us |  18.092 us |  0.9917 us |  0.76 |    0.01 |           - |           - |           - |                   - |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr |   123.04 us |  10.058 us |  0.5513 us |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr |   114.14 us |   6.117 us |  0.3353 us |  0.93 |    0.00 |           - |           - |           - |                   - |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr |   125.54 us |   9.640 us |  0.5284 us |  1.02 |    0.01 |           - |           - |           - |                   - |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr |   116.33 us |   7.611 us |  0.4172 us |  0.95 |    0.00 |           - |           - |           - |                   - |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr |   123.98 us |   6.596 us |  0.3616 us |  1.01 |    0.01 |           - |           - |           - |                   - |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr |   116.97 us |   2.199 us |  0.1206 us |  0.95 |    0.00 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 1,097.10 us |  30.760 us |  1.6860 us |  8.92 |    0.05 |    589.8438 |           - |           - |           1856547 B |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 1,042.05 us |  26.762 us |  1.4669 us |  8.47 |    0.03 |    589.8438 |           - |           - |           1856547 B |
|             DictionaryDefault | LegacyJit |      X86 |     Clr | 1,103.99 us | 301.102 us | 16.5044 us |  8.97 |    0.10 |    589.8438 |           - |           - |           1856547 B |
|                               |           |          |         |             |            |            |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr |   141.82 us |  29.537 us |  1.6190 us |  1.05 |    0.02 |           - |           - |           - |                   - |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr |    79.43 us |   7.343 us |  0.4025 us |  0.59 |    0.00 |           - |           - |           - |                   - |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr |   134.53 us |  13.852 us |  0.7593 us |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr |   127.27 us |   3.717 us |  0.2038 us |  0.95 |    0.00 |           - |           - |           - |                   - |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr |   140.90 us |   8.870 us |  0.4862 us |  1.05 |    0.01 |           - |           - |           - |                   - |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr |   137.21 us |  32.269 us |  1.7688 us |  1.02 |    0.01 |           - |           - |           - |                   - |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr |   136.08 us |  15.682 us |  0.8596 us |  1.01 |    0.00 |           - |           - |           - |                   - |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr |   130.04 us |  25.370 us |  1.3906 us |  0.97 |    0.00 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 1,252.18 us | 288.554 us | 15.8166 us |  9.31 |    0.07 |    943.3594 |           - |           - |           2970469 B |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 1,279.63 us | 152.759 us |  8.3732 us |  9.51 |    0.05 |    943.3594 |           - |           - |           2970469 B |
|             DictionaryDefault |    RyuJit |      X64 |     Clr | 1,243.19 us | 150.465 us |  8.2475 us |  9.24 |    0.08 |    943.3594 |           - |           - |           2970469 B |
|                               |           |          |         |             |            |            |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core |   131.36 us |   9.015 us |  0.4941 us |  1.06 |    0.01 |           - |           - |           - |                   - |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core |    64.86 us |   8.180 us |  0.4484 us |  0.52 |    0.00 |           - |           - |           - |                   - |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core |   123.81 us |  26.803 us |  1.4692 us |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core |   115.63 us |  11.548 us |  0.6330 us |  0.93 |    0.01 |           - |           - |           - |                   - |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core |   132.21 us |  13.039 us |  0.7147 us |  1.07 |    0.01 |           - |           - |           - |                   - |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core |   117.71 us |   7.237 us |  0.3967 us |  0.95 |    0.01 |           - |           - |           - |                   - |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core |   123.65 us |   7.833 us |  0.4293 us |  1.00 |    0.02 |           - |           - |           - |                   - |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core |   116.24 us |  11.367 us |  0.6231 us |  0.94 |    0.01 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |   137.80 us |  15.285 us |  0.8378 us |  1.11 |    0.01 |     35.6445 |           - |           - |            112768 B |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |   149.42 us |   8.044 us |  0.4409 us |  1.21 |    0.02 |     35.6445 |           - |           - |            112768 B |
|             DictionaryDefault |    RyuJit |      X64 |    Core |   134.88 us |  17.539 us |  0.9614 us |  1.09 |    0.01 |     35.6445 |           - |           - |            112768 B |
