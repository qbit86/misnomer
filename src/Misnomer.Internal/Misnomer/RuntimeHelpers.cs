#if NET461 || NETSTANDARD2_0
namespace Misnomer
{
    internal static class RuntimeHelpers
    {
        internal static bool IsReferenceOrContainsReferences<T>() => true;
    }
}
#endif
