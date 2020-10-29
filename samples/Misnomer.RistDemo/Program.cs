using System;
using System.Diagnostics;
using System.IO;
using Misnomer.Extensions;

namespace Misnomer
{
    internal static class Program
    {
        private static void Main()
        {
            using Rist<string> rist = Directory.EnumerateDirectories(".").ToRist();
            rist.AddRange(Directory.EnumerateFiles("."));
            rist.Sort((left, right) => string.CompareOrdinal(right, left));

            foreach (string item in rist)
                Console.WriteLine(item);

            int count = rist.Count;
            string[] array = rist.MoveToArray();
            int length = array.Length;
            Debug.Assert(count <= length);
            Console.WriteLine($"{nameof(count)}: {count}, {nameof(length)}: {length}");

            int capacity = rist.Capacity;
            Debug.Assert(capacity == 0);
            Console.WriteLine($"{nameof(capacity)}: {capacity}");
        }
    }
}
