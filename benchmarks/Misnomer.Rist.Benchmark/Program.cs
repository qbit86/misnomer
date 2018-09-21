using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Misnomer
{
    internal static class Program
    {
        private static void Main()
        {
            // https://benchmarkdotnet.org/articles/configs/configs.html
            Job job = new Job(Job.Default)
                .ApplyAndFreeze(RunMode.Short);

            IConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .With(job);

            Summary _ = BenchmarkRunner.Run<RistBenchmark>(config);
        }
    }
}
