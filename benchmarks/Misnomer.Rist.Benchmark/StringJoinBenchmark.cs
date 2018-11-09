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
        [ArgumentsSource(nameof(Data))]
        public string Move(Rist<string> list)
        {
            string[] array = list.MoveToArray();
            return string.Join(", ", array, 1, 3);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string Linq(Rist<string> list)
        {
            IEnumerable<string> enumerable = list.Skip(1).Take(3);
            return string.Join(", ", enumerable);
        }

        public IEnumerable<Rist<string>> Data()
        {
            yield return CreateAndPopulateList();
        }
    }
}
