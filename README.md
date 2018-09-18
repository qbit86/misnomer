# Misnomer

Standard collections with reduced allocations.

## Misnomer.Rist

**Rist&lt;T&gt;** — recyclable indexed collection. Implementation is based on [**List&lt;T&gt;**](https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Collections/Generic/List.cs), but uses pooling for the internal array.

### Examples

```csharp
Rist<string> rist = Directory.EnumerateDirectories(".").ToRist();
rist.AddRange(Directory.EnumerateFiles("."));
foreach (string item in rist)
    Console.WriteLine(item);

int count = rist.Count;
string[] array = rist.MoveToArray();
int length = array.Length;
Debug.Assert(count <= length);
Console.WriteLine($"{nameof(count)}: {count}, {nameof(length)}: {length}");

rist.Dispose();
```

It is not a fatal error to not dispose an instance of **Rist&lt;T&gt;**.
Failure to do so just leads to not returning the internal array to the pool, so it may be not worth to introduce nested scope with `using` block.

### Remarks

Implementation deliberatly prefers [shared](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1.shared) pool over [private](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1.create) one for the sake of performance.
The risk is that untrusted caller can hold a reference to an array after returning it to [**ArrayPool&lt;T&gt;.Shared**](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1.shared), thus getting access to internal state of **Rist&lt;T&gt;** on subsequent use.

## Misnomer.Fictionary

**Fictionary&lt;TKey, TValue, TKeyComparer&gt;** — strongly typed associative collection. 
Implementation is based on [**Dictionary&lt;TKey, TValue&gt;**](https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Collections/Generic/Dictionary.cs), but uses generic parameter for comparer.
Embedding it directly to the type of collection instead of indirect call to [**IEqualityComparer&lt;TKey&gt;**](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1) interface allows to avoid virtual call and prevents comparer from boxing in case of [value type](https://adamsitnik.com/Value-Types-vs-Reference-Types/).
