using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using Xunit;

namespace Misnomer
{
    public sealed class FictionaryTest
    {
        private const int Count = 233;

        private static KeyValuePair<int, string>[] s_keyValuePairs;

        private static double ScaleFactor { get; } = 1.0;

        private static double CommonRatio { get; } = Math.Pow(2.0, 1.0 / 12.0);

        private static KeyValuePair<int, string>[] KeyValuePairs =>
            s_keyValuePairs ?? (s_keyValuePairs = CreateKeyValuePairs());

        private static double Geometric(int i)
        {
            return Math.Pow(CommonRatio, i) * ScaleFactor;
        }

        private static KeyValuePair<int, string>[] CreateKeyValuePairs()
        {
            var result = new KeyValuePair<int, string>[Count];

            for (int i = 0; i != Count; ++i)
            {
                double rawValue = Geometric(i);
                int key = Convert.ToInt32(rawValue);
                string value = rawValue.ToString(CultureInfo.InvariantCulture);
                result[i] = KeyValuePair.Create(key, value);
            }

            return result;
        }

        [Fact]
        public void Create_WithDictionary()
        {
            // Arrange
            ImmutableDictionary<int, string>.Builder builder =
                ImmutableDictionary.CreateBuilder<int, string>(EqualityComparer<int>.Default);
            for (int i = 0; i != Count; ++i)
            {
                double rawValue = Geometric(i);
                int key = Convert.ToInt32(rawValue);
                string value = rawValue.ToString(CultureInfo.InvariantCulture);
                builder.TryAdd(key, value);
            }

            ImmutableDictionary<int, string> sourceDictionary = builder.ToImmutable();
            var keyComparer = new GenericEqualityComparer<int>();

            // Act
            var dictionary = new Dictionary<int, string>(sourceDictionary, Int32EqualityComparer.Default);
            var fictionary = new Fictionary<int, string, GenericEqualityComparer<int>>(sourceDictionary, keyComparer);

            // Assert
            Assert.Empty(dictionary.Except(fictionary));
            Assert.Empty(fictionary.Except(dictionary));
        }

        [Fact]
        public void Indexer_ShouldBehaveTheSameWay()
        {
            // Arrange
            string[] keys = ArrayPool<string>.Shared.Rent(Count);
            var dictionary = new Dictionary<string, double>(StringComparer.Ordinal);
            var fictionary = new Fictionary<string, double, StringComparer>(StringComparer.Ordinal);
            for (int i = 0; i != keys.Length; ++i)
            {
                double value = Geometric(i);
                int rawKey = Convert.ToInt32(value);
                string key = rawKey.ToString();
                keys[i] = key;
                dictionary[key] = value;
                fictionary[key] = value;
            }

            // Act
            for (int i = 0; i != keys.Length; ++i)
            {
                string key = keys[i];
                double dictionaryValue = dictionary[key];
                double fictionaryValue = fictionary[key];
                Assert.Equal(dictionaryValue, fictionaryValue);
            }
        }

        [Fact]
        public void TryAdd_ShouldBehaveTheSameWay()
        {
            // Arrange
            const int count = Count;
            var dictionary = new Dictionary<int, string>(count, EqualityComparer<int>.Default);
            var fictionary = new Fictionary<int, string, EqualityComparer<int>>(count, EqualityComparer<int>.Default);

            // Act
            for (int i = 0; i != count; ++i)
            {
                double rawValue = Geometric(i);
                int key = Convert.ToInt32(rawValue);
                string value = rawValue.ToString(CultureInfo.InvariantCulture);
                bool addedToDictionary = dictionary.TryAdd(key, value);
                bool addedToFictionary = fictionary.TryAdd(key, value);
                Assert.Equal(addedToDictionary, addedToFictionary);
            }

            // Assert
            Assert.Equal(dictionary.Count, fictionary.Count);

            Assert.Empty(dictionary.Keys.Except(fictionary.Keys));
            Assert.Empty(fictionary.Keys.Except(dictionary.Keys));

            Assert.Empty(dictionary.Values.Except(fictionary.Values));
            Assert.Empty(fictionary.Values.Except(dictionary.Values));

            Assert.Empty(dictionary.Except(fictionary));
            Assert.Empty(fictionary.Except(dictionary));
        }
    }
}
