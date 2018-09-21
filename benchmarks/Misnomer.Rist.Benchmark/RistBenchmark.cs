using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Misnomer
{
    [MemoryDiagnoser]
    public abstract class RistBenchmark
    {
        // https://en.wikipedia.org/wiki/Collatz_conjecture
        private static int CollatzNext(int n)
        {
            return n % 2 == 0 ? n / 2 : 3 * n + 1;
        }

        [Benchmark(Baseline = true)]
        public List<char> List()
        {
            return Core<List<char>>();
        }

        [Benchmark]
        public Rist<char> Rist()
        {
            return Core<Rist<char>>();
        }

        private TList Core<TList>() where TList : IList<char>, new()
        {
            var list = new TList();

            return list;
        }
    }
}
