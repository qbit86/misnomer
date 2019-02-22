using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Misnomer
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public abstract class TryGetValueBenchmark
    {
        private const int Count = 1729;
        private const int Seed = 0x1e4f6c2a;

        private Dictionary<string, int> _dictionary;
        private Fictionary<string, int, OrdinalStringComparerObject> _fictionaryConcreteReference;
        private Fictionary<string, int, OrdinalStringComparer> _fictionaryConcreteValue;
        private Fictionary<string, int, StringComparer> _fictionaryStandardPolymorphic;
        private Fictionary<string, int, IEqualityComparer<string>> _fictionaryVirtual;

        private static string Trial { get; } = (~Seed).ToString();

        private static TDictionary PopulateStringDictionary<TDictionary>(TDictionary dictionary)
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
            _dictionary = PopulateStringDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            var fictionary = new Fictionary<string, int, OrdinalStringComparer>(new OrdinalStringComparer());
            _fictionaryConcreteValue = PopulateStringDictionary(fictionary);
        }


        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            var dictionary = new Dictionary<string, int>(OrdinalStringComparerObject.Default);
            _dictionary = PopulateStringDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteReference))]
        public void GlobalSetupFictionaryConcreteReference()
        {
            var fictionary =
                new Fictionary<string, int, OrdinalStringComparerObject>(OrdinalStringComparerObject.Default);
            _fictionaryConcreteReference = PopulateStringDictionary(fictionary);
        }


        [GlobalSetup(Target = nameof(DictionaryVirtualValue))]
        public void GlobalSetupDictionaryVirtualValue()
        {
            IEqualityComparer<string> comparer = new OrdinalStringComparer();
            var dictionary = new Dictionary<string, int>(comparer);
            _dictionary = PopulateStringDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualValue))]
        public void GlobalSetupFictionaryVirtualValue()
        {
            IEqualityComparer<string> comparer = new OrdinalStringComparer();
            var fictionary = new Fictionary<string, int, IEqualityComparer<string>>(comparer);
            _fictionaryVirtual = PopulateStringDictionary(fictionary);
        }


        [GlobalSetup(Target = nameof(DictionaryVirtualReference))]
        public void GlobalSetupDictionaryVirtualReference()
        {
            IEqualityComparer<string> comparer = OrdinalStringComparerObject.Default;
            var dictionary = new Dictionary<string, int>(comparer);
            _dictionary = PopulateStringDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualReference))]
        public void GlobalSetupFictionaryVirtualReference()
        {
            IEqualityComparer<string> comparer = OrdinalStringComparerObject.Default;
            var fictionary = new Fictionary<string, int, IEqualityComparer<string>>(comparer);
            _fictionaryVirtual = PopulateStringDictionary(fictionary);
        }


        [GlobalSetup(Target = nameof(DictionaryStandardPolymorphic))]
        public void GlobalSetupDictionaryStandardPolymorphic()
        {
            var dictionary = new Dictionary<string, int>(StringComparer.Ordinal);
            _dictionary = PopulateStringDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryStandardPolymorphic))]
        public void GlobalSetupFictionaryStandardPolymorphic()
        {
            var fictionary = new Fictionary<string, int, StringComparer>(StringComparer.Ordinal);
            _fictionaryStandardPolymorphic = PopulateStringDictionary(fictionary);
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


        [Benchmark(Baseline = true)]
        [BenchmarkCategory("ConcreteReference")]
        public bool DictionaryConcreteReference()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory("ConcreteReference")]
        public bool FictionaryConcreteReference()
        {
            return _fictionaryConcreteReference.TryGetValue(Trial, out int _);
        }


        [Benchmark(Baseline = true)]
        [BenchmarkCategory("VirtualValue")]
        public bool DictionaryVirtualValue()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory("VirtualValue")]
        public bool FictionaryVirtualValue()
        {
            return _fictionaryVirtual.TryGetValue(Trial, out int _);
        }


        [Benchmark(Baseline = true)]
        [BenchmarkCategory("VirtualReference")]
        public bool DictionaryVirtualReference()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory("VirtualReference")]
        public bool FictionaryVirtualReference()
        {
            return _fictionaryVirtual.TryGetValue(Trial, out int _);
        }


        [Benchmark(Baseline = true)]
        [BenchmarkCategory("StandardPolymorphic")]
        public bool DictionaryStandardPolymorphic()
        {
            return _dictionary.TryGetValue(Trial, out int _);
        }

        [Benchmark]
        [BenchmarkCategory("StandardPolymorphic")]
        public bool FictionaryStandardPolymorphic()
        {
            return _fictionaryStandardPolymorphic.TryGetValue(Trial, out int _);
        }

        #endregion
    }
}
