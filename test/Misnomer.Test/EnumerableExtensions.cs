using System.Collections.Generic;

// ReSharper disable CheckNamespace

namespace Misnomer
{
    internal static class EnumerableExtensions
    {
        // Used to prevent returning values out of IEnumerable<>-typed properties
        // that an untrusted caller could cast back to array or List.
        public static IEnumerable<T> AsNothingButIEnumerable<T>(this IEnumerable<T> en)
        {
            foreach (T t in en)
                yield return t;
        }
    }
}
