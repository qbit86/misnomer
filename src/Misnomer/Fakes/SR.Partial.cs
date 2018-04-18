// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace System
{
    // https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/src/Resources/Strings.resx
    // ReSharper disable once InconsistentNaming
    internal static partial class SR
    {
        internal const string Arg_BogusIComparer = "Unable to sort because the IComparer.Compare() method returns inconsistent results. Either a value does not compare equal to itself, or one value repeatedly compared to another value yields different results. IComparer: '{0}'.";
        internal const string Arg_KeyNotFoundWithKey = "The given key '{0}' was not present in the dictionary.";
        internal const string Arg_WrongType = "The value '{0}' is not of type '{1}' and cannot be used in this generic collection.";
        internal const string Argument_AddingDuplicate = "An item with the same key has already been added. Key: {0}";
        internal const string Argument_DestinationTooShort = "Destination is too short.";
        internal const string Argument_InvalidArrayType = "Target array type is not compatible with the type of items in the collection.";
        internal const string Argument_InvalidTypeWithPointersNotSupported = "Cannot use type '{0}'. Only value types without pointers or references are supported.";
        internal const string Argument_OverlapAlignmentMismatch = "Overlapping spans have mismatching alignment.";
        internal const string ArgumentOutOfRange_NeedNonNegNum = "Non-negative number required.";
        internal const string InvalidOperation_ConcurrentOperationsNotSupported = "Operations that change non-concurrent collections must have exclusive access. A concurrent update was performed on this collection and corrupted its state. The collection's state is no longer correct.";
        internal const string InvalidOperation_EnumEnded = "Enumeration already finished.";
        internal const string InvalidOperation_EnumFailedVersion = "Collection was modified; enumeration operation may not execute.";
        internal const string InvalidOperation_EnumNotStarted = "Enumeration has not started. Call MoveNext.";
        internal const string InvalidOperation_EnumOpCantHappen = "Enumeration has either not started or has already finished.";
        internal const string InvalidOperation_IComparerFailed = "Failed to compare two elements in the array.";
        internal const string InvalidOperation_NoValue = "Nullable object must have a value.";
        internal const string Memory_OutstandingReferences = "Release all references before disposing this instance.";
        // TODO: Finish assigning constant values.
        internal const string MemoryDisposed = "";
        internal const string Argument_InvalidOffLen = "";
        internal const string ArgumentOutOfRange_Index = "";
        internal const string ArgumentOutOfRange_Count = "";
        internal const string Arg_ArrayPlusOffTooSmall = "";
        internal const string NotSupported_ReadOnlyCollection = "";
        internal const string Arg_RankMultiDimNotSupported = "";
        internal const string Arg_NonZeroLowerBound = "";
        internal const string ArgumentOutOfRange_ListInsert = "";
        internal const string ArgumentOutOfRange_SmallCapacity = "";
        internal const string ArgumentOutOfRange_BiggerThanCollection = "";
        internal const string Serialization_MissingKeys = "";
        internal const string Serialization_NullKey = "";
        internal const string NotSupported_KeyCollectionSet = "";
        internal const string NotSupported_ValueCollectionSet = "";
        internal const string InvalidOperation_NullArray = "";
        internal const string TaskT_TransitionToFinal_AlreadyCompleted = "";
        internal const string TaskCompletionSourceT_TrySetException_NullException = "";
        internal const string TaskCompletionSourceT_TrySetException_NoExceptions = "";
        internal const string NotSupported_StringComparison = "";
    }
}
