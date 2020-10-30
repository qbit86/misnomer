using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Misnomer
{
    internal readonly struct ArraySegmentEqualityComparer<T> : IEqualityComparer<ArraySegment<T>>,
        IEquatable<ArraySegmentEqualityComparer<T>>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ArraySegment<T> x, ArraySegment<T> y) =>
            x.Array == y.Array && x.Offset == y.Offset && x.Count == y.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(ArraySegment<T> obj) =>
            obj.Array is null ? 0 : HashCode.Combine(obj.Offset, obj.Count, obj.Array.GetHashCode());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ArraySegmentEqualityComparer<T> other) => true;
    }

    internal sealed class ArraySegmentComparerObject<T> : IEqualityComparer<ArraySegment<T>>
    {
        private ArraySegmentComparerObject() { }

        internal static ArraySegmentComparerObject<T> Default { get; } = new ArraySegmentComparerObject<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ArraySegment<T> x, ArraySegment<T> y) =>
            x.Array == y.Array && x.Offset == y.Offset && x.Count == y.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(ArraySegment<T> obj) =>
            obj.Array is null ? 0 : HashCode.Combine(obj.Offset, obj.Count, obj.Array.GetHashCode());
    }
}
