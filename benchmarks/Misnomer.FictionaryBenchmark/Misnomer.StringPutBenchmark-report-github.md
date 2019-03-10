``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-AHGJRA : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-ZHPJMA : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-FVKGSB : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-TQTNGY : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |     Mean |      Error |    StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |---------:|-----------:|----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr | 375.3 us |  12.200 us | 0.6687 us |  1.02 |    0.00 |     69.8242 |           - |           - |           215.46 KB |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr | 352.2 us | 107.980 us | 5.9187 us |  0.95 |    0.02 |     69.8242 |           - |           - |           218.14 KB |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr | 369.5 us |   5.805 us | 0.3182 us |  1.00 |    0.00 |     69.8242 |           - |           - |           215.45 KB |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr | 379.8 us |   3.509 us | 0.1924 us |  1.03 |    0.00 |     69.8242 |           - |           - |           218.14 KB |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr | 375.2 us |  12.513 us | 0.6859 us |  1.02 |    0.00 |     69.8242 |           - |           - |           215.46 KB |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr | 386.4 us |  18.272 us | 1.0016 us |  1.05 |    0.00 |     69.3359 |           - |           - |           218.16 KB |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr | 372.1 us |   3.569 us | 0.1956 us |  1.01 |    0.00 |     69.8242 |           - |           - |           215.45 KB |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr | 378.6 us |   9.823 us | 0.5384 us |  1.02 |    0.00 |     69.8242 |           - |           - |           218.14 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 359.3 us |   3.973 us | 0.2178 us |  0.97 |    0.00 |     69.8242 |           - |           - |           215.45 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 380.0 us |  20.883 us | 1.1447 us |  1.03 |    0.00 |     69.8242 |           - |           - |           218.14 KB |
|                               |           |          |         |          |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr | 431.7 us |  16.265 us | 0.8915 us |  1.01 |    0.00 |     47.3633 |           - |           - |           146.37 KB |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr | 413.2 us |   9.799 us | 0.5371 us |  0.97 |    0.00 |     47.8516 |           - |           - |           147.93 KB |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr | 428.0 us |  15.825 us | 0.8674 us |  1.00 |    0.00 |     47.3633 |           - |           - |           146.37 KB |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr | 432.7 us |   3.505 us | 0.1921 us |  1.01 |    0.00 |     47.8516 |           - |           - |           147.93 KB |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr | 431.9 us |   8.483 us | 0.4650 us |  1.01 |    0.00 |     47.3633 |           - |           - |           146.37 KB |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr | 437.8 us |  18.885 us | 1.0352 us |  1.02 |    0.00 |     47.8516 |           - |           - |              148 KB |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr | 429.1 us |   8.879 us | 0.4867 us |  1.00 |    0.00 |     47.3633 |           - |           - |           146.37 KB |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr | 431.6 us |  11.972 us | 0.6562 us |  1.01 |    0.00 |     47.8516 |           - |           - |           147.93 KB |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 426.8 us |   5.485 us | 0.3006 us |  1.00 |    0.00 |     47.3633 |           - |           - |           146.37 KB |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 436.0 us |   7.806 us | 0.4279 us |  1.02 |    0.00 |     47.8516 |           - |           - |           147.93 KB |
|                               |           |          |         |          |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr | 379.0 us |   9.790 us | 0.5366 us |  1.02 |    0.00 |     69.8242 |           - |           - |           215.46 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr | 348.2 us |  17.861 us | 0.9790 us |  0.94 |    0.00 |     69.8242 |           - |           - |           218.14 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr | 371.5 us |   8.631 us | 0.4731 us |  1.00 |    0.00 |     69.8242 |           - |           - |           215.45 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr | 380.9 us |  10.021 us | 0.5493 us |  1.03 |    0.00 |     69.8242 |           - |           - |           218.14 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr | 373.8 us |  16.326 us | 0.8949 us |  1.01 |    0.00 |     69.8242 |           - |           - |           215.46 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr | 385.2 us |   5.930 us | 0.3250 us |  1.04 |    0.00 |     69.3359 |           - |           - |           218.16 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr | 369.7 us |  27.263 us | 1.4944 us |  1.00 |    0.01 |     69.8242 |           - |           - |           215.45 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr | 380.7 us |   5.096 us | 0.2793 us |  1.02 |    0.00 |     69.8242 |           - |           - |           218.14 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 358.6 us |   6.384 us | 0.3499 us |  0.97 |    0.00 |     69.8242 |           - |           - |           215.45 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 382.9 us |  28.843 us | 1.5810 us |  1.03 |    0.00 |     69.8242 |           - |           - |           218.14 KB |
|                               |           |          |         |          |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core | 384.1 us |  19.582 us | 1.0734 us |  1.01 |    0.01 |     69.8242 |           - |           - |           215.42 KB |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core | 354.9 us |   3.860 us | 0.2116 us |  0.94 |    0.01 |     69.8242 |           - |           - |           218.13 KB |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core | 378.8 us |  54.649 us | 2.9955 us |  1.00 |    0.00 |     69.8242 |           - |           - |            215.4 KB |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core | 376.4 us |   7.221 us | 0.3958 us |  0.99 |    0.01 |     69.8242 |           - |           - |           218.13 KB |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core | 386.0 us |   5.858 us | 0.3211 us |  1.02 |    0.01 |     69.8242 |           - |           - |           215.42 KB |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core | 383.4 us |  14.036 us | 0.7694 us |  1.01 |    0.01 |     69.8242 |           - |           - |           218.16 KB |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core | 391.2 us |  91.452 us | 5.0128 us |  1.03 |    0.01 |     69.8242 |           - |           - |            215.4 KB |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core | 378.9 us |  29.507 us | 1.6174 us |  1.00 |    0.00 |     69.8242 |           - |           - |           218.13 KB |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 361.0 us |  37.422 us | 2.0512 us |  0.95 |    0.00 |     69.8242 |           - |           - |            215.4 KB |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core | 363.6 us |  68.346 us | 3.7462 us |  0.96 |    0.02 |     69.8242 |           - |           - |           218.13 KB |
