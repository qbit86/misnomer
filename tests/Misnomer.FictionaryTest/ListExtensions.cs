using System;
using System.Collections.Generic;

namespace Misnomer
{
    internal static class ListExtensions
    {
        public static IEnumerable<T> Mix<T>(this IReadOnlyList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            int count = list.Count;
            for (int i = 0, j = count - 1; i <= j; ++i, --j)
            {
                yield return list[j];
                if (i < j)
                    yield return list[i];
            }
        }
    }
}
