using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Key = System.DateTime;

namespace Misnomer
{
    public abstract class DateTimeTryGetValueBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private Dictionary<Key, int> _dictionary;
        private Fictionary<Key, int, GenericEqualityComparerObject<Key>> _fictionaryConcreteReference;
        private Fictionary<Key, int, GenericEqualityComparer<Key>> _fictionaryConcreteValue;
        private Fictionary<Key, int, IEqualityComparer<Key>> _fictionaryVirtual;

        private static Key Trial { get; } = Key.MinValue;

        private static TDictionary PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                // 269th prime.
                int value = 1723 * i % Count;
                Key key = Key.FromBinary(value);
                dictionary[key] = value;
            }

            return dictionary;
        }

        #region GlobalSetup

        [GlobalSetup(Target = nameof(DictionaryConcreteValue))]
        public void GlobalSetupDictionaryConcreteValue()
        {
            var dictionary = new Dictionary<Key, int>(new GenericEqualityComparer<Key>());
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            var fictionary = new Fictionary<Key, int, GenericEqualityComparer<Key>>(new GenericEqualityComparer<Key>());
            _fictionaryConcreteValue = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            var dictionary = new Dictionary<Key, int>(GenericEqualityComparerObject<Key>.Default);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteReference))]
        public void GlobalSetupFictionaryConcreteReference()
        {
            var fictionary = new Fictionary<Key, int, GenericEqualityComparerObject<Key>>(
                GenericEqualityComparerObject<Key>.Default);
            _fictionaryConcreteReference = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualValue))]
        public void GlobalSetupDictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new GenericEqualityComparer<Key>();
            var dictionary = new Dictionary<Key, int>(comparer);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualValue))]
        public void GlobalSetupFictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new GenericEqualityComparer<Key>();
            var fictionary = new Fictionary<Key, int, IEqualityComparer<Key>>(comparer);
            _fictionaryVirtual = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualReference))]
        public void GlobalSetupDictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = GenericEqualityComparerObject<Key>.Default;
            var dictionary = new Dictionary<Key, int>(comparer);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualReference))]
        public void GlobalSetupFictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = GenericEqualityComparerObject<Key>.Default;
            var fictionary = new Fictionary<Key, int, IEqualityComparer<Key>>(comparer);
            _fictionaryVirtual = PopulateDictionary(fictionary);
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
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryConcreteValue()
        {
            return _fictionaryConcreteValue.TryGetValue(Trial, out int _);
        }

        [Benchmark(Baseline = true)]
        public bool DictionaryConcreteReference()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryConcreteReference()
        {
            return _fictionaryConcreteReference.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool DictionaryVirtualValue()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryVirtualValue()
        {
            return _fictionaryVirtual.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool DictionaryVirtualReference()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool FictionaryVirtualReference()
        {
            return _fictionaryVirtual.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        public bool DictionaryDefault()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        #endregion
    }
}
