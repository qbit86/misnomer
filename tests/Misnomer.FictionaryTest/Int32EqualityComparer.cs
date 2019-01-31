using System.Collections.Generic;

namespace Misnomer
{
    internal sealed class Int32EqualityComparer : IEqualityComparer<int>
    {
        internal static Int32EqualityComparer Default { get; } = new Int32EqualityComparer();

        public bool Equals(int x, int y)
        {
            return x == y;
        }

        public int GetHashCode(int obj)
        {
            return unchecked(obj * 397) ^ obj;
        }
    }
}
