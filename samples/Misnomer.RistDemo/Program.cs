using System.IO;
using Misnomer.Extensions;
using static System.Console;

namespace Misnomer.RistDemo
{
    internal static class Program
    {
        private static void Main()
        {
            Rist<string> rist = Directory.EnumerateDirectories(".").ToRist();
            rist.AddRange(Directory.EnumerateFiles("."));
            foreach (string item in rist)
                WriteLine(item);

            int count = rist.Count;
            int capacity = rist.Capacity;
            string[] array = rist.MoveToArray();
            int length = array.Length;
            WriteLine($"{nameof(count)}: {count}, {nameof(capacity)}: {capacity}, {nameof(length)}: {length}");

            int newCount = rist.Count;
            int newCapacity = rist.Capacity;
            WriteLine($"{nameof(newCount)}: {newCount}, {nameof(newCapacity)}: {newCapacity}");

            rist.Dispose();
        }
    }
}
