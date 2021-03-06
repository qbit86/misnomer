# Misnomer

[![Rist version](https://img.shields.io/nuget/v/Misnomer.Rist.svg?label=Rist&logo=nuget)](https://www.nuget.org/packages/Misnomer.Rist/)
[![Fictionary version](https://img.shields.io/nuget/v/Misnomer.Fictionary.svg?label=Fictionary&logo=nuget)](https://www.nuget.org/packages/Misnomer.Fictionary/)

Standard collections with some optimizations.

## Misnomer.Rist

`Rist<T>` — recyclable indexed collection.
Implementation is based on [List&lt;T&gt;](https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/List.cs), but uses pooling for the internal array.

### Examples

```csharp
using Misnomer;
using Misnomer.Extensions;
```

```csharp
using Rist<string> rist = Directory.EnumerateDirectories(".").ToRist();
rist.AddRange(Directory.EnumerateFiles("."));
foreach (string item in rist)
    Console.WriteLine(item);

string[] array = rist.MoveToArray(out int count);
int length = array.Length;
Debug.Assert(count <= length);
Console.WriteLine($"{nameof(count)}: {count}, {nameof(length)}: {length}");
```

It is not a fatal error to not dispose an instance of `Rist<T>`.
Failure to do so just leads to not returning the internal array to the pool, so it may be not worth to introduce nested scope with `using` block.

### Remarks

Implementation deliberately prefers [shared](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1.shared) pool over [private](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1.create) one for the sake of performance.
The risk is that untrusted caller can hold a reference to an array after returning it to [ArrayPool&lt;T&gt;.Shared](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1.shared), thus getting access to internal state of `Rist<T>` on subsequent use.

## Misnomer.Fictionary

`Fictionary<TKey, TValue, TKeyComparer>` — fast associative collection.
Implementation is based on [Dictionary&lt;TKey, TValue&gt;](https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/Dictionary.cs), but uses generic parameter constraint for polymorphic key comparer.
Specializing with concrete type instead of indirect call to [IEqualityComparer&lt;TKey&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1) interface allows to avoid virtual call and prevents from boxing in case of [value types](https://adamsitnik.com/Value-Types-vs-Reference-Types/).

### Examples

```csharp
using Misnomer;
using Misnomer.Extensions;
```

```csharp
IEnumerable<FileInfo> currentDirFiles =
    new DirectoryInfo(Environment.CurrentDirectory).EnumerateFiles();
using Fictionary<string, FileInfo, OrdinalStringComparer> fictionary = currentDirFiles
    .ToFictionary(fi => fi.Name, new OrdinalStringComparer());

IEnumerable<FileInfo> userDirFiles =
    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)).EnumerateFiles();
foreach (FileInfo fi in userDirFiles)
    fictionary.TryAdd(fi.Name, fi);

foreach (KeyValuePair<string, FileInfo> kv in fictionary)
    Console.WriteLine($"{kv.Key}\t{kv.Value.Directory.FullName}");

Console.WriteLine();
if (fictionary.TryGetValue(".gitconfig", out FileInfo? value))
    Console.WriteLine($"{value.Name}: {value.Length} bytes");
```

There are several ways to create instance of `Fictionary<TKey, TValue, TKeyComparer>`.

Constructor overloads are similar to those of `Dictionary<TKey, TValue>`, but explicitly require passing comparer and specifying all types, so can be verbose. 

To utilize type inference for comparer, you can use factory methods defined in `Fictionary<TKey, TValue>` static class:

```csharp
using var f = Fictionary<string, int>.Create(comparer: new OrdinalStringComparer());
```

Inferred type for `f` here is `Fictionary<string, int, OrdinalStringComparer>`.
There are less generic parameters to specify comparing to invoking constructor:

```csharp
using Fictionary<string, int, OrdinalStringComparer> f = new(comparer: new OrdinalStringComparer());
```

In case if `TKey` implements `IEquatable<TKey>`, and you're fine with this default comparison, you can use factory methods defined in `DefaultFictionary<TKey, TValue>` static class:

```csharp
using var f = DefaultFictionary<int, string>.Create(capacity: 23);
```

Inferred type for `f` here is `Fictionary<int, string, GenericEqualityComparer<int>>`.

`GenericEqualityComparer<T>` is like [EqualityComparer&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.equalitycomparer-1), but requires type of comparands to implement `IEquatable<TKey>`. Unlike `EqualityComparer<T>` it will never fall back to `Object.Equals(Object)`, so no unexpected boxing may happen.

In case if you want to initialize dictionary from collection, you can use `ToFictionary()` extension methods; just import `Misnomer.Extensions` namespace:

```csharp
using var f = Directory.EnumerateDirectories(".")
    .ToFictionary(s => s, s => new DirectoryInfo(s), new OrdinalStringComparer());
```

### Remarks

Take a look at reports in benchmarks/ directory.
Or even better, measure performance by yourself on your environment.

For example for `string` keys `Fictionary<string, int, TComparer>` shows better performance than `Dictionary<string, int>` when `TCmparer` **is value type**.
If comparer is of reference type then outcome may vary depending on JIT/platform/runtime combination. 

## Source Link

All libraries support [Source Link](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/sourcelink) for source code debugging. To enable stepping into library methods implementation in Visual Studio 2017 Update 9, select **Enable Source Link support** in debugging options, and clear **Enable Just My Code**. Source code will be automatically downloaded from GitHub on demand.

![Enable Source Link support](source-link-highlight.png?raw=true)

## License

[![License](https://img.shields.io/github/license/qbit86/misnomer)](LICENSE.txt)

The icon is designed by [OpenMoji](https://openmoji.org) — the open-source emoji and icon project.
License: [CC BY-SA 4.0](https://creativecommons.org/licenses/by-sa/4.0/).
