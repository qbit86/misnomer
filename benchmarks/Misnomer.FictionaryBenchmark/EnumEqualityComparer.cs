using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Key = System.ConsoleColor;

namespace Misnomer
{
    internal readonly struct EnumEqualityComparer : IEqualityComparer<Key>,
        IEquatable<EnumEqualityComparer>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Key x, Key y)
        {
            return (int)y == (int)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(Key obj)
        {
            return ((int)obj).GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(EnumEqualityComparer other)
        {
            return true;
        }
    }

    internal sealed class EnumEqualityComparerObject : IEqualityComparer<Key>
    {
        private EnumEqualityComparerObject() { }

        internal static EnumEqualityComparerObject Default { get; } = new EnumEqualityComparerObject();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Key x, Key y)
        {
            return (int)y == (int)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(Key obj)
        {
            return ((int)obj).GetHashCode();
        }
    }
}
