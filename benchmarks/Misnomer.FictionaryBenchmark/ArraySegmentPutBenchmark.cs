using System.Collections.Generic;
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
            for (int i = 0; i != Count; ++i)
            {
                int firstValue = (7 + 1723 * i) % Count;
                Key firstKey = new(s_array, firstValue, Count - firstValue);
                if (!dictionary!.ContainsKey(firstKey))
                    dictionary.Add(firstKey, firstValue);

                int secondValue = (13 + 853 * i) % Count;
                Key secondKey = new(s_array, secondValue, Count - secondValue);
                dictionary[secondKey] = secondValue;
            }

            return dictionary!.Count;
        }

        #region Benchmarks

        [Benchmark]
        public int DictionaryConcreteValue()
        {
            Dictionary<Key, int> dictionary = new(Count, new ArraySegmentEqualityComparer<int>());
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            Fictionary<Key, int, ArraySegmentEqualityComparer<int>> fictionaryConcreteValue = new(
                Count, new ArraySegmentEqualityComparer<int>());
            return PopulateDictionary(fictionaryConcreteValue);
        }

        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            Dictionary<Key, int> dictionary = new(Count, ArraySegmentComparerObject<int>.Default);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteReference()
        {
            Fictionary<Key, int, ArraySegmentComparerObject<int>> fictionaryConcreteReference = new(
                Count, ArraySegmentComparerObject<int>.Default);
            return PopulateDictionary(fictionaryConcreteReference);
        }

        [Benchmark]
        public int DictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            Dictionary<Key, int> dictionary = new(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            Fictionary<Key, int, IEqualityComparer<Key>> fictionaryVirtual = new(Count, comparer);
            return PopulateDictionary(fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
            Dictionary<Key, int> dictionary = new(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
            Fictionary<Key, int, IEqualityComparer<Key>> fictionaryVirtual = new(Count, comparer);
            return PopulateDictionary(fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryStandardPolymorphic()
        {
            Dictionary<Key, int> dictionary = new(Count, EqualityComparer<Key>.Default);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryStandardPolymorphic()
        {
            Fictionary<Key, int, EqualityComparer<Key>> fictionaryStandardPolymorphic =
                new(Count, EqualityComparer<Key>.Default);
            return PopulateDictionary(fictionaryStandardPolymorphic);
        }

        [Benchmark]
        public int DictionaryDefault()
        {
            Dictionary<Key, int> dictionary = new(Count);
            return PopulateDictionary(dictionary);
        }

        #endregion
    }
}
