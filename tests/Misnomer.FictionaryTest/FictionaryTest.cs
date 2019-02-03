using System;
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

        private static KeyValuePair<int, string>[] s_sampleItems;

        private static ImmutableDictionary<int, string> s_sampleDictionary;

        private static double ScaleFactor { get; } = 1.0;

        private static double CommonRatio { get; } = Math.Pow(2.0, 1.0 / 12.0);

        private static KeyValuePair<int, string>[] SampleItems =>
            s_sampleItems ?? (s_sampleItems = CreateSampleItems());

        private static ImmutableDictionary<int, string> SampleDictionary =>
            s_sampleDictionary ?? (s_sampleDictionary = CreateSampleDictionary());

        private static double Geometric(int i)
        {
            return Math.Pow(CommonRatio, i) * ScaleFactor;
        }

        private static KeyValuePair<int, string>[] CreateSampleItems()
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

        private static ImmutableDictionary<int, string> CreateSampleDictionary()
        {
            ImmutableDictionary<int, string>.Builder builder =
                ImmutableDictionary.CreateBuilder<int, string>(EqualityComparer<int>.Default);

            foreach (KeyValuePair<int, string> kv in SampleItems)
                builder[kv.Key] = kv.Value;

            return builder.ToImmutable();
        }

        [Fact]
        public void Create_WithDictionary()
        {
            // Arrange
            var keyComparer = new GenericEqualityComparer<int>();

            // Act
            var dictionary = new Dictionary<int, string>(SampleDictionary, Int32EqualityComparer.Default);
            var fictionary = new Fictionary<int, string, GenericEqualityComparer<int>>(SampleDictionary, keyComparer);

            // Assert
            Assert.Empty(dictionary.Except(fictionary));
            Assert.Empty(fictionary.Except(dictionary));
        }

        [Fact]
        public void Indexer_ShouldBehaveTheSameWay()
        {
            // Arrange
            var dictionary = new Dictionary<string, double>(StringComparer.Ordinal);
            var fictionary = new Fictionary<string, double, StringComparer>(StringComparer.Ordinal);

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
            var fictionary = new Fictionary<int, string, GenericEqualityComparer<int>>(SampleDictionary, default);
            int count = SampleItems.Length;

            // Act
            for (int i = 0; i != count; ++i)
            {
                int key = SampleItems[i].Key * (i % 2 == 0 ? 1 : -1);
                bool d = dictionary.Remove(key);
                bool f = fictionary.Remove(key);

                Assert.Equal(d, f);
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
