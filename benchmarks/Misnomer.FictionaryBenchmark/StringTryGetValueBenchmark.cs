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

        private Dictionary<string, int>? _dictionary;
        private Fictionary<string, int, OrdinalStringComparerObject>? _fictionaryConcreteReference;
        private Fictionary<string, int, OrdinalStringComparer>? _fictionaryConcreteValue;
        private Fictionary<string, int, StringComparer>? _fictionaryStandardPolymorphic;
        private Fictionary<string, int, IEqualityComparer<string>>? _fictionaryVirtual;

        private static string Trial { get; } = (~Seed).ToString();

        private static TDictionary PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<string, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                int value = unchecked(Seed + i);
                dictionary![value.ToString("x8")] = value;
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
            Fictionary<string, int, OrdinalStringComparer> fictionary = new(new OrdinalStringComparer());
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
            Fictionary<string, int, OrdinalStringComparerObject> fictionary = new(OrdinalStringComparerObject.Default);
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
            using Fictionary<string, int, IEqualityComparer<string>> fictionary = new(comparer);
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
            using Fictionary<string, int, IEqualityComparer<string>> fictionary = new(comparer);
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
            using Fictionary<string, int, StringComparer> fictionary = new(StringComparer.Ordinal);
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
        public bool DictionaryConcreteValue() => _dictionary!.TryGetValue(Trial, out int _);

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryConcreteValue() => _fictionaryConcreteValue!.TryGetValue(Trial, out int _);


        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool DictionaryConcreteReference() => _dictionary!.TryGetValue(Trial, out int _);

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryConcreteReference() => _fictionaryConcreteReference!.TryGetValue(Trial, out int _);


        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool DictionaryVirtualValue() => _dictionary!.TryGetValue(Trial, out int _);

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryVirtualValue() => _fictionaryVirtual!.TryGetValue(Trial, out int _);


        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool DictionaryVirtualReference() => _dictionary!.TryGetValue(Trial, out int _);

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryVirtualReference() => _fictionaryVirtual!.TryGetValue(Trial, out int _);


        [Benchmark(Baseline = true)]
        [BenchmarkCategory(nameof(String))]
        public bool DictionaryStandardPolymorphic() => _dictionary!.TryGetValue(Trial, out int _);

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public bool FictionaryStandardPolymorphic() => _fictionaryStandardPolymorphic!.TryGetValue(Trial, out int _);

        #endregion
    }
}
