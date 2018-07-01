using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable once CheckNamespace

namespace Misnomer
{
    // https://github.com/aspnet/Home/wiki/Engineering-guidelines#unit-tests-and-functional-tests
    public sealed class RistTest
    {
        private static double Sqrt5 { get; } = Math.Sqrt(5);
        private static double Phi { get; } = 0.5 * (1.0 + Sqrt5);

        [Fact]
        public void Add_ShouldBehaveTheSameWay()
        {
            // Arrange
            var list = new List<int>();
            var rist = new Rist<int>();
            const int count = 23;

            // Act
            for (int i = 0; i != count; ++i)
            {
                int item = Convert.ToInt32(Math.Pow(Phi, i) / Sqrt5);
                list.Add(item);
                rist.Add(item);
            }

            // Assert
            Assert.Equal(list, rist);
        }

        [Fact]
        public void AddRange_ShouldBehaveTheSameWay()
        {
            // Arrange
            var list = new List<int>();
            var rist = new Rist<int>();
            IEnumerable<int> collection = new[] {8, 21, 2, 3, 13, 1, 5}.AsNothingButIEnumerable();

            // Act
            list.AddRange(collection);
            rist.AddRange(collection);

            // Assert
            Assert.Equal(list, rist);
        }

        [Fact]
        public void Capacity_ShouldBeEnough()
        {
            // Arrange
            var rist = new Rist<int> {21, 2, 8, 5, 3, 13, 1};

            // Act
            rist.Capacity = 9;

            // Assert
            Assert.InRange(rist.Capacity, rist.Count, int.MaxValue);
        }

        [Fact]
        public void Capacity_ShouldNotChangeContents()
        {
            // Arrange
            var expected = new[] {8, 2, 21, 5, 3, 34, 13};
            var actual = new Rist<int>(expected);

            // Act
            actual.Capacity = 23;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Capacity_ShouldThrow_WhenLessThenSize()
        {
            // Arrange
            var rist = new Rist<int> {21, 2, 8, 5, 3, 13, 1};

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => rist.Capacity = 3);
        }

        [Fact]
        public void Create_WithCollection()
        {
            // Arrange
            IEnumerable<int> collection = new[] {21, 2, 8, 5, 3, 13, 1};
            var expected = new List<int>(collection);

            // Act
            var actual = new Rist<int>(collection);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_WithEnumerable()
        {
            // Arrange
            IEnumerable<int> collection = new[] {21, 2, 8, 5, 3, 13, 1}.AsNothingButIEnumerable();
            var expected = new List<int>(collection);

            // Act
            var actual = new Rist<int>(collection);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_ShouldBehaveTheSameWay()
        {
            // Arrange
            const int count = 23;
            var list = new List<int>(Enumerable.Repeat(int.MinValue, count));
            var rist = new Rist<int>(Enumerable.Repeat(-1, count));

            // Act
            for (int i = 0; i != count; ++i)
            {
                int item = Convert.ToInt32(Math.Pow(Phi, i) / Sqrt5);
                list[i] = item;
                rist[i] = item;
            }

            // Assert
            Assert.Equal(list.Count, rist.Count);
            for (int i = 0; i < rist.Count; ++i)
                Assert.Equal(list[i], rist[i]);
        }

        [Fact]
        public void Insert_ShouldBehaveTheSameWay()
        {
            // Arrange
            var list = new List<int>();
            var rist = new Rist<int>();
            const int count = 23;
            var prng = new Random(nameof(Insert_ShouldBehaveTheSameWay).GetHashCode());

            // Act
            for (int i = 0; i != count; ++i)
            {
                int index = prng.Next(0, i);
                int item = Convert.ToInt32(Math.Pow(Phi, i) / Sqrt5);
                list.Insert(index, item);
                rist.Insert(index, item);
            }

            // Assert
            Assert.Equal(list, rist);
        }
    }
}
