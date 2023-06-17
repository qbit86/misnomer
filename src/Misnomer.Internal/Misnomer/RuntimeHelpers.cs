#if !NETCOREAPP2_0_OR_GREATER && !NETSTANDARD2_1_OR_GREATER
namespace Misnomer
{
    internal static class RuntimeHelpers
    {
        internal static bool IsReferenceOrContainsReferences<T>() => true;
    }
}
#endif
