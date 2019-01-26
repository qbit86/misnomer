using System;
using System.Buffers;
using System.Collections.Generic;
using Xunit;

namespace Misnomer
{
    public sealed class FictionaryTest
    {
        private static double Sqrt5 { get; } = Math.Sqrt(5);

        private static double Phi { get; } = 0.5 * (1.0 + Sqrt5);

        [Fact]
        public void TryAdd_ShouldBehaveTheSameWay()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>(EqualityComparer<int>.Default);
            var fictionary = new Fictionary<int, string, EqualityComparer<int>>(EqualityComparer<int>.Default);
            const int count = 23;

            // Act
            for (int i = 0; i != count; ++i)
            {
                int key = Convert.ToInt32(Math.Pow(Phi, i) / Sqrt5);
                string value = key.ToString();
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

        [Fact]
        public void Indexer_ShouldBehaveTheSameWay()
        {
            // Arrange
            int[] keys = ArrayPool<int>.Shared.Rent(23);
            var dictionary = new Dictionary<int, string>(keys.Length, EqualityComparer<int>.Default);
            var fictionary =
                new Fictionary<int, string, EqualityComparer<int>>(keys.Length, EqualityComparer<int>.Default);
            for (int i = 0; i != keys.Length; ++i)
            {
                int key = Convert.ToInt32(Math.Pow(Phi, i + 2) / Sqrt5);
                keys[i] = key;
                string value = key.ToString();
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
    }
}
