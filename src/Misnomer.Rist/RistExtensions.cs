using System;
using System.Collections.Generic;

namespace Misnomer.Extensions
{
    public static class RistExtensions
    {
        /// <summary>
        /// Creates a <see cref="Rist{T}" /> from an <see cref="IEnumerable{T}" />.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}" /> to create a <see cref="Rist{T}" /> from.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>A <see cref="Rist{T}" /> that contains elements from the input sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static Rist<TSource> ToRist<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new Rist<TSource>(source);
        }
    }
}
