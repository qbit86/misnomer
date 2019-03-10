using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Key = System.ConsoleColor;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class EnumPutBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private static int PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                int firstValue = (7 + 1723 * i) % Count;
                var firstKey = (Key)firstValue;
                if (!dictionary.ContainsKey(firstKey))
                    dictionary.Add(firstKey, firstValue);

                int secondValue = (13 + 853 * i) % Count;
                var secondKey = (Key)secondValue;
                dictionary[secondKey] = secondValue;
            }

            return dictionary.Count;
        }

        #region Benchmarks

        [Benchmark]
        public int DictionaryConcreteValue()
        {
            var dictionary = new Dictionary<Key, int>(Count, new EnumEqualityComparer());
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            var fictionaryConcreteValue = new Fictionary<Key, int, EnumEqualityComparer>(
                Count, new EnumEqualityComparer());
            return PopulateDictionary(fictionaryConcreteValue);
        }

        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            var dictionary = new Dictionary<Key, int>(Count, EnumEqualityComparerObject.Default);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteReference()
        {
            var fictionaryConcreteReference = new Fictionary<Key, int, EnumEqualityComparerObject>(
                Count, EnumEqualityComparerObject.Default);
            return PopulateDictionary(fictionaryConcreteReference);
        }

        [Benchmark]
        public int DictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new EnumEqualityComparer();
            var dictionary = new Dictionary<Key, int>(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new EnumEqualityComparer();
            var fictionaryVirtual = new Fictionary<Key, int, IEqualityComparer<Key>>(Count, comparer);
            return PopulateDictionary(fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = EnumEqualityComparerObject.Default;
            var dictionary = new Dictionary<Key, int>(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = EnumEqualityComparerObject.Default;
            var fictionaryVirtual = new Fictionary<Key, int, IEqualityComparer<Key>>(Count, comparer);
            return PopulateDictionary(fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryStandardPolymorphic()
        {
            var dictionary = new Dictionary<Key, int>(Count, EqualityComparer<Key>.Default);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryStandardPolymorphic()
        {
            var fictionaryStandardPolymorphic =
                new Fictionary<Key, int, EqualityComparer<Key>>(Count, EqualityComparer<Key>.Default);
            return PopulateDictionary(fictionaryStandardPolymorphic);
        }

        [Benchmark]
        public int DictionaryDefault()
        {
            var dictionary = new Dictionary<Key, int>(Count);
            return PopulateDictionary(dictionary);
        }

        #endregion
    }
}
