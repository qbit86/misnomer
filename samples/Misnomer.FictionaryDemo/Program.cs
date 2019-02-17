using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Misnomer.Extensions;

namespace Misnomer
{
    internal static class Program
    {
        private static void Main()
        {
            Fictionary<string, FileSystemInfo, StringOrdinalComparer> fictionary = Directory.EnumerateDirectories(".")
                .Select(s => KeyValuePair.Create(s, (FileSystemInfo)new DirectoryInfo(s)))
                .ToFictionary(new StringOrdinalComparer());
            foreach (string s in Directory.EnumerateFiles("."))
                fictionary.Add(s, new FileInfo(s));

            foreach (KeyValuePair<string, FileSystemInfo> kv in fictionary)
                Console.WriteLine($"{kv.Value.LastWriteTimeUtc:s} {kv.Key}");

            Console.WriteLine();
            if (fictionary.TryGetValue(@".\Program.cs", out FileSystemInfo fsi) && fsi is FileInfo fi)
                Console.WriteLine($"{fi.Name}: {fi.Length} bytes");

            fictionary.Dispose();
        }
    }
}
