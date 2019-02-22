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
            return x.Array == y.Array && x.Offset == y.Offset && x.Count == y.Count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(ArraySegment<T> obj)
        {
            if (obj.Array == null)
                return 0;

            int hash = 5381;
            hash = System.Numerics.Hashing.HashHelpers.Combine(hash, obj.Offset);
            hash = System.Numerics.Hashing.HashHelpers.Combine(hash, obj.Count);

            hash ^= obj.Array.GetHashCode();
            return hash;
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
            return x.Array == y.Array && x.Offset == y.Offset && x.Count == y.Count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(ArraySegment<T> obj)
        {
            if (obj.Array == null)
                return 0;

            int hash = 5381;
            hash = System.Numerics.Hashing.HashHelpers.Combine(hash, obj.Offset);
            hash = System.Numerics.Hashing.HashHelpers.Combine(hash, obj.Count);

            hash ^= obj.Array.GetHashCode();
            return hash;
        }
    }
}
