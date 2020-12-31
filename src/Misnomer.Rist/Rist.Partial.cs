using System;
using System.Buffers;
#if NETCOREAPP2_1 || NETCOREAPP3_1 || NETSTANDARD2_1
using RuntimeHelpers = System.Runtime.CompilerServices.RuntimeHelpers;

#endif

namespace Misnomer
{
    // https://github.com/dotnet/runtime/blob/e7204f5d6fcaca5e097ec854b3be6055229fc442/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/List.cs

    /// <summary>
    /// Represents a recyclable list of objects that can be accessed by index.
    /// Enables pooling instances of inner array of type <see cref="T:T[]"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public sealed partial class Rist<T> : IDisposable
    {
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
        /// Gets a span view over the data in a list.
        /// Items should not be added or removed from the <see cref="Rist{T}"/> while the <see cref="Span{T}"/> is in use.
        /// </summary>
        /// <returns>A <see cref="ReadOnlySpan{T}"/> instance over the <see cref="Rist{T}"/>.</returns>
        public ReadOnlySpan<T> AsSpan() => new(_items, 0, _size);

        /// <summary>
        /// Extracts the internal array and replaces it with a zero length array.
        /// </summary>
        /// <returns>An array that is <see cref="Capacity"/> in length.</returns>
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

        /// <summary>
        /// Extracts the internal array and replaces it with a zero length array.
        /// </summary>
        /// <param name="length">When this method returns,
        /// contains the actual number of elements in the <see cref="Rist{T}"/>.</param>
        /// <returns>An array that is <see cref="Capacity"/> in length.</returns>
        public T[] MoveToArray(out int length)
        {
            length = _size;
            return MoveToArray();
        }
    }
}
