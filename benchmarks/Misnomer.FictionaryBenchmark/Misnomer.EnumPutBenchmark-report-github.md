``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-ADNHTG : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-CINVIW : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-KSUPNK : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-DQBMGR : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |     Mean |     Error |    StdDev | Ratio | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |---------:|----------:|----------:|------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 52.51 us | 5.1867 us | 0.2843 us |  1.10 |           - |           - |           - |                   - |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr | 29.96 us | 0.3221 us | 0.0177 us |  0.62 |           - |           - |           - |                   - |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 47.95 us | 2.8081 us | 0.1539 us |  1.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 45.89 us | 2.8680 us | 0.1572 us |  0.96 |           - |           - |           - |                   - |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 52.45 us | 1.2739 us | 0.0698 us |  1.09 |           - |           - |           - |                   - |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 49.77 us | 2.8225 us | 0.1547 us |  1.04 |           - |           - |           - |                   - |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 48.86 us | 4.3867 us | 0.2404 us |  1.02 |           - |           - |           - |                   - |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 46.33 us | 0.9595 us | 0.0526 us |  0.97 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 44.70 us | 3.7578 us | 0.2060 us |  0.93 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 45.61 us | 2.1164 us | 0.1160 us |  0.95 |           - |           - |           - |                   - |
|             DictionaryDefault | LegacyJit |      X64 |     Clr | 43.40 us | 0.6857 us | 0.0376 us |  0.91 |           - |           - |           - |                   - |
|                               |           |          |         |          |           |           |       |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 55.53 us | 2.9335 us | 0.1608 us |  1.03 |           - |           - |           - |                   - |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 38.58 us | 1.0382 us | 0.0569 us |  0.71 |           - |           - |           - |                   - |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 54.12 us | 5.0476 us | 0.2767 us |  1.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 49.09 us | 3.0907 us | 0.1694 us |  0.91 |           - |           - |           - |                   - |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 54.99 us | 1.6365 us | 0.0897 us |  1.02 |           - |           - |           - |                   - |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 49.80 us | 0.4004 us | 0.0219 us |  0.92 |           - |           - |           - |                   - |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 54.27 us | 1.8064 us | 0.0990 us |  1.00 |           - |           - |           - |                   - |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 49.16 us | 2.6410 us | 0.1448 us |  0.91 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 44.78 us | 2.5272 us | 0.1385 us |  0.83 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 49.26 us | 2.4484 us | 0.1342 us |  0.91 |           - |           - |           - |                   - |
|             DictionaryDefault | LegacyJit |      X86 |     Clr | 44.91 us | 2.0140 us | 0.1104 us |  0.83 |           - |           - |           - |                   - |
|                               |           |          |         |          |           |           |       |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 52.60 us | 2.9825 us | 0.1635 us |  1.10 |           - |           - |           - |                   - |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr | 30.08 us | 4.1864 us | 0.2295 us |  0.63 |           - |           - |           - |                   - |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 47.73 us | 1.4764 us | 0.0809 us |  1.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 46.09 us | 2.8669 us | 0.1571 us |  0.97 |           - |           - |           - |                   - |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 52.53 us | 2.5515 us | 0.1399 us |  1.10 |           - |           - |           - |                   - |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 49.84 us | 1.3495 us | 0.0740 us |  1.04 |           - |           - |           - |                   - |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 49.01 us | 4.6129 us | 0.2528 us |  1.03 |           - |           - |           - |                   - |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 46.18 us | 0.4337 us | 0.0238 us |  0.97 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 44.79 us | 4.4129 us | 0.2419 us |  0.94 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 45.69 us | 0.2440 us | 0.0134 us |  0.96 |           - |           - |           - |                   - |
|             DictionaryDefault |    RyuJit |      X64 |     Clr | 43.47 us | 0.8417 us | 0.0461 us |  0.91 |           - |           - |           - |                   - |
|                               |           |          |         |          |           |           |       |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core | 55.18 us | 1.7171 us | 0.0941 us |  1.11 |           - |           - |           - |                   - |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core | 30.15 us | 0.7327 us | 0.0402 us |  0.60 |           - |           - |           - |                   - |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core | 49.88 us | 1.4262 us | 0.0782 us |  1.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core | 49.09 us | 1.6988 us | 0.0931 us |  0.98 |           - |           - |           - |                   - |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core | 53.72 us | 2.7788 us | 0.1523 us |  1.08 |           - |           - |           - |                   - |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core | 54.96 us | 1.1726 us | 0.0643 us |  1.10 |           - |           - |           - |                   - |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core | 50.06 us | 2.0984 us | 0.1150 us |  1.00 |           - |           - |           - |                   - |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core | 49.06 us | 1.6519 us | 0.0905 us |  0.98 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 31.66 us | 1.5808 us | 0.0867 us |  0.63 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 49.45 us | 1.6748 us | 0.0918 us |  0.99 |           - |           - |           - |                   - |
|             DictionaryDefault |    RyuJit |      X64 |    Core | 33.65 us | 0.9963 us | 0.0546 us |  0.67 |           - |           - |           - |                   - |
