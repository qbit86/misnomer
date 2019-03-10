using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Misnomer
{
    public sealed class RecyclingTest
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores
        [Fact]
        public void RecycledFictionaries_ShouldBehaveCorrectly()
        {
            // Arrange
            const int count = 13;
            var dictionaries = new Dictionary<DateTimeOffset, long>[count];
            var fictionaries = new Fictionary<DateTimeOffset, long, GenericEqualityComparer<DateTimeOffset>>[count];

            for (int i = 0; i != count; ++i)
            {
                dictionaries[i] = new Dictionary<DateTimeOffset, long>();
                fictionaries[i] = DefaultFictionary<DateTimeOffset, long>.Create();
            }

            // Act
            for (int upper = 1; upper <= count; ++upper)
            for (int i = 0; i < upper; ++i)
            {
                Dictionary<DateTimeOffset, long> d = dictionaries[i];
                int newItemCount = Math.Max(1, d.Count);
                Fictionary<DateTimeOffset, long, GenericEqualityComparer<DateTimeOffset>> f = fictionaries[i];
                for (int k = 0; k != newItemCount; ++k)
                {
                    long value = (upper << 24) | (i << 16) | k;
                    d.TryAdd(DateTimeOffset.FromFileTime(value), value);
                    f.TryAdd(DateTimeOffset.FromFileTime(value), value);
                }
            }

            // Assert
            for (int i = 0; i != count; ++i)
            {
                Dictionary<DateTimeOffset, long> d = dictionaries[i];
                Fictionary<DateTimeOffset, long, GenericEqualityComparer<DateTimeOffset>> f = fictionaries[i];

                Assert.Empty(d.Except(f));
                Assert.Empty(f.Except(d));
            }
        }
#pragma warning restore CA1707
    }
}
