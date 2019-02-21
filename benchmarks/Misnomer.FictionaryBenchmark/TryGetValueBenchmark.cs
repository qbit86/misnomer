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

        private Dictionary<string, int> _dictionaryRefStringComparer;
        private Fictionary<string, int, StringComparer> _fictionaryRefStringComparer;
        private Dictionary<string, int> _dictionaryValueStringComparer;

        private static string Trial { get; } = (~Seed).ToString();

        [GlobalSetup(Target = nameof(DictionaryRefStringComparer))]
        public void GlobalSetupDictionaryRefStringComparer()
        {
            var dictionary = new Dictionary<string, int>(StringComparer.Ordinal);
            _dictionaryRefStringComparer = PopulateStringDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryRefStringComparer))]
        public void GlobalSetupFictionaryRefStringComparer()
        {
            Fictionary<string, int, StringComparer> fictionary = Fictionary<string, int>.Create(StringComparer.Ordinal);
            _fictionaryRefStringComparer = PopulateStringDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryValueStringComparer))]
        public void GlobalSetupDictionaryValueStringComparer()
        {
            var dictionary = new Dictionary<string, int>(new OrdinalStringComparer());
            _dictionaryValueStringComparer = PopulateStringDictionary(dictionary);
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
            throw new NotImplementedException();
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public int DictionaryDefaultStringComparer()
        {
            throw new NotImplementedException();
        }

        [Benchmark]
        [BenchmarkCategory(nameof(String))]
        public int FictionaryGenericStringComparer()
        {
            throw new NotImplementedException();
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
