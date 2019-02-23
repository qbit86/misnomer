``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-MXYUHW : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-YRTXYQ : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-UGBUQJ : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-KVAQHN : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  
Categories=String  

```
|                        Method |       Jit | Platform | Runtime |     Mean |     Error |    StdDev | Ratio | RatioSD |
|------------------------------ |---------- |--------- |-------- |---------:|----------:|----------:|------:|--------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 18.38 ns | 4.2953 ns | 0.2354 ns |  1.07 |    0.01 |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr | 16.64 ns | 2.1605 ns | 0.1184 ns |  0.97 |    0.01 |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 17.29 ns | 1.8147 ns | 0.0995 ns |  1.01 |    0.01 |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 20.74 ns | 0.5188 ns | 0.0284 ns |  1.21 |    0.01 |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 18.03 ns | 0.7100 ns | 0.0389 ns |  1.05 |    0.01 |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 19.71 ns | 0.7489 ns | 0.0410 ns |  1.15 |    0.00 |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 17.05 ns | 0.1217 ns | 0.0067 ns |  1.00 |    0.01 |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 19.60 ns | 0.7919 ns | 0.0434 ns |  1.14 |    0.01 |
|  DictionaryDefaultPolymorphic | LegacyJit |      X64 |     Clr | 17.32 ns | 9.0069 ns | 0.4937 ns |  1.01 |    0.03 |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 17.13 ns | 1.7329 ns | 0.0950 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 20.45 ns | 0.5336 ns | 0.0292 ns |  1.19 |    0.01 |
|                               |           |          |         |          |           |           |       |         |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 16.24 ns | 0.2958 ns | 0.0162 ns |  1.07 |    0.00 |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 13.07 ns | 2.6219 ns | 0.1437 ns |  0.86 |    0.01 |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 15.90 ns | 3.6139 ns | 0.1981 ns |  1.05 |    0.01 |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 15.47 ns | 0.1988 ns | 0.0109 ns |  1.02 |    0.00 |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 16.23 ns | 0.9518 ns | 0.0522 ns |  1.07 |    0.00 |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 15.72 ns | 0.5715 ns | 0.0313 ns |  1.04 |    0.00 |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 15.95 ns | 0.4811 ns | 0.0264 ns |  1.05 |    0.00 |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 15.46 ns | 0.8404 ns | 0.0461 ns |  1.02 |    0.00 |
|  DictionaryDefaultPolymorphic | LegacyJit |      X86 |     Clr | 15.16 ns | 0.8576 ns | 0.0470 ns |  1.00 |    0.00 |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 15.15 ns | 0.1390 ns | 0.0076 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 16.22 ns | 7.1593 ns | 0.3924 ns |  1.07 |    0.03 |
|                               |           |          |         |          |           |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 18.33 ns | 0.3927 ns | 0.0215 ns |  1.08 |    0.00 |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr | 16.47 ns | 0.4353 ns | 0.0239 ns |  0.97 |    0.00 |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 17.35 ns | 0.6401 ns | 0.0351 ns |  1.02 |    0.00 |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 19.88 ns | 0.6677 ns | 0.0366 ns |  1.17 |    0.00 |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 18.06 ns | 0.3791 ns | 0.0208 ns |  1.06 |    0.00 |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 20.20 ns | 0.5232 ns | 0.0287 ns |  1.19 |    0.00 |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 17.13 ns | 1.5985 ns | 0.0876 ns |  1.01 |    0.01 |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 19.60 ns | 0.5294 ns | 0.0290 ns |  1.15 |    0.00 |
|  DictionaryDefaultPolymorphic |    RyuJit |      X64 |     Clr | 17.02 ns | 0.3825 ns | 0.0210 ns |  1.00 |    0.00 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 17.04 ns | 0.9319 ns | 0.0511 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 20.26 ns | 0.5920 ns | 0.0324 ns |  1.19 |    0.01 |
|                               |           |          |         |          |           |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core | 20.35 ns | 0.2532 ns | 0.0139 ns |  0.90 |    0.01 |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core | 19.24 ns | 0.0573 ns | 0.0031 ns |  0.85 |    0.01 |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core | 22.84 ns | 0.9990 ns | 0.0548 ns |  1.01 |    0.01 |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core | 22.99 ns | 0.7054 ns | 0.0387 ns |  1.02 |    0.01 |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core | 20.31 ns | 1.4618 ns | 0.0801 ns |  0.90 |    0.01 |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core | 20.57 ns | 7.3025 ns | 0.4003 ns |  0.91 |    0.01 |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core | 20.63 ns | 7.1456 ns | 0.3917 ns |  0.91 |    0.01 |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core | 19.48 ns | 2.2060 ns | 0.1209 ns |  0.86 |    0.01 |
|  DictionaryDefaultPolymorphic |    RyuJit |      X64 |    Core | 16.90 ns | 1.7670 ns | 0.0969 ns |  0.75 |    0.00 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 22.59 ns | 3.9474 ns | 0.2164 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 20.50 ns | 9.7873 ns | 0.5365 ns |  0.91 |    0.03 |
