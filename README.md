# Misnomer

## Misnomer.Rist

**Rist&lt;T&gt;** — recyclable indexed collection. Implementation is based on [**List&lt;Tglt;**](https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/shared/System/Collections/Generic/List.cs), but uses pooling for the internal array.

### Examples

```
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
