using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Misnomer
{
    internal sealed class OrdinalStringComparerObject : IEqualityComparer<string>
    {
        private OrdinalStringComparerObject() { }

        internal static OrdinalStringComparerObject Default { get; } = new OrdinalStringComparerObject();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(string x, string y)
        {
            return string.Equals(x, y, StringComparison.Ordinal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(string obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }
}
