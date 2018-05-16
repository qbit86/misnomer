// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;

namespace Misnomer.Extensions
{
    public static class FictionaryExtensions
    {
        public static Fictionary<TKey, TSource, TKeyComparer> ToFictionary<TSource, TKey, TKeyComparer>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            int capacity = 0;
            if (source is ICollection<TSource> collection)
            {
                capacity = collection.Count;
                if (capacity == 0)
                    return new Fictionary<TKey, TSource, TKeyComparer>(comparer);

                if (collection is TSource[] array)
                    return ToFictionary(array, keySelector, comparer);

                if (collection is List<TSource> list)
                    return ToFictionary(list, keySelector, comparer);
            }

            Fictionary<TKey, TSource, TKeyComparer> d = new Fictionary<TKey, TSource, TKeyComparer>(capacity, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), element);

            return d;
        }

        private static Fictionary<TKey, TSource, TKeyComparer> ToFictionary<TSource, TKey, TKeyComparer>(
            TSource[] source,
            Func<TSource, TKey> keySelector,
            TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            Fictionary<TKey, TSource, TKeyComparer> d =
                new Fictionary<TKey, TSource, TKeyComparer>(source.Length, comparer);
            for (int i = 0; i < source.Length; ++i)
                d.Add(keySelector(source[i]), source[i]);

            return d;
        }

        private static Fictionary<TKey, TSource, TKeyComparer> ToFictionary<TSource, TKey, TKeyComparer>(
            List<TSource> source,
            Func<TSource, TKey> keySelector,
            TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            Fictionary<TKey, TSource, TKeyComparer> d =
                new Fictionary<TKey, TSource, TKeyComparer>(source.Count, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), element);

            return d;
        }
    }
}
