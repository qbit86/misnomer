``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-POESMH : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-KVBXGO : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-PBMDSP : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-EFYFZS : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  
Categories=String  

```
|                        Method |       Jit | Platform | Runtime |     Mean |     Error |    StdDev | Ratio | RatioSD |
|------------------------------ |---------- |--------- |-------- |---------:|----------:|----------:|------:|--------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 18.72 ns | 3.3386 ns | 0.1830 ns |  1.12 |    0.02 |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr | 16.71 ns | 4.4254 ns | 0.2426 ns |  1.00 |    0.00 |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 18.39 ns | 2.1729 ns | 0.1191 ns |  1.10 |    0.02 |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 21.03 ns | 1.7734 ns | 0.0972 ns |  1.26 |    0.02 |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 19.02 ns | 0.7957 ns | 0.0436 ns |  1.14 |    0.01 |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 21.67 ns | 3.2270 ns | 0.1769 ns |  1.30 |    0.01 |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 18.25 ns | 0.9190 ns | 0.0504 ns |  1.09 |    0.01 |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 21.41 ns | 2.9313 ns | 0.1607 ns |  1.28 |    0.01 |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 17.68 ns | 1.6221 ns | 0.0889 ns |  1.06 |    0.02 |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 21.53 ns | 2.2398 ns | 0.1228 ns |  1.29 |    0.03 |
|                               |           |          |         |          |           |           |       |         |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 17.48 ns | 1.3783 ns | 0.0755 ns |  1.27 |    0.02 |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 13.76 ns | 2.4730 ns | 0.1356 ns |  1.00 |    0.00 |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 16.71 ns | 2.7525 ns | 0.1509 ns |  1.21 |    0.02 |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 16.08 ns | 1.4320 ns | 0.0785 ns |  1.17 |    0.01 |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 17.23 ns | 1.6232 ns | 0.0890 ns |  1.25 |    0.02 |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 16.86 ns | 2.5527 ns | 0.1399 ns |  1.23 |    0.02 |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 16.89 ns | 1.0955 ns | 0.0600 ns |  1.23 |    0.01 |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 15.84 ns | 3.7169 ns | 0.2037 ns |  1.15 |    0.02 |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 15.84 ns | 2.4207 ns | 0.1327 ns |  1.15 |    0.02 |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 16.61 ns | 8.6461 ns | 0.4739 ns |  1.21 |    0.03 |
|                               |           |          |         |          |           |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 18.52 ns | 2.0920 ns | 0.1147 ns |  1.11 |    0.01 |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr | 16.63 ns | 0.4418 ns | 0.0242 ns |  1.00 |    0.00 |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 18.16 ns | 0.4011 ns | 0.0220 ns |  1.09 |    0.00 |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 20.92 ns | 0.9770 ns | 0.0536 ns |  1.26 |    0.00 |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 18.79 ns | 1.1414 ns | 0.0626 ns |  1.13 |    0.00 |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 21.62 ns | 0.5348 ns | 0.0293 ns |  1.30 |    0.00 |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 18.26 ns | 2.8960 ns | 0.1587 ns |  1.10 |    0.01 |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 22.67 ns | 0.2781 ns | 0.0152 ns |  1.36 |    0.00 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 17.53 ns | 1.2530 ns | 0.0687 ns |  1.05 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 21.92 ns | 0.5525 ns | 0.0303 ns |  1.32 |    0.00 |
|                               |           |          |         |          |           |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core | 28.21 ns | 2.4332 ns | 0.1334 ns |  1.57 |    0.01 |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core | 18.01 ns | 2.5286 ns | 0.1386 ns |  1.00 |    0.00 |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core | 23.78 ns | 0.9340 ns | 0.0512 ns |  1.32 |    0.01 |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core | 22.64 ns | 5.5374 ns | 0.3035 ns |  1.26 |    0.01 |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core | 21.83 ns | 5.5277 ns | 0.3030 ns |  1.21 |    0.01 |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core | 20.26 ns | 3.3944 ns | 0.1861 ns |  1.13 |    0.01 |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core | 37.29 ns | 0.2252 ns | 0.0123 ns |  2.07 |    0.02 |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core | 29.89 ns | 2.6903 ns | 0.1475 ns |  1.66 |    0.02 |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 27.72 ns | 1.3586 ns | 0.0745 ns |  1.54 |    0.02 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 20.16 ns | 1.5483 ns | 0.0849 ns |  1.12 |    0.01 |
