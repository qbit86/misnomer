using System;
using System.Buffers;

// ReSharper disable once CheckNamespace
namespace Misnomer
{
    // https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/shared/System/Collections/Generic/List.cs
    /// <summary>
    /// Represents a recyclable list of objects that can be accessed by index.
    /// Enables pooling instances of inner array of type <see cref="T:T[]"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public partial class Rist<T> : IDisposable
    {
        private const int MaxArrayLength = 0X7FEFFFFF;

        private static ArrayPool<T> Pool => ArrayPool<T>.Shared;

        /// <summary>
        /// Returns the internal array to the pool and replaces it with a zero length array.
        /// </summary>
        public void Dispose()
        {
            T[] oldItems = _items;
            _size = 0;
            _items = s_emptyArray;
            _version++;
            Pool.Return(oldItems, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
        }

        /// <summary>
        /// Extracts the internal array and replaces it with a zero length array.
        /// </summary>
        /// <returns>An <see cref="T:T[]"/> that is <see cref="Capacity"/> in length.</returns>
        /// <remarks>
        /// This array is <see cref="Capacity"/> in length,
        /// so the caller should save actual <see cref="Count"/> before calling this method.
        /// </remarks>
        public T[] MoveToArray()
        {
            T[] result = _items;
            _size = 0;
            _items = s_emptyArray;
            _version++;
            return result;
        }
    }
}
