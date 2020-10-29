using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Misnomer
{
    internal sealed class GenericEqualityComparerObject<T> : IEqualityComparer<T>
        where T : IEquatable<T>
    {
        private GenericEqualityComparerObject() { }

        internal static GenericEqualityComparerObject<T> Default { get; } = new GenericEqualityComparerObject<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals([AllowNull] T x, [AllowNull] T y)
        {
            if (x is null || y is null)
                return x is null && y is null;

            return x.Equals(y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(T obj) => obj.GetHashCode();
    }
}
