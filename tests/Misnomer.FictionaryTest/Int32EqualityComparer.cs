using System.Collections.Generic;

namespace Misnomer
{
    internal sealed class Int32EqualityComparer : IEqualityComparer<int>
    {
        internal static Int32EqualityComparer Default { get; } = new();

        public bool Equals(int x, int y) => x == y;

        public int GetHashCode(int obj) => unchecked(obj * 397) ^ obj.GetHashCode();
    }
}
