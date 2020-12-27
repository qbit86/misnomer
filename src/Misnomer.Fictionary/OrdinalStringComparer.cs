using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Misnomer
{
#pragma warning disable CA1815, CA2231
    /// <summary>
    /// Represents a string comparison operation that uses ordinal case-sensitive comparison rules.
    /// </summary>
    public readonly struct OrdinalStringComparer : IComparer<string>, IEqualityComparer<string>,
        IEquatable<OrdinalStringComparer>
    {
        /// <summary>
        /// Compares two strings and returns an indication of their relative sort order.
        /// </summary>
        /// <param name="x">A string to compare to <paramref name="y"/>.</param>
        /// <param name="y">A string to compare to <paramref name="x"/>.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(string? x, string? y) => string.CompareOrdinal(x, y);

        /// <summary>
        /// Indicates whether two strings are equal.
        /// </summary>
        /// <param name="x">A string to compare to <paramref name="y"/>.</param>
        /// <param name="y">A string to compare to <paramref name="x"/>.</param>
        /// <returns>
        /// `true` if <paramref name="x"/> and <paramref name="y"/> refer to the same object,
        /// or <paramref name="x"/> and <paramref name="y"/> are equal,
        /// or <paramref name="x"/> and <paramref name="y"/> are `null`; otherwise, `false`.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(string? x, string? y) => string.Equals(x, y, StringComparison.Ordinal);

        /// <summary>
        /// Gets the hash code for the specified string.
        /// </summary>
        /// <param name="obj">A string.</param>
        /// <returns>A 32-bit signed hash code calculated from the value of the <paramref name="obj"/> parameter.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(string obj)
        {
            // ReSharper disable ConstantConditionalAccessQualifier
#if NETCOREAPP2_1 || NETCOREAPP3_0 || NETSTANDARD2_1
            return obj?.GetHashCode(StringComparison.Ordinal) ?? 0;
#else
            return obj?.GetHashCode() ?? 0;
#endif
            // ReSharper restore ConstantConditionalAccessQualifier
        }

        /// <summary>
        /// Indicates whether the current <see cref="OrdinalStringComparer"/> object is equal to another <see cref="OrdinalStringComparer"/> object.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>`true`.</returns>
        public bool Equals(OrdinalStringComparer other) => true;

        /// <summary>
        /// Indicates whether the current <see cref="OrdinalStringComparer"/> object is equal to another comparer object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true` if <paramref name="obj"/> is of type <see cref="OrdinalStringComparer"/>; otherwise, `false`.</returns>
        public override bool Equals(object? obj) => obj is OrdinalStringComparer;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() => typeof(OrdinalStringComparer).GetHashCode();
    }
#pragma warning restore CA2231, CA1815
}
