using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Key = System.ConsoleColor;

namespace Misnomer
{
#pragma warning disable CA2000 // Dispose objects before losing scope
    public abstract class EnumTryGetValueBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private Dictionary<Key, int>? _dictionary;
        private Fictionary<Key, int, EnumEqualityComparer>? _fictionaryConcreteValue;

        private static Key[] Trials { get; } = CreateTrials();

        private static Key[] CreateTrials()
        {
            const int count = 101;
            var result = new Key[count * 2];
            for (int i = 0; i != count; ++i)
            {
                int value = 83 * i % count;
                result[2 * i] = (Key)value;
                result[2 * i + 1] = (Key)~value;
            }

            return result;
        }

        private static TDictionary PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            for (int i = 0; i != Count; ++i)
            {
                // 269th prime.
                int value = 1723 * i % Count;
                var key = (Key)value;
                dictionary![key] = value;
            }

            return dictionary;
        }

        #region GlobalSetup

        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            Dictionary<Key, int> dictionary = new(EnumEqualityComparerObject.Default);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            Fictionary<Key, int, EnumEqualityComparer> fictionary = new(new EnumEqualityComparer());
            _fictionaryConcreteValue = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryDefault))]
        public void GlobalSetupDictionaryDefault()
        {
            Dictionary<Key, int> dictionary = new();
            _dictionary = PopulateDictionary(dictionary);
        }

        #endregion

        #region Benchmarks

        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            int result = 0;
            for (int i = 0; i != Trials.Length; ++i)
            {
                if (_dictionary!.TryGetValue(Trials[i], out int value))
                    result ^= value;
            }

            return result;
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            int result = 0;
            for (int i = 0; i != Trials.Length; ++i)
            {
                if (_fictionaryConcreteValue!.TryGetValue(Trials[i], out int value))
                    result ^= value;
            }

            return result;
        }

        [Benchmark]
        public int DictionaryDefault()
        {
            int result = 0;
            for (int i = 0; i != Trials.Length; ++i)
            {
                if (_dictionary!.TryGetValue(Trials[i], out int value))
                    result ^= value;
            }

            return result;
        }

        #endregion
    }
#pragma warning restore CA2000 // Dispose objects before losing scope
}
