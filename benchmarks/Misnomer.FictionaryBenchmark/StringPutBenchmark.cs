using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class StringPutBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private Dictionary<string, int> _dictionary;
        private Fictionary<string, int, OrdinalStringComparerObject> _fictionaryConcreteReference;
        private Fictionary<string, int, OrdinalStringComparer> _fictionaryConcreteValue;
        private Fictionary<string, int, StringComparer> _fictionaryStandardPolymorphic;
        private Fictionary<string, int, IEqualityComparer<string>> _fictionaryVirtual;

        private static int PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<string, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                int firstValue = (7 + 1723 * i) % Count;
                string firstKey = firstValue.ToString("x8");
                if (!dictionary.ContainsKey(firstKey))
                    dictionary.Add(firstKey, firstValue);

                int secondValue = (13 + 853 * i) % Count;
                string secondKey = secondValue.ToString("x8");
                dictionary[secondKey] = secondValue;
            }

            return dictionary.Count;
        }

        #region GlobalSetup

        [GlobalSetup(Target = nameof(DictionaryConcreteValue))]
        public void GlobalSetupDictionaryConcreteValue()
        {
            _dictionary = new Dictionary<string, int>(new OrdinalStringComparer());
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            _fictionaryConcreteValue = new Fictionary<string, int, OrdinalStringComparer>(new OrdinalStringComparer());
        }


        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            _dictionary = new Dictionary<string, int>(OrdinalStringComparerObject.Default);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteReference))]
        public void GlobalSetupFictionaryConcreteReference()
        {
            _fictionaryConcreteReference =
                new Fictionary<string, int, OrdinalStringComparerObject>(OrdinalStringComparerObject.Default);
        }


        [GlobalSetup(Target = nameof(DictionaryVirtualValue))]
        public void GlobalSetupDictionaryVirtualValue()
        {
            IEqualityComparer<string> comparer = new OrdinalStringComparer();
            _dictionary = new Dictionary<string, int>(comparer);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualValue))]
        public void GlobalSetupFictionaryVirtualValue()
        {
            IEqualityComparer<string> comparer = new OrdinalStringComparer();
            _fictionaryVirtual = new Fictionary<string, int, IEqualityComparer<string>>(comparer);
        }


        [GlobalSetup(Target = nameof(DictionaryVirtualReference))]
        public void GlobalSetupDictionaryVirtualReference()
        {
            IEqualityComparer<string> comparer = OrdinalStringComparerObject.Default;
            _dictionary = new Dictionary<string, int>(comparer);
        }

        [GlobalSetup(Target = nameof(FictionaryVirtualReference))]
        public void GlobalSetupFictionaryVirtualReference()
        {
            IEqualityComparer<string> comparer = OrdinalStringComparerObject.Default;
            _fictionaryVirtual = new Fictionary<string, int, IEqualityComparer<string>>(comparer);
        }


        [GlobalSetup(Target = nameof(DictionaryStandardPolymorphic))]
        public void GlobalSetupDictionaryStandardPolymorphic()
        {
            _dictionary = new Dictionary<string, int>(StringComparer.Ordinal);
        }

        [GlobalSetup(Target = nameof(FictionaryStandardPolymorphic))]
        public void GlobalSetupFictionaryStandardPolymorphic()
        {
            _fictionaryStandardPolymorphic = new Fictionary<string, int, StringComparer>(StringComparer.Ordinal);
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
        public int DictionaryConcreteValue()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            return PopulateDictionary(_fictionaryConcreteValue);
        }


        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteReference()
        {
            return PopulateDictionary(_fictionaryConcreteReference);
        }


        [Benchmark]
        public int DictionaryVirtualValue()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualValue()
        {
            return PopulateDictionary(_fictionaryVirtual);
        }


        [Benchmark]
        public int DictionaryVirtualReference()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualReference()
        {
            return PopulateDictionary(_fictionaryVirtual);
        }


        [Benchmark(Baseline = true)]
        public int DictionaryStandardPolymorphic()
        {
            return PopulateDictionary(_dictionary);
        }

        [Benchmark]
        public int FictionaryStandardPolymorphic()
        {
            return PopulateDictionary(_fictionaryStandardPolymorphic);
        }

        #endregion
    }
}
