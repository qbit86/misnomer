using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
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

            var d = new Fictionary<TKey, TSource, TKeyComparer>(capacity, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), element);

            return d;
        }

        public static Fictionary<TKey, TElement, TKeyComparer> ToFictionary<TSource, TKey, TElement, TKeyComparer>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));

            int capacity = 0;
            if (source is ICollection<TSource> collection)
            {
                capacity = collection.Count;
                if (capacity == 0)
                    return new Fictionary<TKey, TElement, TKeyComparer>(comparer);

                if (collection is TSource[] array)
                    return ToFictionary(array, keySelector, elementSelector, comparer);

                if (collection is List<TSource> list)
                    return ToFictionary(list, keySelector, elementSelector, comparer);
            }

            var d = new Fictionary<TKey, TElement, TKeyComparer>(capacity, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), elementSelector(element));

            return d;
        }

        private static Fictionary<TKey, TSource, TKeyComparer> ToFictionary<TSource, TKey, TKeyComparer>(
            TSource[] source,
            Func<TSource, TKey> keySelector,
            TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            var d = new Fictionary<TKey, TSource, TKeyComparer>(source.Length, comparer);
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
            var d = new Fictionary<TKey, TSource, TKeyComparer>(source.Count, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), element);

            return d;
        }

        private static Fictionary<TKey, TElement, TKeyComparer> ToFictionary<TSource, TKey, TElement, TKeyComparer>(
            TSource[] source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            var d = new Fictionary<TKey, TElement, TKeyComparer>(source.Length, comparer);
            for (int i = 0; i < source.Length; ++i)
                d.Add(keySelector(source[i]), elementSelector(source[i]));

            return d;
        }

        private static Fictionary<TKey, TElement, TKeyComparer> ToFictionary<TSource, TKey, TElement, TKeyComparer>(
            List<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            var d = new Fictionary<TKey, TElement, TKeyComparer>(source.Count, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), elementSelector(element));

            return d;
        }
    }
}
