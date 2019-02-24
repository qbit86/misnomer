``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-BRXZEI : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-TIXLVV : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-GJGLAC : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-BRGTQG : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |      Mean |      Error |    StdDev | Ratio | RatioSD |
|------------------------------ |---------- |--------- |-------- |----------:|-----------:|----------:|------:|--------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr |  33.04 ns |  0.6409 ns | 0.0351 ns |  1.02 |    0.00 |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr |  20.22 ns |  0.7610 ns | 0.0417 ns |  0.63 |    0.00 |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr |  32.28 ns |  0.7584 ns | 0.0416 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr |  30.77 ns |  0.9150 ns | 0.0502 ns |  0.95 |    0.00 |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr |  32.67 ns |  1.8798 ns | 0.1030 ns |  1.01 |    0.00 |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr |  31.37 ns |  1.2226 ns | 0.0670 ns |  0.97 |    0.00 |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr |  32.42 ns |  0.3911 ns | 0.0214 ns |  1.00 |    0.00 |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr |  32.35 ns |  1.4075 ns | 0.0771 ns |  1.00 |    0.00 |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr |  29.48 ns |  1.6406 ns | 0.0899 ns |  0.91 |    0.00 |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 171.18 ns |  3.0212 ns | 0.1656 ns |  5.30 |    0.01 |
|             DictionaryDefault | LegacyJit |      X64 |     Clr |  29.97 ns |  1.0612 ns | 0.0582 ns |  0.93 |    0.00 |
|                               |           |          |         |           |            |           |       |         |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr |  20.76 ns |  2.4679 ns | 0.1353 ns |  1.08 |    0.01 |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr |  16.56 ns | 12.5302 ns | 0.6868 ns |  0.86 |    0.04 |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr |  19.27 ns |  0.5178 ns | 0.0284 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr |  18.85 ns |  0.5648 ns | 0.0310 ns |  0.98 |    0.00 |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr |  20.70 ns |  1.8797 ns | 0.1030 ns |  1.07 |    0.00 |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr |  18.92 ns |  0.9356 ns | 0.0513 ns |  0.98 |    0.00 |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr |  19.27 ns |  0.7368 ns | 0.0404 ns |  1.00 |    0.00 |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr |  19.01 ns |  5.2657 ns | 0.2886 ns |  0.99 |    0.02 |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr |  16.09 ns |  0.1163 ns | 0.0064 ns |  0.84 |    0.00 |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 148.07 ns |  9.6585 ns | 0.5294 ns |  7.68 |    0.03 |
|             DictionaryDefault | LegacyJit |      X86 |     Clr |  16.34 ns |  0.6088 ns | 0.0334 ns |  0.85 |    0.00 |
|                               |           |          |         |           |            |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr |  32.79 ns |  1.4434 ns | 0.0791 ns |  1.01 |    0.01 |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr |  20.26 ns |  0.8057 ns | 0.0442 ns |  0.63 |    0.00 |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr |  32.36 ns |  2.6050 ns | 0.1428 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr |  31.49 ns | 18.2471 ns | 1.0002 ns |  0.97 |    0.03 |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr |  32.72 ns |  0.1716 ns | 0.0094 ns |  1.01 |    0.00 |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr |  31.41 ns |  0.7616 ns | 0.0417 ns |  0.97 |    0.00 |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr |  32.31 ns |  1.9867 ns | 0.1089 ns |  1.00 |    0.01 |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr |  32.20 ns |  1.2084 ns | 0.0662 ns |  1.00 |    0.00 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr |  29.48 ns |  3.1356 ns | 0.1719 ns |  0.91 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 171.61 ns |  6.0875 ns | 0.3337 ns |  5.30 |    0.01 |
|             DictionaryDefault |    RyuJit |      X64 |     Clr |  29.93 ns |  2.6088 ns | 0.1430 ns |  0.93 |    0.01 |
|                               |           |          |         |           |            |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core |  30.55 ns |  1.1211 ns | 0.0615 ns |  1.03 |    0.00 |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core |  20.20 ns |  1.0070 ns | 0.0552 ns |  0.68 |    0.00 |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core |  29.55 ns |  0.7976 ns | 0.0437 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core |  30.81 ns |  3.9740 ns | 0.2178 ns |  1.04 |    0.01 |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core |  30.53 ns |  0.5292 ns | 0.0290 ns |  1.03 |    0.00 |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core |  30.66 ns |  1.3207 ns | 0.0724 ns |  1.04 |    0.00 |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core |  29.91 ns |  0.1070 ns | 0.0059 ns |  1.01 |    0.00 |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core |  29.21 ns |  0.7968 ns | 0.0437 ns |  0.99 |    0.00 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |  28.17 ns |  0.8714 ns | 0.0478 ns |  0.95 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |  30.34 ns |  2.7387 ns | 0.1501 ns |  1.03 |    0.01 |
|             DictionaryDefault |    RyuJit |      X64 |    Core |  28.27 ns |  0.6153 ns | 0.0337 ns |  0.96 |    0.00 |
