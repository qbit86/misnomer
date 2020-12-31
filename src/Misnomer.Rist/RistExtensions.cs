using System;
using System.Collections.Generic;

namespace Misnomer.Extensions
{
    public static class RistExtensions
    {
        /// <summary>
        /// Creates a <see cref="Rist{T}"/> from an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="Rist{T}"/> from.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <returns>A <see cref="Rist{T}"/> that contains elements from the input sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static Rist<TSource> ToRist<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return new Rist<TSource>(source);
        }

        /// <summary>
        /// Extracts the internal array and replaces it with a zero length array.
        /// </summary>
        /// <param name="rist">The <see cref="Rist{T}"/> from which to extract the array.</param>
        /// <param name="segment">When this method returns,
        /// contains the array segment retrieved from the underlying internal array.
        /// </param>
        public static void MoveToArray<T>(this Rist<T> rist, out ArraySegment<T> segment)
        {
            if (rist is null)
                throw new ArgumentNullException(nameof(rist));

            int length = rist._size;
            T[] array = rist.MoveToArray();
            segment = new ArraySegment<T>(array, 0, length);
        }
    }
}
