using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Misnomer
{
    public class StringJoinBenchmark
    {
        private static Rist<string> CreateAndPopulateList()
        {
            var list = new Rist<string>();
            // Populating, filtering, sorting, grouping...
            list.Add("Camille");
            list.Add("Annie");
            list.Add("Sara");
            list.Add("Katrin");
            list.Add("Kari");

            return list;
        }

        [Benchmark(Baseline = true)]
        public string Move()
        {
            using Rist<string> list = CreateAndPopulateList();

            string[] array = list.MoveToArray();
            return string.Join(", ", array, 1, 3);
        }

        [Benchmark]
        public string Copy()
        {
            using Rist<string> list = CreateAndPopulateList();

            string[] array = list.ToArray();
            return string.Join(", ", array, 1, 3);
        }

        [Benchmark]
        public string Linq()
        {
            using Rist<string> list = CreateAndPopulateList();

            IEnumerable<string> enumerable = list.Skip(1).Take(3);
            return string.Join(", ", enumerable);
        }
    }
}
