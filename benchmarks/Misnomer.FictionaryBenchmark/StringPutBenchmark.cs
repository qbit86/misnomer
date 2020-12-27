using System;
using System.Collections.Generic;
using System.Globalization;
using BenchmarkDotNet.Attributes;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class StringPutBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private static int PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<string, int>
        {
            for (int i = 0; i != Count; ++i)
            {
                int firstValue = (7 + 1723 * i) % Count;
                string firstKey = firstValue.ToString("x8", CultureInfo.InvariantCulture);
                if (!dictionary!.ContainsKey(firstKey))
                    dictionary.Add(firstKey, firstValue);

                int secondValue = (13 + 853 * i) % Count;
                string secondKey = secondValue.ToString("x8", CultureInfo.InvariantCulture);
                dictionary[secondKey] = secondValue;
            }

            return dictionary!.Count;
        }

        #region Benchmarks

        [Benchmark]
        public int DictionaryConcreteValue()
        {
            var dictionary = new Dictionary<string, int>(Count, new OrdinalStringComparer());
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            using Fictionary<string, int, OrdinalStringComparer> fictionaryConcreteValue =
                new(Count, new OrdinalStringComparer());
            return PopulateDictionary(fictionaryConcreteValue);
        }


        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            var dictionary = new Dictionary<string, int>(Count, OrdinalStringComparerObject.Default);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryConcreteReference()
        {
            using Fictionary<string, int, OrdinalStringComparerObject> fictionaryConcreteReference =
                new(Count, OrdinalStringComparerObject.Default);
            return PopulateDictionary(fictionaryConcreteReference);
        }


        [Benchmark]
        public int DictionaryVirtualValue()
        {
            IEqualityComparer<string> comparer = new OrdinalStringComparer();
            var dictionary = new Dictionary<string, int>(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualValue()
        {
            IEqualityComparer<string> comparer = new OrdinalStringComparer();
            using Fictionary<string, int, IEqualityComparer<string>> fictionaryVirtual = new(Count, comparer);
            return PopulateDictionary(fictionaryVirtual);
        }


        [Benchmark]
        public int DictionaryVirtualReference()
        {
            IEqualityComparer<string> comparer = OrdinalStringComparerObject.Default;
            var dictionary = new Dictionary<string, int>(Count, comparer);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryVirtualReference()
        {
            IEqualityComparer<string> comparer = OrdinalStringComparerObject.Default;
            using Fictionary<string, int, IEqualityComparer<string>> fictionaryVirtual = new(Count, comparer);
            return PopulateDictionary(fictionaryVirtual);
        }

        [Benchmark]
        public int DictionaryStandardPolymorphic()
        {
            var dictionary = new Dictionary<string, int>(Count, StringComparer.Ordinal);
            return PopulateDictionary(dictionary);
        }

        [Benchmark]
        public int FictionaryStandardPolymorphic()
        {
            using Fictionary<string, int, StringComparer> fictionaryStandardPolymorphic =
                new(Count, StringComparer.Ordinal);
            return PopulateDictionary(fictionaryStandardPolymorphic);
        }

        #endregion
    }
}
