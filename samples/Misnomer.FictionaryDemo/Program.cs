using System;
using System.Collections.Generic;
using System.IO;
using Misnomer.Extensions;

namespace Misnomer
{
    internal static class Program
    {
        private static void Main()
        {
            IEnumerable<FileInfo> currentDirFiles =
                new DirectoryInfo(Environment.CurrentDirectory).EnumerateFiles();
            using Fictionary<string, FileInfo, OrdinalStringComparer> fictionary = currentDirFiles
                .ToFictionary(fi => fi.Name, new OrdinalStringComparer());

            IEnumerable<FileInfo> userDirFiles =
                new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)).EnumerateFiles();
            foreach (FileInfo fi in userDirFiles)
                fictionary.TryAdd(fi.Name, fi);

            foreach (KeyValuePair<string, FileInfo> kv in fictionary)
                Console.WriteLine($"{kv.Key}\t{kv.Value.Directory.FullName}");

            Console.WriteLine();
            if (fictionary.TryGetValue(".gitconfig", out FileInfo value))
                Console.WriteLine($"{value.Name}: {value.Length} bytes");
        }
    }
}
