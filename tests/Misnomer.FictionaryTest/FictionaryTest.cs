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

        private static ImmutableDictionary<int, string>? s_sampleDictionary;

        private static double ScaleFactor { get; } = 1.0;

        private static double CommonRatio { get; } = Math.Pow(2.0, 1.0 / 12.0);

        private static ImmutableArray<KeyValuePair<int, string>> SampleItems =>
            s_sampleItems.IsDefault ? s_sampleItems = CreateSampleItems() : s_sampleItems;

        private static ImmutableDictionary<int, string> SampleDictionary =>
            s_sampleDictionary ??= CreateSampleDictionary();

        private static double Geometric(int i) => Math.Pow(CommonRatio, i) * ScaleFactor;

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

        [Fact]
        public void Clear()
        {
            // Arrange
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary = SampleDictionary.ToFictionary();
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
        public void CopyTo_ShouldBehaveTheSameWay()
        {
            // Arrange
            Dictionary<int, string> dictionary = new(SampleDictionary);
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary = SampleDictionary.ToFictionary();

            var dictionaryArray = new KeyValuePair<int, string>[dictionary.Count];
            var fictionaryArray = new KeyValuePair<int, string>[fictionary.Count];

            // Act
            ((ICollection<KeyValuePair<int, string>>)dictionary).CopyTo(dictionaryArray, 0);
            ((ICollection<KeyValuePair<int, string>>)fictionary).CopyTo(fictionaryArray, 0);

            // Assert
            Assert.Empty(dictionaryArray.Except(fictionaryArray));
            Assert.Empty(fictionaryArray.Except(dictionaryArray));
        }

        [Fact]
        public void Create_WithDictionary()
        {
            // Arrange
            GenericEqualityComparer<int> keyComparer = default;

            // Act
            Dictionary<int, string> dictionary = new(SampleDictionary, Int32EqualityComparer.Default);
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary =
                SampleDictionary.ToFictionary(keyComparer);

            // Assert
            Assert.Empty(dictionary.Except(fictionary));
            Assert.Empty(fictionary.Except(dictionary));
        }

        [Fact]
        public void Indexer_ShouldBehaveTheSameWay()
        {
            // Arrange
            Dictionary<string, double> dictionary = new(StringComparer.Ordinal);
            using Fictionary<string, double, StringComparer> fictionary =
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
            Dictionary<int, string> dictionary = new(SampleDictionary, Int32EqualityComparer.Default);
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary = SampleDictionary.ToFictionary();
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
        public void RemoveOut_ShouldBehaveTheSameWay()
        {
            // Arrange
            Dictionary<int, string> dictionary = new(SampleDictionary, Int32EqualityComparer.Default);
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary = SampleDictionary.ToFictionary();
            int count = SampleItems.Length;

            // Act
            for (int i = 0; i != count; ++i)
            {
                int key = SampleItems[i].Key * (i % 2 == 0 ? 1 : -1);
                bool removedFromDictionary = dictionary.Remove(key, out string? dictionaryValue);
                bool removedFromFictionary = fictionary.Remove(key, out string? fictionaryValue);

                Assert.Equal(removedFromDictionary, removedFromFictionary);
                Assert.Equal(dictionaryValue, fictionaryValue);
                Assert.False(fictionary.ContainsKey(key));
                Assert.False(fictionary.TryGetValue(key, out _));
            }
        }

        [Fact]
        public void TryAdd_ShouldBehaveTheSameWay()
        {
            // Arrange
            int count = SampleItems.Length;
            Dictionary<int, string> dictionary = new(count, EqualityComparer<int>.Default);
            using Fictionary<int, string, EqualityComparer<int>> fictionary = new(0, EqualityComparer<int>.Default);

            // Act
            foreach (KeyValuePair<int, string> kv in SampleItems.Mix())
            {
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

        [Fact]
        public void TryGetValue_ShouldBehaveTheSameWay()
        {
            // Arrange
            Dictionary<int, string> dictionary = new(SampleDictionary.Reverse());
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary =
                SampleDictionary.ToList().Mix().ToFictionary();

            // Act
            foreach (KeyValuePair<int, string> kv in SampleDictionary)
            {
                {
                    bool foundInDictionary = dictionary.TryGetValue(kv.Key, out string? dictionaryValue);
                    bool foundInFictionary = fictionary.TryGetValue(kv.Key, out string? fictionaryValue);

                    Assert.Equal(foundInDictionary, foundInFictionary);
                    Assert.Equal(dictionaryValue, fictionaryValue);
                }
                {
                    bool foundInDictionary = dictionary.TryGetValue(-kv.Key, out string? dictionaryValue);
                    bool foundInFictionary = fictionary.TryGetValue(-kv.Key, out string? fictionaryValue);

                    Assert.Equal(foundInDictionary, foundInFictionary);
                    Assert.Equal(dictionaryValue, fictionaryValue);
                }
            }
        }

        [Fact]
        public void Keys_ShouldBehaveTheSameWay()
        {
            // Arrange
            Dictionary<int, string> dictionary = new(SampleDictionary.Reverse());
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary =
                SampleDictionary.ToList().Mix().ToFictionary();

            // Assert
            Assert.Empty(dictionary.Keys.Except(fictionary.Keys));
            Assert.Empty(fictionary.Keys.Except(dictionary.Keys));
        }

        [Fact]
        public void Values_ShouldBehaveTheSameWay()
        {
            // Arrange
            Dictionary<int, string> dictionary = new(SampleDictionary.Reverse());
            Fictionary<int, string, GenericEqualityComparer<int>> fictionary =
                SampleDictionary.ToList().Mix().ToFictionary();

            // Assert
            Assert.Empty(dictionary.Values.Except(fictionary.Values));
            Assert.Empty(fictionary.Values.Except(dictionary.Values));
        }

        [Fact]
        public void Dispose_ShouldClear()
        {
            // Arrange
            Dictionary<int, string> dictionary = new(SampleDictionary.Reverse());

            Fictionary<int, string, GenericEqualityComparer<int>> fictionary = DefaultFictionary<int, string>.Create();
            foreach (KeyValuePair<int, string> item in SampleItems)
            {
                fictionary.TryAdd(item.Key, item.Value);
                fictionary.TryAdd(-item.Key, item.Key.ToString(CultureInfo.InvariantCulture));
            }

            // Act
            fictionary.Dispose();
            Assert.Empty(fictionary);

            foreach (KeyValuePair<int, string> kv in SampleDictionary.ToList().Mix())
                fictionary.Add(kv.Key, kv.Value);

            // Assert
            Assert.Empty(dictionary.Except(fictionary));
            Assert.Empty(fictionary.Except(dictionary));
        }
    }
}
