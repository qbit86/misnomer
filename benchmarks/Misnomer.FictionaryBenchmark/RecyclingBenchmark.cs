using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Key = System.DateTimeOffset;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class RecyclingBenchmark
    {
        private const int Count = 13;

        private readonly Dictionary<Key, long>[] _dictionaries = new Dictionary<Key, long>[Count];

        private readonly Fictionary<Key, long, GenericEqualityComparer<Key>>[] _fictionaries =
            new Fictionary<Key, long, GenericEqualityComparer<Key>>[Count];

        private static int PopulateDictionaries<TDictionary>(TDictionary[] dictionaries)
            where TDictionary : IDictionary<Key, long>
        {
            Debug.Assert(dictionaries != null, "dictionaries != null");

            int count = dictionaries.Length;
            for (int upper = 1; upper <= count; ++upper)
            for (int i = 0; i < upper; ++i)
            {
                TDictionary d = dictionaries[i];
                Debug.Assert(d != null, "d != null");
                int newItemCount = Math.Max(1, d.Count);
                for (int k = 0; k != newItemCount; ++k)
                {
                    long value = (upper << 24) | (i << 16) | k;
                    d[DateTimeOffset.FromFileTime(value)] = value;
                }
            }

            return dictionaries.Length;
        }

        #region Benchmarks

        [Benchmark(Baseline = true)]
        public int Dictionary()
        {
            int count = _dictionaries.Length;
            for (int i = 0; i != count; ++i)
                _dictionaries[i] = new Dictionary<DateTimeOffset, long>();

            return PopulateDictionaries(_dictionaries);
        }

        [Benchmark]
        public int Fictionary()
        {
            int count = _fictionaries.Length;
            for (int i = 0; i != count; ++i)
                _fictionaries[i] = DefaultFictionary<DateTimeOffset, long>.Create();

            return PopulateDictionaries(_fictionaries);
        }

        #endregion
    }
}
