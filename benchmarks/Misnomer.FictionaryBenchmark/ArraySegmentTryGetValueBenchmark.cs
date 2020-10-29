using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Key = System.ArraySegment<int>;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class ArraySegmentTryGetValueBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private static readonly int[] s_array = new int[Count];

        private Dictionary<Key, int>? _dictionary;
        private Fictionary<Key, int, ArraySegmentComparerObject<int>>? _fictionaryConcreteReference;
        private Fictionary<Key, int, ArraySegmentEqualityComparer<int>>? _fictionaryConcreteValue;
        private Fictionary<Key, int, EqualityComparer<Key>>? _fictionaryStandardPolymorphic;
        private Fictionary<Key, int, IEqualityComparer<Key>>? _fictionaryVirtual;

        private int _trialSeed;

        private Key Trial { get; set; } = new Key(Array.Empty<int>());

        private static TDictionary PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                // 269th prime.
                int value = (5 + 1723 * i) % Count;
                var key = new Key(s_array, value, Count - value);
                dictionary[key] = value;
            }

            return dictionary;
        }

        #region GlobalSetup

        [GlobalSetup]
        public void GlobalSetup()
        {
            int value = (7 + 199 * _trialSeed) % Count;
            ++_trialSeed;
            Trial = new Key(s_array, value, Count - value);
        }

        [GlobalSetup(Target = nameof(DictionaryConcreteValue))]
        public void GlobalSetupDictionaryConcreteValue()
        {
            var dictionary = new Dictionary<Key, int>(new ArraySegmentEqualityComparer<int>());
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            var fictionary =
                new Fictionary<Key, int, ArraySegmentEqualityComparer<int>>(new ArraySegmentEqualityComparer<int>());
            _fictionaryConcreteValue = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            var dictionary = new Dictionary<Key, int>(ArraySegmentComparerObject<int>.Default);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteReference))]
        public void GlobalSetupFictionaryConcreteReference()
        {
            var fictionary =
                new Fictionary<Key, int, ArraySegmentComparerObject<int>>(ArraySegmentComparerObject<int>.Default);
            _fictionaryConcreteReference = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualValue))]
        public void GlobalSetupDictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            var dictionary = new Dictionary<Key, int>(comparer);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualValue))]
        public void GlobalSetupFictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            var fictionary = new Fictionary<Key, int, IEqualityComparer<Key>>(comparer);
            _fictionaryVirtual = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualReference))]
        public void GlobalSetupDictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
            var dictionary = new Dictionary<Key, int>(comparer);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualReference))]
        public void GlobalSetupFictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
            var fictionary = new Fictionary<Key, int, IEqualityComparer<Key>>(comparer);
            _fictionaryVirtual = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryStandardPolymorphic))]
        public void GlobalSetupDictionaryStandardPolymorphic()
        {
            var dictionary = new Dictionary<Key, int>(EqualityComparer<Key>.Default);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryStandardPolymorphic))]
        public void GlobalSetupFictionaryStandardPolymorphic()
        {
            var fictionary = new Fictionary<Key, int, EqualityComparer<Key>>(EqualityComparer<Key>.Default);
            _fictionaryStandardPolymorphic = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryDefault))]
        public void GlobalSetupDictionaryDefault()
        {
            var dictionary = new Dictionary<Key, int>();
            _dictionary = PopulateDictionary(dictionary);
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
        public bool DictionaryConcreteValue()
        {
            return _dictionary!.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryConcreteValue()
        {
            return _fictionaryConcreteValue!.TryGetValue(Trial, out int _);
        }

        [Benchmark(Baseline = true)]
        public bool DictionaryConcreteReference()
        {
            return _dictionary!.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryConcreteReference()
        {
            return _fictionaryConcreteReference!.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool DictionaryVirtualValue()
        {
            return _dictionary!.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryVirtualValue()
        {
            return _fictionaryVirtual!.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool DictionaryVirtualReference()
        {
            return _dictionary!.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryVirtualReference()
        {
            return _fictionaryVirtual!.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool DictionaryStandardPolymorphic()
        {
            return _dictionary!.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryStandardPolymorphic()
        {
            return _fictionaryStandardPolymorphic!.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool DictionaryDefault()
        {
            return _dictionary!.TryGetValue(Trial, out int _);
        }

        #endregion
    }
}
