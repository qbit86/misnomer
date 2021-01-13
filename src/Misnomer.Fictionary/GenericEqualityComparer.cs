using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Misnomer
{
    // https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/EqualityComparer.cs

#pragma warning disable CA1815, CA2231
    /// <summary>
    /// Compares two objects for equivalence by invoking the implementation of the <see cref="IEquatable{T}.Equals(T)"/>.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    public readonly struct GenericEqualityComparer<T> : IEqualityComparer<T>, IEquatable<GenericEqualityComparer<T>>
        where T : IEquatable<T>
    {
        /// <summary>
        /// Determines whether two objects are equal.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>`true` if the specified objects are equal; otherwise, `false`.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(T? x, T? y)
        {
            if (x != null)
            {
                if (y != null) return x.Equals(y);
                return false;
            }

            if (y != null) return false;
            return true;
        }

        // ReSharper disable ConstantConditionalAccessQualifier
        /// <summary>
        /// Serves as a hash function for the specified object for hashing algorithms and data structures, such as a hash table.
        /// </summary>
        /// <param name="obj">The object for which to get a hash code.</param>
        /// <returns>A hash code for the specified object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode([DisallowNull] T obj) => obj?.GetHashCode() ?? 0;
        // ReSharper restore ConstantConditionalAccessQualifier

        /// <summary>
        /// Indicates whether the current <see cref="GenericEqualityComparer{T}"/> object is equal to another <see cref="GenericEqualityComparer{T}"/> object.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>`true`.</returns>
        public bool Equals(GenericEqualityComparer<T> other) => true;

        /// <summary>
        /// Indicates whether the current <see cref="GenericEqualityComparer{T}"/> object is equal to another comparer object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true` if <paramref name="obj"/> is of type <see cref="GenericEqualityComparer{T}"/>; otherwise, `false`.</returns>
        public override bool Equals(object? obj) =>
            obj is GenericEqualityComparer<T>;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() =>
            typeof(GenericEqualityComparer<T>).GetHashCode();
    }
#pragma warning restore CA2231, CA1815
}
