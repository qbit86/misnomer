using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Misnomer.Extensions
{
    public static class RistExtensions
    {
        public static Rist<TSource> ToRist<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new Rist<TSource>(source);
        }
    }
}
