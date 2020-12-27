using System;
using System.Collections.Generic;
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

        private Key Trial { get; set; } = new(Array.Empty<int>());

        private static TDictionary PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            for (int i = 0; i != Count; ++i)
            {
                // 269th prime.
                int value = (5 + 1723 * i) % Count;
                Key key = new(s_array, value, Count - value);
                dictionary![key] = value;
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
            Dictionary<Key, int> dictionary = new(new ArraySegmentEqualityComparer<int>());
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            using Fictionary<Key, int, ArraySegmentEqualityComparer<int>> fictionary =
                new(new ArraySegmentEqualityComparer<int>());
            _fictionaryConcreteValue = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            Dictionary<Key, int> dictionary = new(ArraySegmentComparerObject<int>.Default);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteReference))]
        public void GlobalSetupFictionaryConcreteReference()
        {
            using Fictionary<Key, int, ArraySegmentComparerObject<int>> fictionary =
                new(ArraySegmentComparerObject<int>.Default);
            _fictionaryConcreteReference = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualValue))]
        public void GlobalSetupDictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            Dictionary<Key, int> dictionary = new(comparer);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualValue))]
        public void GlobalSetupFictionaryVirtualValue()
        {
            IEqualityComparer<Key> comparer = new ArraySegmentEqualityComparer<int>();
            using Fictionary<Key, int, IEqualityComparer<Key>> fictionary = new(comparer);
            _fictionaryVirtual = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryVirtualReference))]
        public void GlobalSetupDictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
            Dictionary<Key, int> dictionary = new(comparer);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualReference))]
        public void GlobalSetupFictionaryVirtualReference()
        {
            IEqualityComparer<Key> comparer = ArraySegmentComparerObject<int>.Default;
            using Fictionary<Key, int, IEqualityComparer<Key>> fictionary = new(comparer);
            _fictionaryVirtual = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryStandardPolymorphic))]
        public void GlobalSetupDictionaryStandardPolymorphic()
        {
            Dictionary<Key, int> dictionary = new(EqualityComparer<Key>.Default);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryStandardPolymorphic))]
        public void GlobalSetupFictionaryStandardPolymorphic()
        {
            using Fictionary<Key, int, EqualityComparer<Key>> fictionary = new(EqualityComparer<Key>.Default);
            _fictionaryStandardPolymorphic = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryDefault))]
        public void GlobalSetupDictionaryDefault()
        {
            Dictionary<Key, int> dictionary = new();
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
        public bool DictionaryConcreteValue() => _dictionary!.TryGetValue(Trial, out _);

        [Benchmark]
        public bool FictionaryConcreteValue() => _fictionaryConcreteValue!.TryGetValue(Trial, out _);

        [Benchmark(Baseline = true)]
        public bool DictionaryConcreteReference() => _dictionary!.TryGetValue(Trial, out _);

        [Benchmark]
        public bool FictionaryConcreteReference() => _fictionaryConcreteReference!.TryGetValue(Trial, out _);

        [Benchmark]
        public bool DictionaryVirtualValue() => _dictionary!.TryGetValue(Trial, out _);

        [Benchmark]
        public bool FictionaryVirtualValue() => _fictionaryVirtual!.TryGetValue(Trial, out _);

        [Benchmark]
        public bool DictionaryVirtualReference() => _dictionary!.TryGetValue(Trial, out _);

        [Benchmark]
        public bool FictionaryVirtualReference() => _fictionaryVirtual!.TryGetValue(Trial, out _);

        [Benchmark]
        public bool DictionaryStandardPolymorphic() => _dictionary!.TryGetValue(Trial, out _);

        [Benchmark]
        public bool FictionaryStandardPolymorphic() => _fictionaryStandardPolymorphic!.TryGetValue(Trial, out _);

        [Benchmark]
        public bool DictionaryDefault() => _dictionary!.TryGetValue(Trial, out _);

        #endregion
    }
}
