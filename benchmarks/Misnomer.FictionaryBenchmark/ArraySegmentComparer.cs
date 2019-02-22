using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Misnomer
{
    internal readonly struct ArraySegmentComparer<T> : IEqualityComparer<ArraySegment<T>>,
        IEquatable<ArraySegmentComparer<T>>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ArraySegment<T> x, ArraySegment<T> y)
        {
            return x.Equals(y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(ArraySegment<T> obj)
        {
            return obj.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ArraySegmentComparer<T> other)
        {
            return true;
        }
    }

    internal sealed class ArraySegmentComparerObject<T> : IEqualityComparer<ArraySegment<T>>
    {
        private ArraySegmentComparerObject() { }

        internal static ArraySegmentComparerObject<T> Default { get; } = new ArraySegmentComparerObject<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ArraySegment<T> x, ArraySegment<T> y)
        {
            return x.Equals(y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(ArraySegment<T> obj)
        {
            return obj.GetHashCode();
        }
    }
}
