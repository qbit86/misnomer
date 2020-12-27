using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Key = System.DateTime;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class DateTimePutBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private static int PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            for (int i = 0; i != Count; ++i)
            {
                int firstValue = (7 + 1723 * i) % Count;
                var firstKey = Key.FromBinary(firstValue);
                if (!dictionary!.ContainsKey(firstKey))
                    dictionary.Add(firstKey, firstValue);

                int secondValue = (13 + 853 * i) % Count;
                var secondKey = Key.FromBinary(secondValue);
                dictionary[secondKey] = secondValue;
            }

            return dictionary!.Count;
        }

        #region Benchmarks

        [Benchmark]
        public int DictionaryConcreteValue()
        {
            Dictionary<Key, int> dictionary = new(Count, new GenericEqualityComparer<Key>());
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            Fictionary<Key, int, GenericEqualityComparer<Key>> fictionaryConcreteValue =
                new(Count, new GenericEqualityComparer<Key>());
            return PopulateDictionary(fictionaryConcreteValue);
        }

        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            Dictionary<Key, int> dictionary = new(Count, GenericEqualityComparerObject<Key>.Default);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteReference()
        {
            using Fictionary<Key, int, GenericEqualityComparerObject<Key>> fictionaryConcreteReference =
                new(Count, GenericEqualityComparerObject<Key>.Default);
            return PopulateDictionary(fictionaryConcreteReference);
        }

        [Benchmark]
        public int DictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new GenericEqualityComparer<Key>();
            Dictionary<Key, int> dictionary = new(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new GenericEqualityComparer<Key>();
            using Fictionary<Key, int, IEqualityComparer<Key>> fictionaryVirtual = new(Count, comparer);
            return PopulateDictionary(fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = GenericEqualityComparerObject<Key>.Default;
            Dictionary<Key, int> dictionary = new(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = GenericEqualityComparerObject<Key>.Default;
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
