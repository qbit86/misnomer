``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-KXGLQI : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-QYKAXU : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-AFPOHH : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-DTCLVP : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                      Method |       Jit | Platform | Runtime |     Mean |      Error |    StdDev | Ratio | RatioSD |
|---------------------------- |---------- |--------- |-------- |---------:|-----------:|----------:|------:|--------:|
|     DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 32.59 ns |  1.1826 ns | 0.0648 ns |  1.01 |    0.00 |
|     FictionaryConcreteValue | LegacyJit |      X64 |     Clr | 21.00 ns |  7.6481 ns | 0.4192 ns |  0.65 |    0.01 |
| DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 32.31 ns |  1.5974 ns | 0.0876 ns |  1.00 |    0.00 |
| FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 32.09 ns |  1.2175 ns | 0.0667 ns |  0.99 |    0.00 |
|      DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 32.68 ns |  1.4233 ns | 0.0780 ns |  1.01 |    0.00 |
|      FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 32.61 ns |  2.5934 ns | 0.1422 ns |  1.01 |    0.00 |
|  DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 32.10 ns |  1.8462 ns | 0.1012 ns |  0.99 |    0.01 |
|  FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 31.83 ns |  1.3661 ns | 0.0749 ns |  0.99 |    0.00 |
|           DictionaryDefault | LegacyJit |      X64 |     Clr | 29.95 ns |  0.9030 ns | 0.0495 ns |  0.93 |    0.00 |
|                             |           |          |         |          |            |           |       |         |
|     DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 21.72 ns |  8.0845 ns | 0.4431 ns |  1.10 |    0.02 |
|     FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 16.75 ns |  5.0211 ns | 0.2752 ns |  0.85 |    0.01 |
| DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 19.71 ns |  1.2268 ns | 0.0672 ns |  1.00 |    0.00 |
| FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 20.35 ns |  3.8363 ns | 0.2103 ns |  1.03 |    0.01 |
|      DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 21.79 ns |  1.0745 ns | 0.0589 ns |  1.11 |    0.01 |
|      FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 19.10 ns |  0.2939 ns | 0.0161 ns |  0.97 |    0.00 |
|  DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 20.32 ns |  2.4865 ns | 0.1363 ns |  1.03 |    0.01 |
|  FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 19.73 ns |  0.7085 ns | 0.0388 ns |  1.00 |    0.01 |
|           DictionaryDefault | LegacyJit |      X86 |     Clr | 17.02 ns |  0.6559 ns | 0.0360 ns |  0.86 |    0.00 |
|                             |           |          |         |          |            |           |       |         |
|     DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 33.89 ns |  2.6718 ns | 0.1465 ns |  1.00 |    0.01 |
|     FictionaryConcreteValue |    RyuJit |      X64 |     Clr | 21.94 ns |  0.5381 ns | 0.0295 ns |  0.65 |    0.00 |
| DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 33.95 ns |  1.0577 ns | 0.0580 ns |  1.00 |    0.00 |
| FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 33.80 ns |  7.0711 ns | 0.3876 ns |  1.00 |    0.01 |
|      DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 34.45 ns |  8.5116 ns | 0.4665 ns |  1.01 |    0.01 |
|      FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 34.13 ns |  1.3863 ns | 0.0760 ns |  1.01 |    0.00 |
|  DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 33.98 ns |  7.2162 ns | 0.3955 ns |  1.00 |    0.01 |
|  FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 33.22 ns |  0.8748 ns | 0.0479 ns |  0.98 |    0.00 |
|           DictionaryDefault |    RyuJit |      X64 |     Clr | 31.46 ns |  3.8510 ns | 0.2111 ns |  0.93 |    0.01 |
|                             |           |          |         |          |            |           |       |         |
|     DictionaryConcreteValue |    RyuJit |      X64 |    Core | 33.22 ns | 12.5140 ns | 0.6859 ns |  1.10 |    0.03 |
|     FictionaryConcreteValue |    RyuJit |      X64 |    Core | 21.50 ns |  2.3729 ns | 0.1301 ns |  0.71 |    0.00 |
| DictionaryConcreteReference |    RyuJit |      X64 |    Core | 30.15 ns |  2.3355 ns | 0.1280 ns |  1.00 |    0.00 |
| FictionaryConcreteReference |    RyuJit |      X64 |    Core | 30.62 ns | 12.7130 ns | 0.6968 ns |  1.02 |    0.03 |
|      DictionaryVirtualValue |    RyuJit |      X64 |    Core | 31.54 ns |  1.7045 ns | 0.0934 ns |  1.05 |    0.00 |
|      FictionaryVirtualValue |    RyuJit |      X64 |    Core | 30.78 ns |  0.4399 ns | 0.0241 ns |  1.02 |    0.00 |
|  DictionaryVirtualReference |    RyuJit |      X64 |    Core | 29.97 ns |  1.4199 ns | 0.0778 ns |  0.99 |    0.00 |
|  FictionaryVirtualReference |    RyuJit |      X64 |    Core | 29.54 ns |  0.6833 ns | 0.0375 ns |  0.98 |    0.01 |
|           DictionaryDefault |    RyuJit |      X64 |    Core | 29.97 ns |  3.9484 ns | 0.2164 ns |  0.99 |    0.01 |
