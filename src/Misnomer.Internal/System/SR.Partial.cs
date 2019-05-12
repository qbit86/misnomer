namespace System
{
    // https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/src/Resources/Strings.resx

    internal static partial class SR
    {
        internal const string Arg_ArrayPlusOffTooSmall = "Destination array is not long enough to copy all the items in the collection. Check array index and length.";
        internal const string Arg_BogusIComparer = "Unable to sort because the IComparer.Compare() method returns inconsistent results. Either a value does not compare equal to itself, or one value repeatedly compared to another value yields different results. IComparer: '{0}'.";
        internal const string Arg_HTCapacityOverflow = "Hashtable's capacity overflowed and went negative. Check load factor, capacity and the current size of the table.";
        internal const string Arg_KeyNotFoundWithKey = "The given key '{0}' was not present in the dictionary.";
        internal const string Arg_NonZeroLowerBound = "The lower bound of target array must be zero.";
        internal const string Arg_RankMultiDimNotSupported = "Only single dimensional arrays are supported for the requested action.";
        internal const string Arg_SystemException = "System error.";
        internal const string Arg_WrongType = "The value '{0}' is not of type '{1}' and cannot be used in this generic collection.";
        internal const string Argument_AddingDuplicate = "An item with the same key has already been added. Key: {0}";
        internal const string Argument_BadFormatSpecifier = "Format specifier was invalid.";
        internal const string Argument_CannotExtractScalar = "Cannot extract a Unicode scalar value from the specified index in the input.";
        internal const string Argument_DestinationTooShort = "Destination is too short.";
        internal const string Argument_InvalidArrayType = "Target array type is not compatible with the type of items in the collection.";
        internal const string Argument_InvalidOffLen = "Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.";
        internal const string Argument_InvalidTypeWithPointersNotSupported = "Cannot use type '{0}'. Only value types without pointers or references are supported.";
        internal const string Argument_OverlapAlignmentMismatch = "Overlapping spans have mismatching alignment.";
        internal const string ArgumentOutOfRange_BiggerThanCollection = "Must be less than or equal to the size of the collection.";
        internal const string ArgumentOutOfRange_Count = "Count must be positive and count must refer to a location within the string/array/collection.";
        internal const string ArgumentOutOfRange_Index = "Index was out of range. Must be non-negative and less than the size of the collection.";
        internal const string ArgumentOutOfRange_ListInsert = "Index must be within the bounds of the List.";
        internal const string ArgumentOutOfRange_NeedNonNegNum = "Non-negative number required.";
        internal const string ArgumentOutOfRange_SmallCapacity = "capacity was less than the current size.";
        internal const string ConcurrentCollection_SyncRoot_NotSupported = "The SyncRoot property may not be used for the synchronization of concurrent collections.";
        internal const string InvalidOperation_ConcurrentOperationsNotSupported = "Operations that change non-concurrent collections must have exclusive access. A concurrent update was performed on this collection and corrupted its state. The collection's state is no longer correct.";
        internal const string InvalidOperation_EnumEnded = "Enumeration already finished.";
        internal const string InvalidOperation_EnumFailedVersion = "Collection was modified; enumeration operation may not execute.";
        internal const string InvalidOperation_EnumNotStarted = "Enumeration has not started. Call MoveNext.";
        internal const string InvalidOperation_EnumOpCantHappen = "Enumeration has either not started or has already finished.";
        internal const string InvalidOperation_IComparerFailed = "Failed to compare two elements in the array.";
        internal const string InvalidOperation_NoValue = "Nullable object must have a value.";
        internal const string InvalidOperation_NullArray = "The underlying array is null.";
        internal const string Memory_OutstandingReferences = "Release all references before disposing this instance.";
        internal const string MemoryDisposed = "Memory<T> has been disposed.";
        internal const string NotSupported_KeyCollectionSet = "Mutating a key collection derived from a dictionary is not allowed.";
        internal const string NotSupported_ReadOnlyCollection = "Collection is read-only.";
        internal const string NotSupported_StringComparison = "The string comparison type passed in is currently not supported.";
        internal const string NotSupported_ValueCollectionSet = "Mutating a value collection derived from a dictionary is not allowed.";
        internal const string Serialization_MissingKeys = "The keys for this dictionary are missing.";
        internal const string Serialization_NullKey = "One of the serialized keys is null.";
        internal const string SerializationException = "Serialization error.";
        internal const string TaskCompletionSourceT_TrySetException_NoExceptions = "The exceptions collection was empty.";
        internal const string TaskCompletionSourceT_TrySetException_NullException = "The exceptions collection included at least one null element.";
        internal const string TaskT_TransitionToFinal_AlreadyCompleted = "An attempt was made to transition a task to a final state when it had already completed.";
    }
}
