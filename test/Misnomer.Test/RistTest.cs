using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// https://github.com/aspnet/Home/wiki/Engineering-guidelines#unit-tests-and-functional-tests
// ReSharper disable once CheckNamespace
namespace Misnomer
{
    public sealed class RistTest
    {
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
    }
}
