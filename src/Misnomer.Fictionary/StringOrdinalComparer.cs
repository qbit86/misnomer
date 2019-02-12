using System;
using System.Collections.Generic;

namespace Misnomer
{
#pragma warning disable CA1815, CA2231
    public readonly struct StringOrdinalComparer : IComparer<string>, IEqualityComparer<string>,
        IEquatable<StringOrdinalComparer>
#pragma warning restore CA2231, CA1815
    {
        public int Compare(string x, string y)
        {
            return string.CompareOrdinal(x, y);
        }

        public bool Equals(string x, string y)
        {
            return string.Equals(x, y, StringComparison.Ordinal);
        }

        public int GetHashCode(string obj)
        {
            return obj?.GetHashCode() ?? 0;
        }

        public bool Equals(StringOrdinalComparer other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is StringOrdinalComparer;
        }

        public override int GetHashCode()
        {
            return typeof(StringOrdinalComparer).GetHashCode();
        }
    }
}
