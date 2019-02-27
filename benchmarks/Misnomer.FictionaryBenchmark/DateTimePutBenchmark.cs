using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Key = System.DateTime;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class DateTimePutBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private Dictionary<Key, int> _dictionary;
        private Fictionary<Key, int, GenericEqualityComparerObject<Key>> _fictionaryConcreteReference;
        private Fictionary<Key, int, GenericEqualityComparer<Key>> _fictionaryConcreteValue;
        private Fictionary<Key, int, EqualityComparer<Key>> _fictionaryStandardPolymorphic;
        private Fictionary<Key, int, IEqualityComparer<Key>> _fictionaryVirtual;

        private static int PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                int firstValue = (7 + 1723 * i) % Count;
                Key firstKey = Key.FromBinary(firstValue);
                if (!dictionary.ContainsKey(firstKey))
                    dictionary.Add(firstKey, firstValue);

                int secondValue = (13 + 853 * i) % Count;
                Key secondKey = Key.FromBinary(secondValue);
                dictionary[secondKey] = secondValue;
            }

            return dictionary.Count;
        }

        #region GlobalSetup

        [GlobalSetup(Target = nameof(DictionaryConcreteValue))]
        public void GlobalSetupDictionaryConcreteValue()
        {
            _dictionary = new Dictionary<Key, int>(new GenericEqualityComparer<Key>());
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            _fictionaryConcreteValue =
                new Fictionary<Key, int, GenericEqualityComparer<Key>>(new GenericEqualityComparer<Key>());
        }

        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            _dictionary = new Dictionary<Key, int>(GenericEqualityComparerObject<Key>.Default);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteReference))]
        public void GlobalSetupFictionaryConcreteReference()
        {
            _fictionaryConcreteReference = new Fictionary<Key, int, GenericEqualityComparerObject<Key>>(
                GenericEqualityComparerObject<Key>.Default);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualValue))]
        public void GlobalSetupDictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new GenericEqualityComparer<Key>();
            _dictionary = new Dictionary<Key, int>(comparer);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualValue))]
        public void GlobalSetupFictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new GenericEqualityComparer<Key>();
            _fictionaryVirtual = new Fictionary<Key, int, IEqualityComparer<Key>>(comparer);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualReference))]
        public void GlobalSetupDictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = GenericEqualityComparerObject<Key>.Default;
            _dictionary = new Dictionary<Key, int>(comparer);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualReference))]
        public void GlobalSetupFictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = GenericEqualityComparerObject<Key>.Default;
            _fictionaryVirtual = new Fictionary<Key, int, IEqualityComparer<Key>>(comparer);
        }

        [GlobalSetup(Target = nameof(DictionaryStandardPolymorphic))]
        public void GlobalSetupDictionaryStandardPolymorphic()
        {
            _dictionary = new Dictionary<Key, int>(EqualityComparer<Key>.Default);
        }

        [GlobalSetup(Target = nameof(FictionaryStandardPolymorphic))]
        public void GlobalSetupFictionaryStandardPolymorphic()
        {
            _fictionaryStandardPolymorphic =
                new Fictionary<Key, int, EqualityComparer<Key>>(EqualityComparer<Key>.Default);
        }

        [GlobalSetup(Target = nameof(DictionaryDefault))]
        public void GlobalSetupDictionaryDefault()
        {
            _dictionary = new Dictionary<Key, int>();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _dictionary = null;
            _fictionaryConcreteReference = null;
            _fictionaryConcreteValue = null;
            _fictionaryVirtual = null;
        }

        #endregion

        #region Benchmarks

        [Benchmark]
        public int DictionaryConcreteValue()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            return PopulateDictionary(_fictionaryConcreteValue);
        }

        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteReference()
        {
            return PopulateDictionary(_fictionaryConcreteReference);
        }

        [Benchmark]
        public int DictionaryVirtualValue()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualValue()
        {
            return PopulateDictionary(_fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryVirtualReference()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualReference()
        {
            return PopulateDictionary(_fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryStandardPolymorphic()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryStandardPolymorphic()
        {
            return PopulateDictionary(_fictionaryStandardPolymorphic);
        }

        [Benchmark]
        public int DictionaryDefault()
        {
            return PopulateDictionary(_dictionary);
        }

        #endregion
    }
}
