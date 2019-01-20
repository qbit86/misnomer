using System;
using System.Collections.Generic;

namespace Misnomer
{
    public static class Fictionary<TKey, TValue>
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

        public static Fictionary<TKey, TValue, TKeyComparer> Create<TKeyComparer>(int capacity, TKeyComparer comparer)
            where TKeyComparer : IEqualityComparer<TKey>
        {
            return new Fictionary<TKey, TValue, TKeyComparer>(capacity, comparer);
        }
    }

    // ReSharper disable UnusedTypeParameter
    public sealed partial class Fictionary<TKey, TValue, TKeyComparer>
        where TKeyComparer : IEqualityComparer<TKey>
    {
    }
    // ReSharper restore UnusedTypeParameter
}
