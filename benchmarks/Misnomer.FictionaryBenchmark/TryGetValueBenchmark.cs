using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Misnomer
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public abstract class TryGetValueBenchmark
    {
        [Benchmark(Baseline = true)]
        [BenchmarkCategory("String")]
        public int StringDictionary()
        {
            throw new NotImplementedException();
        }

        [Benchmark]
        [BenchmarkCategory("String")]
        public int StringFictionary()
        {
            throw new NotImplementedException();
        }
    }
}
