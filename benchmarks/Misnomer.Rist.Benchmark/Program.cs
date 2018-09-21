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
            // http://benchmarkdotnet.org/Configs/Configs.htm
            Job job = new Job(Job.Default)
                .ApplyAndFreeze(RunMode.Short);

            IConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .With(job);

            Summary _ = BenchmarkRunner.Run<RistBenchmark>(config);
        }
    }
}
