# Misnomer

- [ ] Get rid of annoying [ArraySortHelper.cs] when method [MemoryExtensions.Sort()] will become available in [System.Memory] package newer than 4.5.4.
    Replace
    ```cs
    ArraySortHelper<T>.Sort(new Span<T>(_items, 0, _size), comparison);
    ```
    with
    ```cs
    new Span<T>(_items, 0, _size).Sort(comparison);
    ```
- [ ] Update sources when C# 9 will be available: replace generic `T` with `T?` in a couple of places, remove suppression rules in related `.editorconfig`s.

[ArraySortHelper.cs]: src/Misnomer.Rist/System/ArraySortHelper.cs
[MemoryExtensions.Sort()]: https://docs.microsoft.com/en-us/dotnet/api/system.memoryextensions.sort
[System.Memory]: https://nuget.org/packages/System.Memory/
