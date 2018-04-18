// ReSharper disable once CheckNamespace
namespace System
{
    // https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/src/Resources/Strings.resx
    // ReSharper disable once InconsistentNaming
    internal static partial class SR
    {
        internal const string Arg_BogusIComparer = "Unable to sort because the IComparer.Compare() method returns inconsistent results. Either a value does not compare equal to itself, or one value repeatedly compared to another value yields different results. IComparer: '{0}'.";
        internal const string InvalidOperation_IComparerFailed = "Failed to compare two elements in the array.";
    }
}
