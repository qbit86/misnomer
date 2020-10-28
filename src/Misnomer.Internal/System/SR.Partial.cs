// ReSharper disable InconsistentNaming

namespace System
{
    // https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/src/Resources/Strings.resx

    internal static partial class SR
    {
        internal const string Arg_ArrayPlusOffTooSmall = "Destination array is not long enough to copy all the items in the collection. Check array index and length.";
        internal const string Arg_BogusIComparer = "Unable to sort because the IComparer.Compare() method returns inconsistent results. Either a value does not compare equal to itself, or one value repeatedly compared to another value yields different results. IComparer: '{0}'.";
        internal const string Arg_HTCapacityOverflow = "Hashtable's capacity overflowed and went negative. Check load factor, capacity and the current size of the table.";
        internal const string Arg_KeyNotFoundWithKey = "The given key '{0}' was not present in the dictionary.";
        internal const string Arg_LowerBoundsMustMatch = "The arrays' lower bounds must be identical.";
        internal const string Arg_MustBeType = "Type must be a type provided by the runtime.";
        internal const string Arg_Need1DArray = "Array was not a one-dimensional array.";
        internal const string Arg_Need2DArray = "Array was not a two-dimensional array.";
        internal const string Arg_Need3DArray = "Array was not a three-dimensional array.";
        internal const string Arg_NeedAtLeast1Rank = "Must provide at least one rank.";
        internal const string Arg_NonZeroLowerBound = "The lower bound of target array must be zero.";
        internal const string Arg_RankIndices = "Indices length does not match the array rank.";
        internal const string Arg_RankMultiDimNotSupported = "Only single dimensional arrays are supported for the requested action.";
        internal const string Arg_RanksAndBounds = "Number of lengths and lowerBounds must match.";
        internal const string Arg_TypeNotSupported = "Specified type is not supported";
        internal const string Arg_WrongType = "The value '{0}' is not of type '{1}' and cannot be used in this generic collection.";
        internal const string Argument_AddingDuplicate = "An item with the same key has already been added. Key: {0}";
        internal const string Argument_AddingDuplicateWithKey = "An item with the same key has already been added. Key: {0}";
        internal const string Argument_BadFormatSpecifier = "Format specifier was invalid.";
        internal const string Argument_CannotExtractScalar = "Cannot extract a Unicode scalar value from the specified index in the input.";
        internal const string Argument_DestinationTooShort = "Destination is too short.";
        internal const string Argument_InvalidArgumentForComparison = "Type of argument is not compatible with the generic comparer.";
        internal const string Argument_InvalidArrayType = "Target array type is not compatible with the type of items in the collection.";
        internal const string Argument_InvalidFlag = "Value of flags is invalid.";
        internal const string Argument_InvalidOffLen = "Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.";
        internal const string Argument_InvalidTypeWithPointersNotSupported = "Cannot use type '{0}'. Only value types without pointers or references are supported.";
        internal const string Argument_OverlapAlignmentMismatch = "Overlapping spans have mismatching alignment.";
        internal const string Argument_PrecisionTooLarge = "Precision cannot be larger than {0}.";
        internal const string Argument_SpansMustHaveSameLength = "Length of items must be same as length of keys.";
        internal const string ArgumentException_OtherNotArrayOfCorrectLength = "Object is not a array with the same number of elements as the array to compare it to.";
        internal const string ArgumentException_ValueTupleIncorrectType = "Argument must be of type {0}.";
        internal const string ArgumentNull_Array = "Array cannot be null.";
        internal const string ArgumentNull_SafeHandle = "SafeHandle cannot be null.";
        internal const string ArgumentOutOfRange_BadHourMinuteSecond = "Hour, Minute, and Second parameters describe an un-representable DateTime.";
        internal const string ArgumentOutOfRange_BadYearMonthDay = "Year, Month, and Day parameters describe an un-representable DateTime.";
        internal const string ArgumentOutOfRange_BiggerThanCollection = "Must be less than or equal to the size of the collection.";
        internal const string ArgumentOutOfRange_Count = "Count must be positive and count must refer to a location within the string/array/collection.";
        internal const string ArgumentOutOfRange_EndIndexStartIndex = "endIndex cannot be greater than startIndex.";
        internal const string ArgumentOutOfRange_Enum = "Enum value was out of legal range.";
        internal const string ArgumentOutOfRange_GetCharCountOverflow = "Too many bytes. The resulting number of chars is larger than what can be returned as an int.";
        internal const string ArgumentOutOfRange_HugeArrayNotSupported = "Arrays larger than 2GB are not supported.";
        internal const string ArgumentOutOfRange_Index = "Index was out of range. Must be non-negative and less than the size of the collection.";
        internal const string ArgumentOutOfRange_IndexCount = "Index and count must refer to a location within the string.";
        internal const string ArgumentOutOfRange_IndexCountBuffer = "Index and count must refer to a location within the buffer.";
        internal const string ArgumentOutOfRange_ListInsert = "Index must be within the bounds of the List.";
        internal const string ArgumentOutOfRange_NeedNonNegNum = "Non-negative number required.";
        internal const string ArgumentOutOfRange_SmallCapacity = "capacity was less than the current size.";
        internal const string ArgumentOutOfRange_Year = "Year must be between 1 and 9999.";
        internal const string AsyncMethodBuilder_InstanceNotInitialized = "The builder was not properly initialized.";
        internal const string ConcurrentCollection_SyncRoot_NotSupported = "The SyncRoot property may not be used for the synchronization of concurrent collections.";
        internal const string InvalidOperation_ConcurrentOperationsNotSupported = "Operations that change non-concurrent collections must have exclusive access. A concurrent update was performed on this collection and corrupted its state. The collection's state is no longer correct.";
        internal const string InvalidOperation_EnumEnded = "Enumeration already finished.";
        internal const string InvalidOperation_EnumFailedVersion = "Collection was modified; enumeration operation may not execute.";
        internal const string InvalidOperation_EnumNotStarted = "Enumeration has not started. Call MoveNext.";
        internal const string InvalidOperation_EnumOpCantHappen = "Enumeration has either not started or has already finished.";
        internal const string InvalidOperation_HandleIsNotInitialized = "Handle is not initialized.";
        internal const string InvalidOperation_HandleIsNotPinned = "Handle is not pinned.";
        internal const string InvalidOperation_IComparerFailed = "Failed to compare two elements in the array.";
        internal const string InvalidOperation_NoValue = "Nullable object must have a value.";
        internal const string InvalidOperation_NullArray = "The underlying array is null.";
        internal const string InvalidOperation_WrongAsyncResultOrEndCalledMultiple = "Either the IAsyncResult object did not come from the corresponding async method on this type, or the End method was called multiple times with the same IAsyncResult.";
        internal const string Memory_OutstandingReferences = "Release all references before disposing this instance.";
        internal const string NotSupported_FixedSizeCollection = "Collection was of a fixed size.";
        internal const string NotSupported_KeyCollectionSet = "Mutating a key collection derived from a dictionary is not allowed.";
        internal const string NotSupported_ReadOnlyCollection = "Collection is read-only.";
        internal const string NotSupported_StringComparison = "The string comparison type passed in is currently not supported.";
        internal const string NotSupported_ValueCollectionSet = "Mutating a value collection derived from a dictionary is not allowed.";
        internal const string Overflow_TimeSpanTooLong = "TimeSpan overflowed because the duration is too long.";
        internal const string Rank_MultiDimNotSupported = "Only single dimension arrays are supported here.";
        internal const string Serialization_MissingKeys = "The keys for this dictionary are missing.";
        internal const string Serialization_NullKey = "One of the serialized keys is null.";
        internal const string SerializationException = "Serialization error.";
        internal const string Task_ContinueWith_ESandLR = "The specified TaskContinuationOptions combined LongRunning and ExecuteSynchronously.  Synchronous continuations should not be long running.";
        internal const string Task_ContinueWith_NotOnAnything = "The specified TaskContinuationOptions excluded all continuation kinds.";
        internal const string Task_Delay_InvalidDelay = "The value needs to translate in milliseconds to -1 (signifying an infinite timeout), 0 or a positive integer less than or equal to the maximum allowed timer duration.";
        internal const string Task_Delay_InvalidMillisecondsDelay = "The value needs to be either -1 (signifying an infinite timeout), 0 or a positive integer.";
        internal const string Task_Dispose_NotCompleted = "A task may only be disposed if it is in a completion state (RanToCompletion, Faulted or Canceled).";
        internal const string Task_MultiTaskContinuation_EmptyTaskList = "The tasks argument contains no tasks.";
        internal const string Task_MultiTaskContinuation_NullTask = "The tasks argument included a null value.";
        internal const string Task_RunSynchronously_AlreadyStarted = "RunSynchronously may not be called on a task that was already started.";
        internal const string Task_RunSynchronously_Continuation = "RunSynchronously may not be called on a continuation task.";
        internal const string Task_RunSynchronously_Promise = "RunSynchronously may not be called on a task not bound to a delegate, such as the task returned from an asynchronous method.";
        internal const string Task_RunSynchronously_TaskCompleted = "RunSynchronously may not be called on a task that has already completed.";
        internal const string Task_Start_AlreadyStarted = "Start may not be called on a task that was already started.";
        internal const string Task_Start_ContinuationTask = "Start may not be called on a continuation task.";
        internal const string Task_Start_Promise = "Start may not be called on a promise-style task.";
        internal const string Task_Start_TaskCompleted = "Start may not be called on a task that has completed.";
        internal const string Task_ThrowIfDisposed = "The task has been disposed.";
        internal const string Task_WaitMulti_NullTask = "The tasks array included at least one null element.";
        internal const string TaskCompletionSourceT_TrySetException_NoExceptions = "The exceptions collection was empty.";
        internal const string TaskCompletionSourceT_TrySetException_NullException = "The exceptions collection included at least one null element.";
        internal const string TaskT_TransitionToFinal_AlreadyCompleted = "An attempt was made to transition a task to a final state when it had already completed.";
    }
}
