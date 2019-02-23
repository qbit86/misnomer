using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Key = System.ArraySegment<int>;

namespace Misnomer
{
    public abstract class ArraySegmentTryGetValueBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private static readonly int[] s_array = new int[Count];

        private Dictionary<Key, int> _dictionary;
        private Fictionary<Key, int, ArraySegmentComparerObject<int>> _fictionaryConcreteReference;

        private Fictionary<Key, int, ArraySegmentComparer<int>> _fictionaryConcreteValue;
        // private Fictionary<Key, int, EqualityComparer<Key>> _fictionaryStandardPolymorphic;
        // private Fictionary<Key, int, IEqualityComparer<Key>> _fictionaryVirtual;

        private static Key Trial { get; } = new Key(Array.Empty<int>());

        private static TDictionary PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                // 269th prime.
                int value = 1723 * i % Count;
                var key = new Key(s_array, value, Count - value);
                dictionary[key] = value;
            }

            return dictionary;
        }

        #region GlobalSetup

        [GlobalSetup(Target = nameof(DictionaryDefault))]
        public void GlobalSetupDictionaryDefault()
        {
            var dictionary = new Dictionary<Key, int>();
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryConcreteValue))]
        public void GlobalSetupDictionaryConcreteValue()
        {
            var dictionary = new Dictionary<Key, int>(new ArraySegmentComparer<int>());
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            var fictionary = new Fictionary<Key, int, ArraySegmentComparer<int>>(new ArraySegmentComparer<int>());
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

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _dictionary = null;
            _fictionaryConcreteValue = null;
        }

        #endregion

        #region Benchmarks

        [Benchmark]
        public bool DictionaryDefault()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark(Baseline = true)]
        public bool DictionaryConcreteValue()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryConcreteValue()
        {
            return _fictionaryConcreteValue.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool DictionaryConcreteReference()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryConcreteReference()
        {
            return _fictionaryConcreteReference.TryGetValue(Trial, out int _);
        }

        #endregion
    }
}
