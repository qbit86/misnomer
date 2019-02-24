``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-QFIVDD : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-VTJBMJ : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-NSKMLL : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-CDNFQA : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |      Mean |      Error |    StdDev | Ratio | RatioSD |
|------------------------------ |---------- |--------- |-------- |----------:|-----------:|----------:|------:|--------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 15.378 ns |  5.2967 ns | 0.2903 ns |  1.07 |    0.04 |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr |  8.943 ns |  0.5325 ns | 0.0292 ns |  0.62 |    0.03 |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 14.456 ns | 14.1474 ns | 0.7755 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 13.526 ns |  1.4004 ns | 0.0768 ns |  0.94 |    0.05 |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 15.469 ns |  0.8836 ns | 0.0484 ns |  1.07 |    0.05 |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 14.540 ns |  0.7781 ns | 0.0426 ns |  1.01 |    0.06 |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 14.594 ns |  2.0117 ns | 0.1103 ns |  1.01 |    0.05 |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 12.973 ns |  0.5185 ns | 0.0284 ns |  0.90 |    0.05 |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 13.493 ns |  1.2433 ns | 0.0681 ns |  0.94 |    0.05 |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 13.164 ns |  0.7109 ns | 0.0390 ns |  0.91 |    0.05 |
|             DictionaryDefault | LegacyJit |      X64 |     Clr | 12.707 ns |  0.2537 ns | 0.0139 ns |  0.88 |    0.05 |
|                               |           |          |         |           |            |           |       |         |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 17.780 ns |  2.8906 ns | 0.1584 ns |  1.01 |    0.03 |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 15.041 ns |  3.0695 ns | 0.1682 ns |  0.85 |    0.03 |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 17.661 ns |  9.5910 ns | 0.5257 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 15.771 ns |  2.1062 ns | 0.1154 ns |  0.89 |    0.03 |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 17.639 ns |  0.1940 ns | 0.0106 ns |  1.00 |    0.03 |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 16.050 ns |  0.1208 ns | 0.0066 ns |  0.91 |    0.03 |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 17.689 ns |  1.1150 ns | 0.0611 ns |  1.00 |    0.03 |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 18.026 ns |  0.8552 ns | 0.0469 ns |  1.02 |    0.03 |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 15.099 ns |  0.1849 ns | 0.0101 ns |  0.86 |    0.02 |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 17.283 ns |  0.4758 ns | 0.0261 ns |  0.98 |    0.03 |
|             DictionaryDefault | LegacyJit |      X86 |     Clr | 14.993 ns |  0.4529 ns | 0.0248 ns |  0.85 |    0.03 |
|                               |           |          |         |           |            |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 15.061 ns |  0.1259 ns | 0.0069 ns |  1.07 |    0.00 |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr |  8.964 ns |  0.1711 ns | 0.0094 ns |  0.64 |    0.00 |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 14.043 ns |  0.1891 ns | 0.0104 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 13.469 ns |  0.7599 ns | 0.0417 ns |  0.96 |    0.00 |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 15.296 ns |  1.3019 ns | 0.0714 ns |  1.09 |    0.01 |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 14.557 ns |  0.2982 ns | 0.0163 ns |  1.04 |    0.00 |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 14.303 ns |  0.1542 ns | 0.0085 ns |  1.02 |    0.00 |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 12.919 ns |  0.2127 ns | 0.0117 ns |  0.92 |    0.00 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 13.376 ns |  0.4142 ns | 0.0227 ns |  0.95 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 13.458 ns |  0.1483 ns | 0.0081 ns |  0.96 |    0.00 |
|             DictionaryDefault |    RyuJit |      X64 |     Clr | 12.993 ns |  0.5232 ns | 0.0287 ns |  0.93 |    0.00 |
|                               |           |          |         |           |            |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core | 16.661 ns |  0.4276 ns | 0.0234 ns |  1.04 |    0.00 |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core |  9.450 ns |  0.4251 ns | 0.0233 ns |  0.59 |    0.00 |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core | 16.001 ns |  1.6398 ns | 0.0899 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core | 14.287 ns |  2.7343 ns | 0.1499 ns |  0.89 |    0.01 |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core | 16.629 ns |  3.9332 ns | 0.2156 ns |  1.04 |    0.01 |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core | 15.669 ns |  1.0324 ns | 0.0566 ns |  0.98 |    0.01 |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core | 15.230 ns |  3.2013 ns | 0.1755 ns |  0.95 |    0.01 |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core | 14.058 ns |  0.6448 ns | 0.0353 ns |  0.88 |    0.01 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 10.727 ns |  0.3624 ns | 0.0199 ns |  0.67 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 15.012 ns |  1.5451 ns | 0.0847 ns |  0.94 |    0.00 |
|             DictionaryDefault |    RyuJit |      X64 |    Core |  9.956 ns |  0.1168 ns | 0.0064 ns |  0.62 |    0.00 |
