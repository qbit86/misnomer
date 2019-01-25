using System;
using System.Collections.Generic;

namespace Misnomer
{
    public static class DefaultFictionary<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> Create()
        {
            return new Fictionary<TKey, TValue, GenericEqualityComparer<TKey>>(0, new GenericEqualityComparer<TKey>());
        }

        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> Create(int capacity)
        {
            return new Fictionary<TKey, TValue, GenericEqualityComparer<TKey>>(capacity,
                new GenericEqualityComparer<TKey>());
        }

        public static Fictionary<TKey, TValue, GenericEqualityComparer<TKey>> Create(
            IEnumerable<KeyValuePair<TKey, TValue>> collection)
        {
            return new Fictionary<TKey, TValue, GenericEqualityComparer<TKey>>(collection,
                new GenericEqualityComparer<TKey>());
        }
    }

    public static class Fictionary<TKey, TValue>
    {
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

        public static Fictionary<TKey, TValue, TKeyComparer> Create<TKeyComparer>(
            IEnumerable<KeyValuePair<TKey, TValue>> collection, TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(collection, comparer);
        }
    }

    // ReSharper disable UnusedTypeParameter
    public sealed partial class Fictionary<TKey, TValue, TKeyComparer>
        where TKeyComparer : IEqualityComparer<TKey>
    {
    }
    // ReSharper restore UnusedTypeParameter
}
