``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-JMOLKO : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-COALGX : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-LEOISI : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-EPOFQZ : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                      Method |       Jit | Platform | Runtime |     Mean |     Error |    StdDev | Ratio | RatioSD |
|---------------------------- |---------- |--------- |-------- |---------:|----------:|----------:|------:|--------:|
| DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 2.514 us | 0.5341 us | 0.0293 us |  1.00 |    0.00 |
|     FictionaryConcreteValue | LegacyJit |      X64 |     Clr | 1.582 us | 0.0551 us | 0.0030 us |  0.63 |    0.01 |
|           DictionaryDefault | LegacyJit |      X64 |     Clr | 2.332 us | 0.2017 us | 0.0111 us |  0.93 |    0.01 |
|                             |           |          |         |          |           |           |       |         |
| DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 2.881 us | 0.8300 us | 0.0455 us |  1.00 |    0.00 |
|     FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 1.943 us | 0.4219 us | 0.0231 us |  0.67 |    0.02 |
|           DictionaryDefault | LegacyJit |      X86 |     Clr | 2.123 us | 0.6998 us | 0.0384 us |  0.74 |    0.02 |
|                             |           |          |         |          |           |           |       |         |
| DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 2.467 us | 0.0441 us | 0.0024 us |  1.00 |    0.00 |
|     FictionaryConcreteValue |    RyuJit |      X64 |     Clr | 1.566 us | 0.1893 us | 0.0104 us |  0.63 |    0.00 |
|           DictionaryDefault |    RyuJit |      X64 |     Clr | 2.302 us | 0.1028 us | 0.0056 us |  0.93 |    0.00 |
|                             |           |          |         |          |           |           |       |         |
| DictionaryConcreteReference |    RyuJit |      X64 |    Core | 2.551 us | 0.1125 us | 0.0062 us |  1.00 |    0.00 |
|     FictionaryConcreteValue |    RyuJit |      X64 |    Core | 1.499 us | 0.0324 us | 0.0018 us |  0.59 |    0.00 |
|           DictionaryDefault |    RyuJit |      X64 |    Core | 1.779 us | 0.0076 us | 0.0004 us |  0.70 |    0.00 |
