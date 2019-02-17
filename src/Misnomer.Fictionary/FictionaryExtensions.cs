using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Misnomer.Extensions
{
    /// <summary>
    /// Provides a set of initialization methods for instances of the <see cref="Fictionary{TKey, TValue, TKeyComparer}" /> class.
    /// </summary>
    public static class FictionaryExtensions
    {
        /// <summary>
        /// Creates a new <see cref="Fictionary{TKey, TValue, TKeyComparer}" /> that contains the specified items
        /// and uses the <see cref="GenericEqualityComparer{TKey}" />.
        /// </summary>
        /// <param name="source">The collection whose elements are copied to the new <see cref="Fictionary{TKey, TValue, TKeyComparer}" />.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <returns>A new <see cref="Fictionary{TKey, TValue, TKeyComparer}" /> that contains the specified items
        /// and uses the <see cref="GenericEqualityComparer{TKey}" />.</returns>
        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> ToFictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source)
            where TKey : IEquatable<TKey>
        {
            return new Fictionary<TKey, TValue, GenericEqualityComparer<TKey>>(source,
                new GenericEqualityComparer<TKey>());
        }

        /// <summary>
        /// Creates a new <see cref="Fictionary{TKey, TValue, TKeyComparer}" /> that contains the specified items and uses the specified key comparer.
        /// </summary>
        /// <param name="source">The collection whose elements are copied to the new <see cref="Fictionary{TKey, TValue, TKeyComparer}" />.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}" /> implementation to use to compare keys for equality.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
        /// <returns>A new <see cref="Fictionary{TKey, TValue, TKeyComparer}" /> that contains the specified items and uses the specified comparer.</returns>
        public static Fictionary<TKey, TValue, TKeyComparer> ToFictionary<TKey, TValue, TKeyComparer>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source, TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(source, comparer);
        }

        /// <summary>
        /// Creates a new <see cref="Fictionary{TKey, TValue, TKeyComparer}" /> that contains the specified items and uses the specified key comparer.
        /// </summary>
        /// <param name="source">The <see cref="IDictionary{TKey, TValue}" /> whose elements are copied to the new <see cref="Fictionary{TKey, TValue, TKeyComparer}" />.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}" /> implementation to use to compare keys for equality.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
        /// <returns>A new <see cref="Fictionary{TKey, TValue, TKeyComparer}" /> that contains the specified items and uses the specified comparer.</returns>
        public static Fictionary<TKey, TValue, TKeyComparer> ToFictionary<TKey, TValue, TKeyComparer>(
            this IDictionary<TKey, TValue> source, TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(source, comparer);
        }

        public static Fictionary<TKey, TSource, GenericEqualityComparer<TKey>> ToFictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
            where TKey : IEquatable<TKey>
        {
            return source.ToFictionary(keySelector, new GenericEqualityComparer<TKey>());
        }

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

        public static Fictionary<TKey, TElement, GenericEqualityComparer<TKey>> ToFictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
            where TKey : IEquatable<TKey>
        {
            return source.ToFictionary(keySelector, elementSelector, new GenericEqualityComparer<TKey>());
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
