using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace Misnomer
{
    public sealed class FictionaryTest
    {
        private const int Count = 233;

        private static double ScaleFactor { get; } = 1.0;

        private static double CommonRatio { get; } = Math.Pow(2.0, 1.0 / 12.0);

        [Fact]
        public void Indexer_ShouldBehaveTheSameWay()
        {
            // Arrange
            int[] keys = ArrayPool<int>.Shared.Rent(Count);
            var dictionary = new Dictionary<int, string>(EqualityComparer<int>.Default);
            var fictionary = new Fictionary<int, string, EqualityComparer<int>>(EqualityComparer<int>.Default);
            for (int i = 0; i != keys.Length; ++i)
            {
                double rawValue = Math.Pow(CommonRatio, i) * ScaleFactor;
                int key = Convert.ToInt32(rawValue);
                keys[i] = key;
                string value = rawValue.ToString(CultureInfo.InvariantCulture);
                dictionary[key] = value;
                fictionary[key] = value;
            }

            // Act
            for (int i = 0; i != keys.Length; ++i)
            {
                int key = keys[i];
                string dictionaryValue = dictionary[key];
                string fictionaryValue = fictionary[key];
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
                double rawValue = Math.Pow(CommonRatio, i) * ScaleFactor;
                int key = Convert.ToInt32(rawValue);
                string value = rawValue.ToString(CultureInfo.InvariantCulture);
                bool addedToDictionary = dictionary.TryAdd(key, value);
                bool addedToFictionary = fictionary.TryAdd(key, value);
                Assert.Equal(addedToDictionary, addedToFictionary);
            }

            // Assert
            Assert.Equal(dictionary.Count, fictionary.Count);
            Assert.Equal(dictionary, fictionary);
            Assert.Equal(dictionary.Keys, fictionary.Keys);
            Assert.Equal(dictionary.Values, fictionary.Values);
        }
    }
}
