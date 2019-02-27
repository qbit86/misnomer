``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-KXDWMV : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-MZODQM : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-NHYJFD : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Job-LLUJMH : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |     Mean |      Error |    StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |---------:|-----------:|----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 372.1 us |  73.164 us | 4.0104 us |  1.08 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr | 329.7 us |  18.408 us | 1.0090 us |  0.95 |    0.00 |     52.7344 |           - |           - |           162.47 KB |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 359.4 us |  29.810 us | 1.6340 us |  1.04 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 350.0 us |  29.987 us | 1.6437 us |  1.01 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 365.0 us |   5.106 us | 0.2799 us |  1.06 |    0.00 |     52.7344 |           - |           - |           162.47 KB |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 363.1 us |   1.701 us | 0.0932 us |  1.05 |    0.00 |     52.7344 |           - |           - |           162.47 KB |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 359.5 us |  19.822 us | 1.0865 us |  1.04 |    0.00 |     52.7344 |           - |           - |           162.47 KB |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 353.6 us |  28.023 us | 1.5360 us |  1.02 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 345.6 us |  17.431 us | 0.9554 us |  1.00 |    0.00 |     52.7344 |           - |           - |           162.47 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 353.3 us |   2.664 us | 0.1460 us |  1.02 |    0.00 |     52.7344 |           - |           - |           162.47 KB |
|                               |           |          |         |          |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 423.4 us |  70.231 us | 3.8496 us |  1.02 |    0.01 |     35.1563 |           - |           - |           108.31 KB |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 391.5 us |   8.142 us | 0.4463 us |  0.94 |    0.01 |     35.1563 |           - |           - |           108.31 KB |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 420.1 us |   9.176 us | 0.5029 us |  1.01 |    0.01 |     35.1563 |           - |           - |           108.31 KB |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 412.4 us |   5.342 us | 0.2928 us |  0.99 |    0.01 |     35.1563 |           - |           - |           108.31 KB |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 419.7 us |  22.041 us | 1.2081 us |  1.01 |    0.01 |     35.1563 |           - |           - |           108.31 KB |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 421.6 us |  69.073 us | 3.7861 us |  1.02 |    0.00 |     35.1563 |           - |           - |           108.31 KB |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 421.2 us |  16.370 us | 0.8973 us |  1.01 |    0.01 |     35.1563 |           - |           - |           108.31 KB |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 418.6 us |  53.332 us | 2.9233 us |  1.01 |    0.00 |     35.1563 |           - |           - |           108.31 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 415.4 us |  74.125 us | 4.0630 us |  1.00 |    0.00 |     35.1563 |           - |           - |           108.31 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 416.0 us |  35.462 us | 1.9438 us |  1.00 |    0.01 |     35.1563 |           - |           - |           108.31 KB |
|                               |           |          |         |          |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 368.8 us |  37.461 us | 2.0534 us |  1.06 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr | 330.9 us |  32.383 us | 1.7750 us |  0.95 |    0.02 |     52.7344 |           - |           - |           162.47 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 359.4 us |  38.185 us | 2.0931 us |  1.04 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 355.6 us |  56.579 us | 3.1013 us |  1.02 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 368.5 us |  39.545 us | 2.1676 us |  1.06 |    0.02 |     52.7344 |           - |           - |           162.47 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 365.8 us |  40.513 us | 2.2207 us |  1.05 |    0.02 |     52.7344 |           - |           - |           162.47 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 366.2 us |  32.128 us | 1.7610 us |  1.05 |    0.02 |     52.7344 |           - |           - |           162.47 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 357.9 us |  24.032 us | 1.3173 us |  1.03 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 347.2 us |  75.607 us | 4.1443 us |  1.00 |    0.00 |     52.7344 |           - |           - |           162.47 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 353.9 us |  32.302 us | 1.7706 us |  1.02 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|                               |           |          |         |          |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core | 364.8 us |   5.925 us | 0.3248 us |  1.12 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core | 326.5 us |  70.298 us | 3.8533 us |  1.00 |    0.02 |     52.7344 |           - |           - |           162.47 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core | 363.4 us |  32.962 us | 1.8068 us |  1.11 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core | 344.1 us |  25.162 us | 1.3792 us |  1.05 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core | 363.0 us |   4.750 us | 0.2604 us |  1.11 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core | 360.4 us | 133.359 us | 7.3098 us |  1.10 |    0.03 |     52.7344 |           - |           - |           162.47 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core | 361.3 us |  18.305 us | 1.0034 us |  1.11 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core | 347.5 us |   2.458 us | 0.1347 us |  1.06 |    0.01 |     52.7344 |           - |           - |           162.47 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 326.5 us |  43.158 us | 2.3656 us |  1.00 |    0.00 |     52.7344 |           - |           - |           162.47 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 323.9 us |  15.426 us | 0.8455 us |  0.99 |    0.00 |     52.7344 |           - |           - |           162.47 KB |
