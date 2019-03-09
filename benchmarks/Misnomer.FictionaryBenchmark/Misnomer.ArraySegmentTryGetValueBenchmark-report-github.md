``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.348 (1809/October2018Update/Redstone5)
Intel Core i5-4690K CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT
  Job-ECXCYV : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-BZLAHT : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3362.0
  Job-YJIOJM : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Job-JDFWIG : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                        Method |       Jit | Platform | Runtime |      Mean |      Error |    StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------------ |---------- |--------- |-------- |----------:|-----------:|----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|       DictionaryConcreteValue | LegacyJit |      X64 |     Clr |  33.67 ns |  2.0716 ns | 0.1136 ns |  1.02 |    0.01 |           - |           - |           - |                   - |
|       FictionaryConcreteValue | LegacyJit |      X64 |     Clr |  21.13 ns |  2.4948 ns | 0.1367 ns |  0.64 |    0.01 |           - |           - |           - |                   - |
|   DictionaryConcreteReference | LegacyJit |      X64 |     Clr |  33.12 ns |  5.3131 ns | 0.2912 ns |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference | LegacyJit |      X64 |     Clr |  31.48 ns |  2.8414 ns | 0.1557 ns |  0.95 |    0.01 |           - |           - |           - |                   - |
|        DictionaryVirtualValue | LegacyJit |      X64 |     Clr |  33.43 ns |  1.6223 ns | 0.0889 ns |  1.01 |    0.01 |           - |           - |           - |                   - |
|        FictionaryVirtualValue | LegacyJit |      X64 |     Clr |  32.04 ns |  1.1116 ns | 0.0609 ns |  0.97 |    0.01 |           - |           - |           - |                   - |
|    DictionaryVirtualReference | LegacyJit |      X64 |     Clr |  33.50 ns |  2.1146 ns | 0.1159 ns |  1.01 |    0.01 |           - |           - |           - |                   - |
|    FictionaryVirtualReference | LegacyJit |      X64 |     Clr |  32.74 ns |  2.1532 ns | 0.1180 ns |  0.99 |    0.01 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr |  30.43 ns |  1.5804 ns | 0.0866 ns |  0.92 |    0.01 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic | LegacyJit |      X64 |     Clr | 173.84 ns | 18.6354 ns | 1.0215 ns |  5.25 |    0.06 |           - |           - |           - |                   - |
|             DictionaryDefault | LegacyJit |      X64 |     Clr |  30.41 ns |  0.9513 ns | 0.0521 ns |  0.92 |    0.01 |           - |           - |           - |                   - |
|                               |           |          |         |           |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue | LegacyJit |      X86 |     Clr |  20.64 ns |  0.2254 ns | 0.0124 ns |  1.05 |    0.01 |           - |           - |           - |                   - |
|       FictionaryConcreteValue | LegacyJit |      X86 |     Clr |  16.85 ns |  1.5713 ns | 0.0861 ns |  0.85 |    0.01 |           - |           - |           - |                   - |
|   DictionaryConcreteReference | LegacyJit |      X86 |     Clr |  19.71 ns |  1.6331 ns | 0.0895 ns |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference | LegacyJit |      X86 |     Clr |  19.20 ns |  1.0327 ns | 0.0566 ns |  0.97 |    0.00 |           - |           - |           - |                   - |
|        DictionaryVirtualValue | LegacyJit |      X86 |     Clr |  20.71 ns |  0.3419 ns | 0.0187 ns |  1.05 |    0.01 |           - |           - |           - |                   - |
|        FictionaryVirtualValue | LegacyJit |      X86 |     Clr |  18.50 ns |  2.5462 ns | 0.1396 ns |  0.94 |    0.00 |           - |           - |           - |                   - |
|    DictionaryVirtualReference | LegacyJit |      X86 |     Clr |  19.70 ns |  1.8768 ns | 0.1029 ns |  1.00 |    0.00 |           - |           - |           - |                   - |
|    FictionaryVirtualReference | LegacyJit |      X86 |     Clr |  19.20 ns |  0.6741 ns | 0.0369 ns |  0.97 |    0.01 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr |  16.67 ns |  1.7194 ns | 0.0942 ns |  0.85 |    0.01 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic | LegacyJit |      X86 |     Clr | 152.17 ns | 29.1864 ns | 1.5998 ns |  7.72 |    0.12 |           - |           - |           - |                   - |
|             DictionaryDefault | LegacyJit |      X86 |     Clr |  17.11 ns |  1.0568 ns | 0.0579 ns |  0.87 |    0.01 |           - |           - |           - |                   - |
|                               |           |          |         |           |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |     Clr |  34.62 ns |  4.7134 ns | 0.2584 ns |  1.01 |    0.02 |           - |           - |           - |                   - |
|       FictionaryConcreteValue |    RyuJit |      X64 |     Clr |  21.80 ns |  2.2384 ns | 0.1227 ns |  0.63 |    0.01 |           - |           - |           - |                   - |
|   DictionaryConcreteReference |    RyuJit |      X64 |     Clr |  34.42 ns |  5.5686 ns | 0.3052 ns |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference |    RyuJit |      X64 |     Clr |  32.47 ns |  5.3484 ns | 0.2932 ns |  0.94 |    0.02 |           - |           - |           - |                   - |
|        DictionaryVirtualValue |    RyuJit |      X64 |     Clr |  34.67 ns |  5.1490 ns | 0.2822 ns |  1.01 |    0.02 |           - |           - |           - |                   - |
|        FictionaryVirtualValue |    RyuJit |      X64 |     Clr |  33.45 ns |  5.1005 ns | 0.2796 ns |  0.97 |    0.01 |           - |           - |           - |                   - |
|    DictionaryVirtualReference |    RyuJit |      X64 |     Clr |  34.38 ns |  0.3415 ns | 0.0187 ns |  1.00 |    0.01 |           - |           - |           - |                   - |
|    FictionaryVirtualReference |    RyuJit |      X64 |     Clr |  33.88 ns |  1.9319 ns | 0.1059 ns |  0.98 |    0.01 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr |  31.72 ns |  2.0801 ns | 0.1140 ns |  0.92 |    0.01 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |     Clr | 181.50 ns |  9.1213 ns | 0.5000 ns |  5.27 |    0.06 |           - |           - |           - |                   - |
|             DictionaryDefault |    RyuJit |      X64 |     Clr |  31.55 ns |  0.3994 ns | 0.0219 ns |  0.92 |    0.01 |           - |           - |           - |                   - |
|                               |           |          |         |           |            |           |       |         |             |             |             |                     |
|       DictionaryConcreteValue |    RyuJit |      X64 |    Core |  32.44 ns |  1.5048 ns | 0.0825 ns |  1.02 |    0.00 |           - |           - |           - |                   - |
|       FictionaryConcreteValue |    RyuJit |      X64 |    Core |  21.47 ns |  0.2579 ns | 0.0141 ns |  0.68 |    0.00 |           - |           - |           - |                   - |
|   DictionaryConcreteReference |    RyuJit |      X64 |    Core |  31.75 ns |  0.7572 ns | 0.0415 ns |  1.00 |    0.00 |           - |           - |           - |                   - |
|   FictionaryConcreteReference |    RyuJit |      X64 |    Core |  32.63 ns |  4.8062 ns | 0.2634 ns |  1.03 |    0.01 |           - |           - |           - |                   - |
|        DictionaryVirtualValue |    RyuJit |      X64 |    Core |  32.61 ns |  2.3418 ns | 0.1284 ns |  1.03 |    0.00 |           - |           - |           - |                   - |
|        FictionaryVirtualValue |    RyuJit |      X64 |    Core |  42.36 ns |  1.2978 ns | 0.0711 ns |  1.33 |    0.00 |           - |           - |           - |                   - |
|    DictionaryVirtualReference |    RyuJit |      X64 |    Core |  31.55 ns |  1.8422 ns | 0.1010 ns |  0.99 |    0.00 |           - |           - |           - |                   - |
|    FictionaryVirtualReference |    RyuJit |      X64 |    Core |  31.12 ns |  1.1945 ns | 0.0655 ns |  0.98 |    0.00 |           - |           - |           - |                   - |
| DictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |  29.86 ns |  1.7254 ns | 0.0946 ns |  0.94 |    0.00 |           - |           - |           - |                   - |
| FictionaryStandardPolymorphic |    RyuJit |      X64 |    Core |  31.90 ns |  4.1551 ns | 0.2278 ns |  1.00 |    0.01 |           - |           - |           - |                   - |
|             DictionaryDefault |    RyuJit |      X64 |    Core |  29.97 ns |  1.6369 ns | 0.0897 ns |  0.94 |    0.00 |           - |           - |           - |                   - |
