#if NET461 || NETSTANDARD1_3 || NETSTANDARD2_0
namespace System.Runtime.CompilerServices
{
    internal static class RuntimeHelpers
    {
        internal static bool IsReferenceOrContainsReferences<T>() => true;
    }
}
#endif
