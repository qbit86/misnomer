using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Misnomer
{
    internal sealed class GenericEqualityComparerObject<T> : IEqualityComparer<T>
        where T : IEquatable<T>
    {
        private GenericEqualityComparerObject() { }

        internal static GenericEqualityComparerObject<T> Default { get; } = new GenericEqualityComparerObject<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(T x, T y)
        {
            if (y == null)
                return x == null;

            return y.Equals(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(T obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }
}
