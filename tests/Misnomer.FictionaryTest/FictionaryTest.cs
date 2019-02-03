using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using Misnomer.Extensions;
using Xunit;

namespace Misnomer
{
    public sealed class FictionaryTest
    {
        private const int Count = 233;

        private static ImmutableArray<KeyValuePair<int, string>> s_sampleItems;

        private static ImmutableDictionary<int, string> s_sampleDictionary;

        private static double ScaleFactor { get; } = 1.0;

        private static double CommonRatio { get; } = Math.Pow(2.0, 1.0 / 12.0);

        private static ImmutableArray<KeyValuePair<int, string>> SampleItems =>
            s_sampleItems.IsDefault ? s_sampleItems = CreateSampleItems() : s_sampleItems;

        private static ImmutableDictionary<int, string> SampleDictionary =>
            s_sampleDictionary ?? (s_sampleDictionary = CreateSampleDictionary());

        private static double Geometric(int i)
        {
            return Math.Pow(CommonRatio, i) * ScaleFactor;
        }

        private static ImmutableArray<KeyValuePair<int, string>> CreateSampleItems()
        {
            ImmutableArray<KeyValuePair<int, string>>.Builder builder =
                ImmutableArray.CreateBuilder<KeyValuePair<int, string>>();

            for (int i = 0; i != Count; ++i)
            {
                double rawValue = Geometric(i);
                int key = Convert.ToInt32(rawValue);
                string value = rawValue.ToString(CultureInfo.InvariantCulture);
                builder.Add(KeyValuePair.Create(key, value));
            }

            return builder.ToImmutable();
        }

        private static ImmutableDictionary<int, string> CreateSampleDictionary()
        {
            ImmutableDictionary<int, string>.Builder builder =
                ImmutableDictionary.CreateBuilder<int, string>(EqualityComparer<int>.Default);

            foreach (KeyValuePair<int, string> kv in SampleItems)
                builder[kv.Key] = kv.Value;

            return builder.ToImmutable();
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores
        [Fact]
        public void Clear()
        {
            // Arrange
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary =
                DefaultFictionary.Create(SampleDictionary);
            foreach (KeyValuePair<int, string> kv in SampleDictionary)
                Assert.True(fictionary.ContainsKey(kv.Key));

            // Act
            fictionary.Clear();

            // Assert
            Assert.Empty(fictionary);
            foreach (KeyValuePair<int, string> kv in SampleDictionary)
                Assert.False(fictionary.ContainsKey(kv.Key));
        }

        [Fact]
        public void ContainsValue_ShouldBehaveTheSameWay()
        {
            // Arrange
            Dictionary<string, int> dictionary = SampleDictionary.ToDictionary(kv => kv.Value, kv => kv.Key);
            Fictionary<string, int, GenericEqualityComparer<string>> fictionary =
                SampleDictionary.ToFictionary(kv => kv.Value, kv => kv.Key);
            const int bound = 100;
            int hitCount = 0;
            int missCount = 0;

            // Assert
            for (int i = 0; i != bound; ++i)
            {
                bool dictionaryContainsValue = dictionary.ContainsValue(i);
                bool fictionaryContainsValue = fictionary.ContainsValue(i);

                Assert.Equal(dictionaryContainsValue, fictionaryContainsValue);

                hitCount += Convert.ToInt32(fictionaryContainsValue);
                missCount += Convert.ToInt32(!fictionaryContainsValue);
            }

            Assert.True(hitCount > 0);
            Assert.True(missCount > 0);
        }

        [Fact]
        public void Create_WithDictionary()
        {
            // Arrange
            var keyComparer = new GenericEqualityComparer<int>();

            // Act
            var dictionary = new Dictionary<int, string>(SampleDictionary, Int32EqualityComparer.Default);
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary =
                Fictionary.Create(SampleDictionary, keyComparer);

            // Assert
            Assert.Empty(dictionary.Except(fictionary));
            Assert.Empty(fictionary.Except(dictionary));
        }

        [Fact]
        public void Indexer_ShouldBehaveTheSameWay()
        {
            // Arrange
            var dictionary = new Dictionary<string, double>(StringComparer.Ordinal);
            Fictionary<string, double, StringComparer> fictionary =
                Fictionary<string, double>.Create(StringComparer.Ordinal);

            int count = SampleItems.Length;
            for (int i = 0; i != count; ++i)
            {
                double value = Geometric(i);
                string key = SampleItems[i].Value;
                dictionary[key] = value;
                fictionary[key] = value;
            }

            // Act
            for (int i = 0; i != count; ++i)
            {
                string key = SampleItems[i].Value;
                double dictionaryValue = dictionary[key];
                double fictionaryValue = fictionary[key];
                Assert.Equal(dictionaryValue, fictionaryValue);
            }
        }

        [Fact]
        public void Remove_ShouldBehaveTheSameWay()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>(SampleDictionary, Int32EqualityComparer.Default);
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary =
                DefaultFictionary.Create(SampleDictionary);
            int count = SampleItems.Length;

            // Act
            for (int i = 0; i != count; ++i)
            {
                int key = SampleItems[i].Key * (i % 2 == 0 ? 1 : -1);
                bool removedFromDictionary = dictionary.Remove(key);
                bool removedFromFictionary = fictionary.Remove(key);

                Assert.Equal(removedFromDictionary, removedFromFictionary);
                Assert.False(fictionary.ContainsKey(key));
                Assert.False(fictionary.TryGetValue(key, out _));
            }
        }

        [Fact]
        public void TryAdd_ShouldBehaveTheSameWay()
        {
            // Arrange
            int count = SampleItems.Length;
            var dictionary = new Dictionary<int, string>(count, EqualityComparer<int>.Default);
            var fictionary = new Fictionary<int, string, EqualityComparer<int>>(count, EqualityComparer<int>.Default);

            // Act
            for (int i = 0; i != count; ++i)
            {
                KeyValuePair<int, string> kv = SampleItems[i];
                int key = kv.Key;
                string value = kv.Value;
                bool addedToDictionary = dictionary.TryAdd(key, value);
                bool addedToFictionary = fictionary.TryAdd(key, value);
                Assert.Equal(addedToDictionary, addedToFictionary);
                Assert.True(fictionary.ContainsKey(key));
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
#pragma warning restore CA1707 // Identifiers should not contain underscores
    }
}
