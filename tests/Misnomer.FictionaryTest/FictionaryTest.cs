using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace Misnomer
{
    public sealed class FictionaryTest
    {
        private static double Sqrt5 { get; } = Math.Sqrt(5);

        private static double Phi { get; } = 0.5 * (1.0 + Sqrt5);

        [Fact]
        public void Indexer_ShouldBehaveTheSameWay()
        {
            // Arrange
            int[] keys = ArrayPool<int>.Shared.Rent(23);
            var dictionary = new Dictionary<int, string>(EqualityComparer<int>.Default);
            var fictionary = new Fictionary<int, string, EqualityComparer<int>>(EqualityComparer<int>.Default);
            for (int i = 0; i != keys.Length; ++i)
            {
                double rawValue = Math.Pow(Phi, i) / Sqrt5;
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
            const int count = 23;
            var dictionary = new Dictionary<int, string>(count, EqualityComparer<int>.Default);
            var fictionary = new Fictionary<int, string, EqualityComparer<int>>(count, EqualityComparer<int>.Default);

            // Act
            for (int i = 0; i != count; ++i)
            {
                double rawValue = Math.Pow(Phi, i) / Sqrt5;
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
