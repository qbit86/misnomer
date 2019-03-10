``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-GNQYBQ : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-GXEBEZ : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-JDFTNF : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-KPRNZY : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|     Method |       Jit | Platform | Runtime |      Mean |     Error |    StdDev | Ratio | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|----------- |---------- |--------- |-------- |----------:|----------:|----------:|------:|------------:|------------:|------------:|--------------------:|
| Dictionary | LegacyJit |      X64 |     Clr |  4.615 ms | 0.1776 ms | 0.0097 ms |  1.00 |    250.0000 |    164.0625 |    164.0625 |          1077.97 KB |
| Fictionary | LegacyJit |      X64 |     Clr |  4.461 ms | 0.1386 ms | 0.0076 ms |  0.97 |    117.1875 |    117.1875 |    117.1875 |            516.5 KB |
|            |           |          |         |           |           |           |       |             |             |             |                     |
| Dictionary | LegacyJit |      X86 |     Clr | 12.373 ms | 0.4316 ms | 0.0237 ms |  1.00 |    203.1250 |    140.6250 |    140.6250 |           956.85 KB |
| Fictionary | LegacyJit |      X86 |     Clr | 12.385 ms | 0.1237 ms | 0.0068 ms |  1.00 |     93.7500 |     93.7500 |     93.7500 |           456.85 KB |
|            |           |          |         |           |           |           |       |             |             |             |                     |
| Dictionary |    RyuJit |      X64 |     Clr |  4.526 ms | 0.5391 ms | 0.0296 ms |  1.00 |    250.0000 |    164.0625 |    164.0625 |          1077.97 KB |
| Fictionary |    RyuJit |      X64 |     Clr |  4.443 ms | 0.0764 ms | 0.0042 ms |  0.98 |    117.1875 |    117.1875 |    117.1875 |            516.5 KB |
|            |           |          |         |           |           |           |       |             |             |             |                     |
| Dictionary |    RyuJit |      X64 |    Core |  4.129 ms | 0.1860 ms | 0.0102 ms |  1.00 |    250.0000 |    164.0625 |    164.0625 |          1077.82 KB |
| Fictionary |    RyuJit |      X64 |    Core |  4.006 ms | 0.1198 ms | 0.0066 ms |  0.97 |     78.1250 |     78.1250 |     78.1250 |           375.37 KB |
