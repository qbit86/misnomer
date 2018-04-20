// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;

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
