using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Misnomer
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public abstract class ArraySegmentTryGetValueBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private static readonly int[] s_array = new int[Count];

        private Dictionary<ArraySegment<int>, int> _dictionary;
        // private Fictionary<ArraySegment<int>, int, ArraySegmentComparerObject<int>> _fictionaryConcreteReference;
        private Fictionary<ArraySegment<int>, int, ArraySegmentComparer<int>> _fictionaryConcreteValue;
        // private Fictionary<ArraySegment<int>, int, EqualityComparer<ArraySegment<int>>> _fictionaryStandardPolymorphic;
        // private Fictionary<ArraySegment<int>, int, IEqualityComparer<ArraySegment<int>>> _fictionaryVirtual;

        private static ArraySegment<int> Trial { get; } = new ArraySegment<int>(Array.Empty<int>());

        private static TDictionary PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<ArraySegment<int>, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                // 269th prime.
                int value = 1723 * i % Count;
                var key = new ArraySegment<int>(s_array, value, Count - value);
                dictionary[key] = value;
            }

            return dictionary;
        }

        #region GlobalSetup

        [GlobalSetup(Target = nameof(DictionaryConcreteValue))]
        public void GlobalSetupDictionaryConcreteValue()
        {
            var dictionary = new Dictionary<ArraySegment<int>, int>(new ArraySegmentComparer<int>());
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            var fictionary = new Fictionary<ArraySegment<int>, int, ArraySegmentComparer<int>>(
                new ArraySegmentComparer<int>());
            _fictionaryConcreteValue = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryDefault))]
        public void GlobalSetupDictionaryDefault()
        {
            var dictionary = new Dictionary<ArraySegment<int>, int>();
            _dictionary = PopulateDictionary(dictionary);
        }

        #endregion

        #region Benchmarks

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("ConcreteValue")]
        public bool DictionaryConcreteValue()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory("ConcreteValue")]
        public bool FictionaryConcreteValue()
        {
            return _fictionaryConcreteValue.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory("ConcreteValue")]
        public bool DictionaryDefault()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        #endregion
    }
}
