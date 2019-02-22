``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-CHHVZF : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-LEYSCV : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-OJMRJY : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-FUYIVR : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |          Categories |     Mean |     Error |    StdDev | Ratio | RatioSD |
|------------------------------ |---------- |--------- |-------- |-------------------- |---------:|----------:|----------:|------:|--------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr |       ConcreteValue | 18.20 ns | 1.1615 ns | 0.0637 ns |  1.00 |    0.00 |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr |       ConcreteValue | 16.11 ns | 0.4733 ns | 0.0259 ns |  0.89 |    0.00 |
|                               |           |          |         |                     |          |           |           |       |         |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr |   ConcreteReference | 17.83 ns | 0.3263 ns | 0.0179 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr |   ConcreteReference | 20.49 ns | 0.9935 ns | 0.0545 ns |  1.15 |    0.00 |
|                               |           |          |         |                     |          |           |           |       |         |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr |        VirtualValue | 18.37 ns | 1.6658 ns | 0.0913 ns |  1.00 |    0.00 |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr |        VirtualValue | 21.23 ns | 4.1945 ns | 0.2299 ns |  1.16 |    0.02 |
|                               |           |          |         |                     |          |           |           |       |         |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr |    VirtualReference | 17.44 ns | 0.8707 ns | 0.0477 ns |  1.00 |    0.00 |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr |    VirtualReference | 20.63 ns | 1.1770 ns | 0.0645 ns |  1.18 |    0.00 |
|                               |           |          |         |                     |          |           |           |       |         |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | StandardPolymorphic | 17.01 ns | 0.9576 ns | 0.0525 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | StandardPolymorphic | 20.84 ns | 2.6663 ns | 0.1461 ns |  1.23 |    0.01 |
|                               |           |          |         |                     |          |           |           |       |         |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr |       ConcreteValue | 17.27 ns | 1.8841 ns | 0.1033 ns |  1.00 |    0.00 |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr |       ConcreteValue | 13.22 ns | 0.8159 ns | 0.0447 ns |  0.77 |    0.01 |
|                               |           |          |         |                     |          |           |           |       |         |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr |   ConcreteReference | 16.33 ns | 3.5824 ns | 0.1964 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr |   ConcreteReference | 15.78 ns | 4.8888 ns | 0.2680 ns |  0.97 |    0.01 |
|                               |           |          |         |                     |          |           |           |       |         |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr |        VirtualValue | 17.00 ns | 3.5951 ns | 0.1971 ns |  1.00 |    0.00 |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr |        VirtualValue | 16.67 ns | 1.1263 ns | 0.0617 ns |  0.98 |    0.02 |
|                               |           |          |         |                     |          |           |           |       |         |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr |    VirtualReference | 16.19 ns | 1.9786 ns | 0.1085 ns |  1.00 |    0.00 |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr |    VirtualReference | 15.55 ns | 0.2184 ns | 0.0120 ns |  0.96 |    0.01 |
|                               |           |          |         |                     |          |           |           |       |         |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | StandardPolymorphic | 15.81 ns | 3.1437 ns | 0.1723 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | StandardPolymorphic | 16.08 ns | 1.8655 ns | 0.1023 ns |  1.02 |    0.01 |
|                               |           |          |         |                     |          |           |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr |       ConcreteValue | 18.13 ns | 0.0950 ns | 0.0052 ns |  1.00 |    0.00 |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr |       ConcreteValue | 16.11 ns | 0.4641 ns | 0.0254 ns |  0.89 |    0.00 |
|                               |           |          |         |                     |          |           |           |       |         |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr |   ConcreteReference | 18.00 ns | 4.9485 ns | 0.2712 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr |   ConcreteReference | 20.52 ns | 0.5161 ns | 0.0283 ns |  1.14 |    0.02 |
|                               |           |          |         |                     |          |           |           |       |         |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr |        VirtualValue | 18.39 ns | 0.3930 ns | 0.0215 ns |  1.00 |    0.00 |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr |        VirtualValue | 20.98 ns | 1.6597 ns | 0.0910 ns |  1.14 |    0.01 |
|                               |           |          |         |                     |          |           |           |       |         |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr |    VirtualReference | 17.62 ns | 0.4192 ns | 0.0230 ns |  1.00 |    0.00 |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr |    VirtualReference | 20.73 ns | 1.5127 ns | 0.0829 ns |  1.18 |    0.01 |
|                               |           |          |         |                     |          |           |           |       |         |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | StandardPolymorphic | 17.39 ns | 5.9365 ns | 0.3254 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | StandardPolymorphic | 21.13 ns | 2.7441 ns | 0.1504 ns |  1.22 |    0.02 |
|                               |           |          |         |                     |          |           |           |       |         |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core |       ConcreteValue | 20.76 ns | 2.3823 ns | 0.1306 ns |  1.00 |    0.00 |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core |       ConcreteValue | 19.61 ns | 0.4085 ns | 0.0224 ns |  0.94 |    0.01 |
|                               |           |          |         |                     |          |           |           |       |         |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core |   ConcreteReference | 26.53 ns | 0.3315 ns | 0.0182 ns |  1.00 |    0.00 |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core |   ConcreteReference | 22.06 ns | 1.1995 ns | 0.0658 ns |  0.83 |    0.00 |
|                               |           |          |         |                     |          |           |           |       |         |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core |        VirtualValue | 23.86 ns | 1.2347 ns | 0.0677 ns |  1.00 |    0.00 |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core |        VirtualValue | 26.20 ns | 0.8242 ns | 0.0452 ns |  1.10 |    0.00 |
|                               |           |          |         |                     |          |           |           |       |         |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core |    VirtualReference | 23.51 ns | 3.4759 ns | 0.1905 ns |  1.00 |    0.00 |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core |    VirtualReference | 19.36 ns | 1.6851 ns | 0.0924 ns |  0.82 |    0.00 |
|                               |           |          |         |                     |          |           |           |       |         |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | StandardPolymorphic | 21.20 ns | 2.5635 ns | 0.1405 ns |  1.00 |    0.00 |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | StandardPolymorphic | 26.24 ns | 2.1161 ns | 0.1160 ns |  1.24 |    0.01 |
