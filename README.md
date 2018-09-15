# Misnomer

Standard collections with reduced allocations.

## Misnomer.Rist

**Rist&lt;T&gt;** — recyclable indexed collection. Implementation is based on [**List&lt;T&gt;**](https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/shared/System/Collections/Generic/List.cs), but uses pooling for the internal array.

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

### Remarks

Implementation deliberatly prefers [shared](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1.shared) pool over [private](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1.create) one for the sake of performance.
The risk is that untrusted caller can hold a reference to an array after returning it to **ArrayPool&lt;T&gt;.Shared**, thus getting access to internal state of **Rist&lt;T&gt;**.
