using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Key = System.ConsoleColor;


namespace Misnomer
{
    public abstract class EnumTryGetValueBenchmark
    {
        // 270th prime.
        private const int Count = 1733;

        private Dictionary<Key, int> _dictionary;
        private Fictionary<Key, int, EnumEqualityComparer> _fictionaryConcreteValue;

        private static Key[] Trials { get; } = CreateTrials();

        private static Key[] CreateTrials()
        {
            const int count = 101;
            var result = new Key[count * 2];
            for (int i = 0; i != count; ++i)
            {
                int value = 83 * i % count;
                result[2 * i] = (Key)value;
                result[2 * i + 1] = (Key)(~value);
            }

            return result;
        }

        private static TDictionary PopulateDictionary<TDictionary>(TDictionary dictionary)
            where TDictionary : IDictionary<Key, int>
        {
            Debug.Assert(dictionary != null, "dictionary != null");

            for (int i = 0; i != Count; ++i)
            {
                // 269th prime.
                int value = 1723 * i % Count;
                var key = (Key)value;
                dictionary[key] = value;
            }

            return dictionary;
        }

        private readonly struct EnumEqualityComparer : IEqualityComparer<Key>,
            IEquatable<EnumEqualityComparer>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(Key x, Key y)
            {
                return (int)y == (int)x;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetHashCode(Key obj)
            {
                return ((int)obj).GetHashCode();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(EnumEqualityComparer other)
            {
                return true;
            }
        }

        private sealed class EnumEqualityComparerObject : IEqualityComparer<Key>
        {
            private EnumEqualityComparerObject() { }

            internal static EnumEqualityComparerObject Default { get; } = new EnumEqualityComparerObject();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(Key x, Key y)
            {
                return (int)y == (int)x;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetHashCode(Key obj)
            {
                return ((int)obj).GetHashCode();
            }
        }

        #region GlobalSetup

        [GlobalSetup(Target = nameof(DictionaryConcreteReference))]
        public void GlobalSetupDictionaryConcreteReference()
        {
            var dictionary = new Dictionary<Key, int>(EnumEqualityComparerObject.Default);
            _dictionary = PopulateDictionary(dictionary);
        }

        [GlobalSetup(Target = nameof(FictionaryConcreteValue))]
        public void GlobalSetupFictionaryConcreteValue()
        {
            var fictionary = new Fictionary<Key, int, EnumEqualityComparer>(new EnumEqualityComparer());
            _fictionaryConcreteValue = PopulateDictionary(fictionary);
        }

        [GlobalSetup(Target = nameof(DictionaryDefault))]
        public void GlobalSetupDictionaryDefault()
        {
            var dictionary = new Dictionary<Key, int>();
            _dictionary = PopulateDictionary(dictionary);
        }

        #endregion

        #region Benchmarks

        [Benchmark(Baseline = true)]
        public int DictionaryConcreteReference()
        {
            int result = 0;
            for (int i = 0; i != Trials.Length; ++i)
                if (_dictionary.TryGetValue(Trials[i], out int value))
                    result ^= value;

            return result;
        }

        [Benchmark]
        public int FictionaryConcreteValue()
        {
            int result = 0;
            for (int i = 0; i != Trials.Length; ++i)
                if (_fictionaryConcreteValue.TryGetValue(Trials[i], out int value))
                    result ^= value;

            return result;
        }

        [Benchmark]
        public int DictionaryDefault()
        {
            int result = 0;
            for (int i = 0; i != Trials.Length; ++i)
                if (_dictionary.TryGetValue(Trials[i], out int value))
                    result ^= value;

            return result;
        }

        #endregion
    }
}
