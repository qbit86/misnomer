using System;
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
                int item = Convert.ToInt32(Math.Pow(Phi, i) / Sqrt5);
                string value = item.ToString();
                dictionary.TryAdd(item, value);
                fictionary.TryAdd(item, value);
            }

            // Assert
            Assert.Equal(dictionary, fictionary);
        }
    }
}
