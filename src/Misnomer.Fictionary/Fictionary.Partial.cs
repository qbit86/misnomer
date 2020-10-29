using System;
using System.Buffers;
using System.Collections.Generic;

namespace Misnomer
{
    /// <summary>
    /// Provides a set of initialization methods for instances of the <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> class
    /// with <see cref="GenericEqualityComparer{TKey}"/> used as the key comparer.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public static class DefaultFictionary<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
#pragma warning disable CA1000 // Do not declare static members on generic types
        /// <summary>
        /// Creates an empty <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that uses the <see cref="GenericEqualityComparer{TKey}"/>.
        /// </summary>
        /// <returns>An empty <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that uses the <see cref="GenericEqualityComparer{TKey}"/>.</returns>
        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> Create()
        {
            return new Fictionary<TKey, TValue, GenericEqualityComparer<TKey>>(0, new GenericEqualityComparer<TKey>());
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> class that is empty,
        /// has the specified initial capacity, and uses the <see cref="GenericEqualityComparer{TKey}"/>.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> can contain.</param>
        /// <returns>
        /// A new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that has the specified initial capacity,
        /// and uses the <see cref="GenericEqualityComparer{TKey}"/>.
        /// </returns>
        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> Create(int capacity)
        {
            return new Fictionary<TKey, TValue, GenericEqualityComparer<TKey>>(capacity,
                new GenericEqualityComparer<TKey>());
        }
#pragma warning restore CA1000 // Do not declare static members on generic types
    }

    /// <summary>
    /// Provides a set of initialization methods for instances of the <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> class.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public static class Fictionary<TKey, TValue>
    {
#pragma warning disable CA1000 // Do not declare static members on generic types
        /// <summary>
        /// Creates an empty <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that uses the specified comparer.
        /// </summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}"/> implementation to use to compare keys for equality.</param>
        /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
        /// <returns>An empty <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that uses the specified comparer" />.</returns>
        public static Fictionary<TKey, TValue, TKeyComparer> Create<TKeyComparer>(TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(0, comparer);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> class that is empty,
        /// has the specified initial capacity, and uses the specified comparer.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> can contain.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}"/> implementation to use to compare keys for equality.</param>
        /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
        /// <returns>
        /// A new <see cref="Fictionary{TKey, TValue, TKeyComparer}"/> that has the specified initial capacity,
        /// and uses the specified comparer.
        /// </returns>
        public static Fictionary<TKey, TValue, TKeyComparer> Create<TKeyComparer>(int capacity, TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(capacity, comparer);
        }
#pragma warning restore CA1000 // Do not declare static members on generic types
    }

    // https://github.com/dotnet/runtime/blob/e9b7afc2d67f42e1bfeabf6f67421290e614b97a/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/Dictionary.cs

    // ReSharper disable UnusedTypeParameter
    /// <summary>
    /// Represents a generic collection of key/value pairs with concretely typed key comparer.
    /// Avoids virtual calls to the key comparer.
    /// Enables pooling instances of inner array of dictionary entries.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
    public sealed partial class Fictionary<TKey, TValue, TKeyComparer> : IDisposable
        where TKeyComparer : IEqualityComparer<TKey> where TKey : notnull
    {
        private static ArrayPool<Entry> Pool => ArrayPool<Entry>.Shared;

        /// <summary>
        /// Returns the internal array to the pool.
        /// </summary>
        public void Dispose()
        {
            ++_version;
            _count = 0;
            _freeList = 0;
            _freeCount = 0;
            _keys = null;
            _values = null;
            _buckets = null;

            if (_entries != null)
            {
                Pool.Return(_entries, true);
                _entries = null;
            }
        }
    }
    // ReSharper restore UnusedTypeParameter
}
