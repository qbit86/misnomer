using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Misnomer
{
#pragma warning disable CA1815, CA2231
    /// <summary>
    /// Represents a string comparison operation that uses ordinal case-sensitive comparison rules.
    /// </summary>
    public readonly struct StringOrdinalComparer : IComparer<string>, IEqualityComparer<string>,
        IEquatable<StringOrdinalComparer>
#pragma warning restore CA2231, CA1815
    {
        /// <summary>
        /// Compares two strings and returns an indication of their relative sort order.
        /// </summary>
        /// <param name="x">A string to compare to <paramref name="y"/>.</param>
        /// <param name="y">A string to compare to <paramref name="x"/>.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(string x, string y)
        {
            return string.CompareOrdinal(x, y);
        }

        /// <summary>
        /// Indicates whether two strings are equal.
        /// </summary>
        /// <param name="x">A string to compare to <paramref name="y"/>.</param>
        /// <param name="y">A string to compare to <paramref name="x"/>.</param>
        /// <returns>`true` if <paramref name="x"/> and <paramref name="y"/> refer to the same object,
        /// or <paramref name="x"/> and <paramref name="y"/> are equal,
        /// or <paramref name="x"/> and <paramref name="y"/> are `null`; otherwise, `false`.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(string x, string y)
        {
            return string.Equals(x, y, StringComparison.Ordinal);
        }

        /// <summary>
        /// Gets the hash code for the specified string.
        /// </summary>
        /// <param name="obj">A string.</param>
        /// <returns>A 32-bit signed hash code calculated from the value of the <paramref name="obj"/> parameter.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(string obj)
        {
            return obj?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Indicates whether the current <see cref="StringOrdinalComparer" /> object is equal to another <see cref="StringOrdinalComparer" /> object.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>`true`.</returns>
        public bool Equals(StringOrdinalComparer other)
        {
            return true;
        }

        /// <summary>
        /// Indicates whether the current <see cref="StringOrdinalComparer" /> object is equal to another comparer object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true` if <paramref name="obj"/> is of type <see cref="StringOrdinalComparer" />; otherwise, `false`.</returns>
        public override bool Equals(object obj)
        {
            return obj is StringOrdinalComparer;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return typeof(StringOrdinalComparer).GetHashCode();
        }
    }
}
