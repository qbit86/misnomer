``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-UZMRYA : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-QAOIFE : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-USNCJY : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-WRRQXJ : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

InvocationCount=1  IterationCount=3  LaunchCount=1  
UnrollFactor=1  WarmupCount=3  

```
|     Method |       Jit | Platform | Runtime |      Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|----------- |---------- |--------- |-------- |----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| Dictionary | LegacyJit |      X64 |     Clr |  4.713 ms | 1.0938 ms | 0.0600 ms |           - |           - |           - |          1080.71 KB |
| Fictionary | LegacyJit |      X64 |     Clr |  4.370 ms | 3.0709 ms | 0.1683 ms |           - |           - |           - |           378.56 KB |
| Dictionary | LegacyJit |      X86 |     Clr | 12.374 ms | 5.1128 ms | 0.2802 ms |           - |           - |           - |           962.39 KB |
| Fictionary | LegacyJit |      X86 |     Clr | 12.157 ms | 4.9052 ms | 0.2689 ms |           - |           - |           - |           338.35 KB |
| Dictionary |    RyuJit |      X64 |     Clr |  4.574 ms | 0.9443 ms | 0.0518 ms |           - |           - |           - |          1080.71 KB |
| Fictionary |    RyuJit |      X64 |     Clr |  4.243 ms | 1.2534 ms | 0.0687 ms |           - |           - |           - |           378.56 KB |
| Dictionary |    RyuJit |      X64 |    Core |  4.123 ms | 1.4854 ms | 0.0814 ms |           - |           - |           - |           1076.8 KB |
| Fictionary |    RyuJit |      X64 |    Core |  3.855 ms | 2.0571 ms | 0.1128 ms |           - |           - |           - |           374.45 KB |
