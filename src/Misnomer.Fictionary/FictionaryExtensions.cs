﻿using System;
using System.Collections.Generic;

namespace Misnomer.Extensions
{
    /// <summary>
    /// Provides a set of initialization methods for instances of the <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> class.
    /// </summary>
    public static class FictionaryExtensions
    {
        /// <summary>
        /// Creates a new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the specified items
        /// and uses the <see cref="GenericEqualityComparer{TKey}"/>.
        /// </summary>
        /// <param name="source">The collection whose elements are copied to the new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/>.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <returns>
        /// A new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the specified items
        /// and uses the <see cref="GenericEqualityComparer{TKey}"/>.
        /// </returns>
        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> ToFictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source)
            where TKey : IEquatable<TKey> =>
            new(source, new GenericEqualityComparer<TKey>());

        /// <summary>
        /// Creates a new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the specified items and uses the specified key comparer.
        /// </summary>
        /// <param name="source">The collection whose elements are copied to the new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/>.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}"/> implementation to use to compare keys for equality.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
        /// <returns>A new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the specified items and uses the specified comparer.</returns>
        public static Fictionary<TKey, TValue, TKeyComparer> ToFictionary<TKey, TValue, TKeyComparer>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source, TKeyComparer comparer)
            where TKey : notnull
            where TKeyComparer : IEqualityComparer<TKey> =>
            new(source, comparer);

        /// <summary>
        /// Creates a new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the specified items and uses the specified key comparer.
        /// </summary>
        /// <param name="source">The <see cref="IDictionary{TKey, TValue}"/> whose elements are copied to the new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/>.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}"/> implementation to use to compare keys for equality.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
        /// <returns>A new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the specified items and uses the specified comparer.</returns>
        public static Fictionary<TKey, TValue, TKeyComparer> ToFictionary<TKey, TValue, TKeyComparer>(
            this IDictionary<TKey, TValue> source, TKeyComparer comparer)
            where TKey : notnull
            where TKeyComparer : IEqualityComparer<TKey> =>
            new(source, comparer);

        /// <summary>
        /// Enumerates and transforms a sequence, and produces a <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> of its contents by using the <see cref="GenericEqualityComparer{TKey}"/>.
        /// </summary>
        /// <param name="source">The sequence to enumerate to generate the dictionary.</param>
        /// <param name="keySelector">The function that will produce the key for the dictionary from each sequence element.</param>
        /// <typeparam name="TSource">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the keys in the resulting dictionary.</typeparam>
        /// <returns>A new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the items in the specified sequence.</returns>
        public static Fictionary<TKey, TSource, GenericEqualityComparer<TKey>> ToFictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
            where TKey : IEquatable<TKey> =>
            source.ToFictionary(keySelector, new GenericEqualityComparer<TKey>());

        /// <summary>
        /// Enumerates and transforms a sequence, and produces a <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> of its contents by using the specified key comparer.
        /// </summary>
        /// <param name="source">The sequence to enumerate to generate the dictionary.</param>
        /// <param name="keySelector">The function that will produce the key for the dictionary from each sequence element.</param>
        /// <param name="comparer">The key comparer to use for the dictionary.</param>
        /// <typeparam name="TSource">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the keys in the resulting dictionary.</typeparam>
        /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
        /// <returns>A new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the items in the specified sequence.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is `null`;
        /// or <paramref name="keySelector"/> produces a key that is null.
        /// </exception>
        public static Fictionary<TKey, TSource, TKeyComparer> ToFictionary<TSource, TKey, TKeyComparer>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            TKeyComparer comparer)
            where TKey : notnull
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

            Fictionary<TKey, TSource, TKeyComparer> d = new(capacity, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), element);

            return d;
        }

        /// <summary>
        /// Enumerates and transforms a sequence, and produces a <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> of its contents by using the <see cref="GenericEqualityComparer{TKey}"/>.
        /// </summary>
        /// <param name="source">The sequence to enumerate to generate the dictionary.</param>
        /// <param name="keySelector">The function that will produce the key for the dictionary from each sequence element.</param>
        /// <param name="elementSelector">The function that will produce the value for the dictionary from each sequence element.</param>
        /// <typeparam name="TSource">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the keys in the resulting dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the resulting dictionary.</typeparam>
        /// <returns>A new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the items in the specified sequence.</returns>
        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> ToFictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector)
            where TKey : IEquatable<TKey> =>
            source.ToFictionary(keySelector, elementSelector, new GenericEqualityComparer<TKey>());

        /// <summary>
        /// Enumerates and transforms a sequence, and produces a <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> of its contents by using the specified key comparer.
        /// </summary>
        /// <param name="source">The sequence to enumerate to generate the dictionary.</param>
        /// <param name="keySelector">The function that will produce the key for the dictionary from each sequence element.</param>
        /// <param name="elementSelector">The function that will produce the value for the dictionary from each sequence element.</param>
        /// <param name="comparer">The key comparer to use for the dictionary.</param>
        /// <typeparam name="TSource">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the keys in the resulting dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the resulting dictionary.</typeparam>
        /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
        /// <returns>A new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that contains the items in the specified sequence.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is `null`;
        /// or <paramref name="keySelector"/> produces a key that is null.
        /// </exception>
        public static Fictionary<TKey, TValue, TKeyComparer> ToFictionary<TSource, TKey, TValue, TKeyComparer>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector,
            TKeyComparer comparer)
            where TKey : notnull
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
                    return new Fictionary<TKey, TValue, TKeyComparer>(comparer);

                if (collection is TSource[] array)
                    return ToFictionary(array, keySelector, elementSelector, comparer);

                if (collection is List<TSource> list)
                    return ToFictionary(list, keySelector, elementSelector, comparer);
            }

            Fictionary<TKey, TValue, TKeyComparer> d = new(capacity, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), elementSelector(element));

            return d;
        }

        private static Fictionary<TKey, TSource, TKeyComparer> ToFictionary<TSource, TKey, TKeyComparer>(
            TSource[] source,
            Func<TSource, TKey> keySelector,
            TKeyComparer comparer)
            where TKey : notnull
            where TKeyComparer : IEqualityComparer<TKey>
        {
            Fictionary<TKey, TSource, TKeyComparer> d = new(source.Length, comparer);
            for (int i = 0; i < source.Length; ++i)
                d.Add(keySelector(source[i]), source[i]);

            return d;
        }

        private static Fictionary<TKey, TSource, TKeyComparer> ToFictionary<TSource, TKey, TKeyComparer>(
            List<TSource> source,
            Func<TSource, TKey> keySelector,
            TKeyComparer comparer)
            where TKey : notnull
            where TKeyComparer : IEqualityComparer<TKey>
        {
            Fictionary<TKey, TSource, TKeyComparer> d = new(source.Count, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), element);

            return d;
        }

        private static Fictionary<TKey, TValue, TKeyComparer> ToFictionary<TSource, TKey, TValue, TKeyComparer>(
            TSource[] source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector,
            TKeyComparer comparer)
            where TKey : notnull
            where TKeyComparer : IEqualityComparer<TKey>
        {
            Fictionary<TKey, TValue, TKeyComparer> d = new(source.Length, comparer);
            for (int i = 0; i < source.Length; ++i)
                d.Add(keySelector(source[i]), elementSelector(source[i]));

            return d;
        }

        private static Fictionary<TKey, TValue, TKeyComparer> ToFictionary<TSource, TKey, TValue, TKeyComparer>(
            List<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector,
            TKeyComparer comparer)
            where TKey : notnull
            where TKeyComparer : IEqualityComparer<TKey>
        {
            Fictionary<TKey, TValue, TKeyComparer> d = new(source.Count, comparer);
            foreach (TSource element in source)
                d.Add(keySelector(element), elementSelector(element));

            return d;
        }
    }
}
