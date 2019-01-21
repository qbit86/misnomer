using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Misnomer
{
    // https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Collections/Generic/EqualityComparer.cs
    public readonly struct GenericEqualityComparer<T> : IEqualityComparer<T>, IEquatable<GenericEqualityComparer<T>>
        where T : IEquatable<T>
    {
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

        public bool Equals(GenericEqualityComparer<T> other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is GenericEqualityComparer<T>;
        }

        public override int GetHashCode()
        {
            return typeof(GenericEqualityComparer<T>).GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(GenericEqualityComparer<T> left, GenericEqualityComparer<T> right)
        {
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(GenericEqualityComparer<T> left, GenericEqualityComparer<T> right)
        {
            return false;
        }
    }
}
