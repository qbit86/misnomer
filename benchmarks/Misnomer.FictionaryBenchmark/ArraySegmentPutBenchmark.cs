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

        private Dictionary<Key, int> _dictionary;
        private Fictionary<Key, int, ArraySegmentComparerObject<int>> _fictionaryConcreteReference;
        private Fictionary<Key, int, ArraySegmentEqualityComparer<int>> _fictionaryConcreteValue;
        private Fictionary<Key, int, EqualityComparer<Key>> _fictionaryStandardPolymorphic;
        private Fictionary<Key, int, IEqualityComparer<Key>> _fictionaryVirtual;

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

        #region GlobalSetup

        [GlobalSetup(Target = nameof(DictionaryConcreteValue))]
        public void GlobalSetupDictionaryConcreteValue()
        {
            _dictionary = new Dictionary<Key, int>(new ArraySegmentEqualityComparer<int>());
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            _fictionaryConcreteValue =
                new Fictionary<Key, int, ArraySegmentEqualityComparer<int>>(new ArraySegmentEqualityComparer<int>());
        }

        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            _dictionary = new Dictionary<Key, int>(ArraySegmentComparerObject<int>.Default);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteReference))]
        public void GlobalSetupFictionaryConcreteReference()
        {
            _fictionaryConcreteReference = new Fictionary<Key, int, ArraySegmentComparerObject<int>>(
                ArraySegmentComparerObject<int>.Default);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualValue))]
        public void GlobalSetupDictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            _dictionary = new Dictionary<Key, int>(comparer);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualValue))]
        public void GlobalSetupFictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            _fictionaryVirtual = new Fictionary<Key, int, IEqualityComparer<Key>>(comparer);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualReference))]
        public void GlobalSetupDictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
            _dictionary = new Dictionary<Key, int>(comparer);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualReference))]
        public void GlobalSetupFictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
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
            _fictionaryStandardPolymorphic = null;
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
