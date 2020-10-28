#if NETCOREAPP2_0 || NET461 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD2_0
namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    internal sealed class DoesNotReturnAttribute : Attribute { }
}
#endif
