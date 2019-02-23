using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Misnomer
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public abstract class StringTryGetValueBenchmark
    {
        private const int Count = 1729;
        private const int Seed = 0x1e4f6c2a;

        private Dictionary<string, int> _dictionary;
        private Fictionary<string, int, OrdinalStringComparerObject> _fictionaryConcreteReference;
        private Fictionary<string, int, OrdinalStringComparer> _fictionaryConcreteValue;
        private Fictionary<string, int, StringComparer> _fictionaryStandardPolymorphic;
        private Fictionary<string, int, IEqualityComparer<string>> _fictionaryVirtual;

        private static string Trial { get; } = (~Seed).ToString();

        private static TDictionary PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<string, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                int value = unchecked(Seed + i);
                dictionary[value.ToString("x8")] = value;
            }

            return dictionary;
        }

        #region GlobalSetup

        [GlobalSetup(Target = nameof(DictionaryConcreteValue))]
        public void GlobalSetupDictionaryConcreteValue()
        {
            var dictionary = new Dictionary<string, int>(new OrdinalStringComparer());
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            var fictionary = new Fictionary<string, int, OrdinalStringComparer>(new OrdinalStringComparer());
            _fictionaryConcreteValue = PopulateDictionary(fictionary);
        }


        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            var dictionary = new Dictionary<string, int>(OrdinalStringComparerObject.Default);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteReference))]
        public void GlobalSetupFictionaryConcreteReference()
        {
            var fictionary =
                new Fictionary<string, int, OrdinalStringComparerObject>(OrdinalStringComparerObject.Default);
            _fictionaryConcreteReference = PopulateDictionary(fictionary);
        }


        [GlobalSetup(Target = nameof(DictionaryVirtualValue))]
        public void GlobalSetupDictionaryVirtualValue()
        {
            IEqualityComparer<string> comparer = new OrdinalStringComparer();
            var dictionary = new Dictionary<string, int>(comparer);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualValue))]
        public void GlobalSetupFictionaryVirtualValue()
        {
            IEqualityComparer<string> comparer = new OrdinalStringComparer();
            var fictionary = new Fictionary<string, int, IEqualityComparer<string>>(comparer);
            _fictionaryVirtual = PopulateDictionary(fictionary);
        }


        [GlobalSetup(Target = nameof(DictionaryVirtualReference))]
        public void GlobalSetupDictionaryVirtualReference()
        {
            IEqualityComparer<string> comparer = OrdinalStringComparerObject.Default;
            var dictionary = new Dictionary<string, int>(comparer);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualReference))]
        public void GlobalSetupFictionaryVirtualReference()
        {
            IEqualityComparer<string> comparer = OrdinalStringComparerObject.Default;
            var fictionary = new Fictionary<string, int, IEqualityComparer<string>>(comparer);
            _fictionaryVirtual = PopulateDictionary(fictionary);
        }


        [GlobalSetup(Target = nameof(DictionaryStandardPolymorphic))]
        public void GlobalSetupDictionaryStandardPolymorphic()
        {
            var dictionary = new Dictionary<string, int>(StringComparer.Ordinal);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryStandardPolymorphic))]
        public void GlobalSetupFictionaryStandardPolymorphic()
        {
            var fictionary = new Fictionary<string, int, StringComparer>(StringComparer.Ordinal);
            _fictionaryStandardPolymorphic = PopulateDictionary(fictionary);
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
        [BenchmarkCategory(nameof(String))]
        public bool DictionaryConcreteValue()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryConcreteValue()
        {
            return _fictionaryConcreteValue.TryGetValue(Trial, out int _);
        }


        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool DictionaryConcreteReference()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryConcreteReference()
        {
            return _fictionaryConcreteReference.TryGetValue(Trial, out int _);
        }


        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool DictionaryVirtualValue()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryVirtualValue()
        {
            return _fictionaryVirtual.TryGetValue(Trial, out int _);
        }


        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool DictionaryVirtualReference()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryVirtualReference()
        {
            return _fictionaryVirtual.TryGetValue(Trial, out int _);
        }


        [Benchmark(Baseline = true)]
        [BenchmarkCategory(nameof(String))]
        public bool DictionaryStandardPolymorphic()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryStandardPolymorphic()
        {
            return _fictionaryStandardPolymorphic.TryGetValue(Trial, out int _);
        }

        #endregion
    }
}
