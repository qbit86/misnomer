using System;
using System.Buffers;
using System.Collections.Generic;

namespace Misnomer
{
    public static class DefaultFictionary
    {
        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> Create<TKey, TValue>(
            IEnumerable<KeyValuePair<TKey, TValue>> collection)
            where TKey : IEquatable<TKey>
        {
            return new Fictionary<TKey, TValue, GenericEqualityComparer<TKey>>(collection,
                new GenericEqualityComparer<TKey>());
        }
    }

    public static class DefaultFictionary<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> Create()
        {
            return new Fictionary<TKey, TValue, GenericEqualityComparer<TKey>>(0, new GenericEqualityComparer<TKey>());
        }

        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> Create(int capacity)
        {
            return new Fictionary<TKey, TValue, GenericEqualityComparer<TKey>>(capacity,
                new GenericEqualityComparer<TKey>());
        }
#pragma warning restore CA1000 // Do not declare static members on generic types
    }

    public static class Fictionary
    {
        public static Fictionary<TKey, TValue, TKeyComparer> Create<TKey, TValue, TKeyComparer>(
            IEnumerable<KeyValuePair<TKey, TValue>> collection, TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(collection, comparer);
        }

        public static Fictionary<TKey, TValue, TKeyComparer> Create<TKey, TValue, TKeyComparer>(
            IDictionary<TKey, TValue> dictionary, TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(dictionary, comparer);
        }
    }

    public static class Fictionary<TKey, TValue>
    {
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static Fictionary<TKey, TValue, TKeyComparer> Create<TKeyComparer>(TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(0, comparer);
        }

        public static Fictionary<TKey, TValue, TKeyComparer> Create<TKeyComparer>(int capacity, TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(capacity, comparer);
        }
#pragma warning restore CA1000 // Do not declare static members on generic types
    }

    // https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Collections/Generic/Dictionary.cs

    // ReSharper disable UnusedTypeParameter
    /// <summary>
    /// Represents a generic collection of key/value pairs.
    /// Enables pooling instances of inner array of dictionary entries.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <typeparam name="TKeyComparer">The type of the comparer that is used to determine equality of keys for the dictionary.</typeparam>
    public sealed partial class Fictionary<TKey, TValue, TKeyComparer> : IDisposable
        where TKeyComparer : IEqualityComparer<TKey>
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
