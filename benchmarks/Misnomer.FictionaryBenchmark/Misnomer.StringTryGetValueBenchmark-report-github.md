``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-TNPFYQ : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-LCPJXE : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-ZNEBQQ : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-HYAXMW : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=15  LaunchCount=2  WarmupCount=10  
Categories=String  

```
|                        Method |       Jit | Platform | Runtime |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |
|------------------------------ |---------- |--------- |-------- |---------:|----------:|----------:|---------:|------:|--------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 18.23 ns | 0.0281 ns | 0.0421 ns | 18.21 ns |  1.07 |    0.01 |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr | 15.48 ns | 0.0322 ns | 0.0462 ns | 15.47 ns |  0.91 |    0.01 |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 17.46 ns | 0.3525 ns | 0.5276 ns | 17.46 ns |  1.02 |    0.03 |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 20.46 ns | 0.0761 ns | 0.1115 ns | 20.45 ns |  1.20 |    0.01 |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 17.99 ns | 0.0243 ns | 0.0356 ns | 17.99 ns |  1.05 |    0.01 |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 20.88 ns | 0.0545 ns | 0.0815 ns | 20.88 ns |  1.22 |    0.01 |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 17.23 ns | 0.0396 ns | 0.0568 ns | 17.22 ns |  1.01 |    0.01 |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 21.39 ns | 0.8896 ns | 1.3316 ns | 21.41 ns |  1.25 |    0.07 |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 17.10 ns | 0.1065 ns | 0.1561 ns | 17.04 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 20.13 ns | 0.1254 ns | 0.1838 ns | 20.10 ns |  1.18 |    0.02 |
|                               |           |          |         |          |           |           |          |       |         |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 16.28 ns | 0.0333 ns | 0.0489 ns | 16.28 ns |  1.07 |    0.01 |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 13.02 ns | 0.0256 ns | 0.0383 ns | 13.01 ns |  0.86 |    0.00 |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 15.69 ns | 0.0258 ns | 0.0370 ns | 15.68 ns |  1.03 |    0.00 |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 15.55 ns | 0.0292 ns | 0.0438 ns | 15.55 ns |  1.03 |    0.00 |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 16.24 ns | 0.0303 ns | 0.0454 ns | 16.24 ns |  1.07 |    0.01 |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 15.70 ns | 0.0205 ns | 0.0293 ns | 15.69 ns |  1.04 |    0.00 |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 15.68 ns | 0.0271 ns | 0.0406 ns | 15.69 ns |  1.03 |    0.01 |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 15.57 ns | 0.1352 ns | 0.2024 ns | 15.50 ns |  1.03 |    0.01 |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 15.16 ns | 0.0315 ns | 0.0462 ns | 15.15 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 15.99 ns | 0.0271 ns | 0.0406 ns | 15.98 ns |  1.05 |    0.00 |
|                               |           |          |         |          |           |           |          |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 18.27 ns | 0.0202 ns | 0.0303 ns | 18.26 ns |  1.08 |    0.00 |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr | 15.83 ns | 0.2877 ns | 0.4217 ns | 15.55 ns |  0.93 |    0.03 |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 16.96 ns | 0.0215 ns | 0.0315 ns | 16.95 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 20.35 ns | 0.0560 ns | 0.0837 ns | 20.32 ns |  1.20 |    0.01 |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 18.00 ns | 0.0192 ns | 0.0263 ns | 17.99 ns |  1.06 |    0.00 |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 20.91 ns | 0.0346 ns | 0.0517 ns | 20.92 ns |  1.23 |    0.00 |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 17.22 ns | 0.0222 ns | 0.0326 ns | 17.22 ns |  1.02 |    0.00 |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 20.07 ns | 0.0456 ns | 0.0682 ns | 20.07 ns |  1.18 |    0.00 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 16.95 ns | 0.0190 ns | 0.0284 ns | 16.94 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 20.38 ns | 0.2696 ns | 0.4035 ns | 20.39 ns |  1.20 |    0.02 |
|                               |           |          |         |          |           |           |          |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core | 23.52 ns | 2.2019 ns | 3.2275 ns | 20.51 ns |  1.01 |    0.09 |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core | 18.16 ns | 0.7071 ns | 1.0583 ns | 18.13 ns |  0.77 |    0.09 |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core | 24.20 ns | 1.0299 ns | 1.5096 ns | 22.78 ns |  1.03 |    0.04 |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core | 21.93 ns | 0.0671 ns | 0.0984 ns | 21.89 ns |  0.94 |    0.06 |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core | 20.24 ns | 0.0362 ns | 0.0530 ns | 20.23 ns |  0.86 |    0.06 |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core | 21.23 ns | 0.7420 ns | 1.1107 ns | 21.18 ns |  0.91 |    0.04 |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core | 21.71 ns | 0.8833 ns | 1.2947 ns | 20.53 ns |  0.93 |    0.11 |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core | 19.00 ns | 0.0186 ns | 0.0279 ns | 19.00 ns |  0.81 |    0.05 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 23.53 ns | 1.1477 ns | 1.6089 ns | 22.20 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 19.49 ns | 0.0253 ns | 0.0379 ns | 19.48 ns |  0.83 |    0.06 |
