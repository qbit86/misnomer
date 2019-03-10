using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Key = System.ArraySegment<int>;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class ArraySegmentPutBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private static readonly int[] s_array = new int[Count];

        private static int PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                int firstValue = (7 + 1723 * i) % Count;
                var firstKey = new Key(s_array, firstValue, Count - firstValue);
                if (!dictionary.ContainsKey(firstKey))
                    dictionary.Add(firstKey, firstValue);

                int secondValue = (13 + 853 * i) % Count;
                var secondKey = new Key(s_array, secondValue, Count - secondValue);
                dictionary[secondKey] = secondValue;
            }

            return dictionary.Count;
        }

        #region Benchmarks

        [Benchmark]
        public int DictionaryConcreteValue()
        {
            var dictionary = new Dictionary<Key, int>(new ArraySegmentEqualityComparer<int>());
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            var fictionaryConcreteValue =
                new Fictionary<Key, int, ArraySegmentEqualityComparer<int>>(new ArraySegmentEqualityComparer<int>());
            return PopulateDictionary(fictionaryConcreteValue);
        }

        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            var dictionary = new Dictionary<Key, int>(ArraySegmentComparerObject<int>.Default);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteReference()
        {
            var fictionaryConcreteReference = new Fictionary<Key, int, ArraySegmentComparerObject<int>>(
                ArraySegmentComparerObject<int>.Default);
            return PopulateDictionary(fictionaryConcreteReference);
        }

        [Benchmark]
        public int DictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            var dictionary = new Dictionary<Key, int>(comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            var fictionaryVirtual = new Fictionary<Key, int, IEqualityComparer<Key>>(comparer);
            return PopulateDictionary(fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
            var dictionary = new Dictionary<Key, int>(comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
            var fictionaryVirtual = new Fictionary<Key, int, IEqualityComparer<Key>>(comparer);
            return PopulateDictionary(fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryStandardPolymorphic()
        {
            var dictionary = new Dictionary<Key, int>(EqualityComparer<Key>.Default);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryStandardPolymorphic()
        {
            var fictionaryStandardPolymorphic =
                new Fictionary<Key, int, EqualityComparer<Key>>(EqualityComparer<Key>.Default);
            return PopulateDictionary(fictionaryStandardPolymorphic);
        }

        [Benchmark]
        public int DictionaryDefault()
        {
            var dictionary = new Dictionary<Key, int>();
            return PopulateDictionary(dictionary);
        }

        #endregion
    }
}
