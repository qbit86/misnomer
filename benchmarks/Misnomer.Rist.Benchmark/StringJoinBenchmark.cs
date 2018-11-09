using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Misnomer
{
    public abstract class StringJoinBenchmark
    {
        [Benchmark(Baseline = true)]
        public string Move()
        {
            return string.Empty;
        }

        [Benchmark]
        public string Linq()
        {
            return string.Empty;
        }
    }
}
