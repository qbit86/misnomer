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

        private Dictionary<string, int> _dictionaryDefaultStringComparer;
        private Dictionary<string, int> _dictionaryRefStringComparer;
        private Dictionary<string, int> _dictionaryValueStringComparer;
        private Fictionary<string, int, GenericEqualityComparer<string>> _fictionaryGenericStringComparer;
        private Fictionary<string, int, StringComparer> _fictionaryRefStringComparer;
        private Fictionary<string, int, OrdinalStringComparer> _fictionaryValueStringComparer;

        private static string Trial { get; } = (~Seed).ToString();

        [GlobalSetup(Target = nameof(DictionaryDefaultStringComparer))]
        public void GlobalSetupDictionaryDefaultStringComparer()
        {
            var dictionary = new Dictionary<string, int>();
            _dictionaryDefaultStringComparer = PopulateStringDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryRefStringComparer))]
        public void GlobalSetupDictionaryRefStringComparer()
        {
            var dictionary = new Dictionary<string, int>(StringComparer.Ordinal);
            _dictionaryRefStringComparer = PopulateStringDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryValueStringComparer))]
        public void GlobalSetupDictionaryValueStringComparer()
        {
            var dictionary = new Dictionary<string, int>(new OrdinalStringComparer());
            _dictionaryValueStringComparer = PopulateStringDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryGenericStringComparer))]
        public void GlobalSetupFictionaryGenericStringComparer()
        {
            Fictionary<string, int, GenericEqualityComparer<string>> fictionary =
                DefaultFictionary<string, int>.Create();
            _fictionaryGenericStringComparer = PopulateStringDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryRefStringComparer))]
        public void GlobalSetupFictionaryRefStringComparer()
        {
            Fictionary<string, int, StringComparer> fictionary = Fictionary<string, int>.Create(StringComparer.Ordinal);
            _fictionaryRefStringComparer = PopulateStringDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryValueStringComparer))]
        public void GlobalSetupFictionaryValueStringComparer()
        {
            Fictionary<string, int, OrdinalStringComparer> fictionary =
                Fictionary<string, int>.Create(new OrdinalStringComparer());
            _fictionaryValueStringComparer = PopulateStringDictionary(fictionary);
        }


        [Benchmark(Baseline = true)]
        [BenchmarkCategory(nameof(String))]
        public int DictionaryRefStringComparer()
        {
            return _dictionaryRefStringComparer.TryGetValue(Trial, out int result) ? result : default;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public int FictionaryRefStringComparer()
        {
            return _fictionaryRefStringComparer.TryGetValue(Trial, out int result) ? result : default;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public int DictionaryValueStringComparer()
        {
            return _dictionaryValueStringComparer.TryGetValue(Trial, out int result) ? result : default;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public int FictionaryValueStringComparer()
        {
            return _fictionaryValueStringComparer.TryGetValue(Trial, out int result) ? result : default;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public int DictionaryDefaultStringComparer()
        {
            return _dictionaryDefaultStringComparer.TryGetValue(Trial, out int result) ? result : default;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public int FictionaryGenericStringComparer()
        {
            return _fictionaryGenericStringComparer.TryGetValue(Trial, out int result) ? result : default;
        }

        private TDictionary PopulateStringDictionary<TDictionary>(TDictionary dictionary)
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
    }
}
