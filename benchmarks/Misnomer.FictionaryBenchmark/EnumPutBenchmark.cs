using System.Collections.Generic;
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
            for (int i = 0; i != Count; ++i)
            {
                int firstValue = (7 + 1723 * i) % Count;
                var firstKey = (Key)firstValue;
                if (!dictionary!.ContainsKey(firstKey))
                    dictionary.Add(firstKey, firstValue);

                int secondValue = (13 + 853 * i) % Count;
                var secondKey = (Key)secondValue;
                dictionary[secondKey] = secondValue;
            }

            return dictionary!.Count;
        }

        #region Benchmarks

        [Benchmark]
        public int DictionaryConcreteValue()
        {
            Dictionary<Key, int> dictionary = new(Count, new EnumEqualityComparer());
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            using Fictionary<Key, int, EnumEqualityComparer> fictionaryConcreteValue =
                new(Count, new EnumEqualityComparer());
            return PopulateDictionary(fictionaryConcreteValue);
        }

        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            Dictionary<Key, int> dictionary = new(Count, EnumEqualityComparerObject.Default);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteReference()
        {
            using Fictionary<Key, int, EnumEqualityComparerObject> fictionaryConcreteReference =
                new(Count, EnumEqualityComparerObject.Default);
            return PopulateDictionary(fictionaryConcreteReference);
        }

        [Benchmark]
        public int DictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new EnumEqualityComparer();
            Dictionary<Key, int> dictionary = new(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new EnumEqualityComparer();
            using Fictionary<Key, int, IEqualityComparer<Key>> fictionaryVirtual = new(Count, comparer);
            return PopulateDictionary(fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = EnumEqualityComparerObject.Default;
            Dictionary<Key, int> dictionary = new(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = EnumEqualityComparerObject.Default;
            using Fictionary<Key, int, IEqualityComparer<Key>> fictionaryVirtual = new(Count, comparer);
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
            using Fictionary<Key, int, EqualityComparer<Key>> fictionaryStandardPolymorphic =
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
