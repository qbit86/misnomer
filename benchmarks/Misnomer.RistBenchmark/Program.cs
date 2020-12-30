using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using RunMode = BenchmarkDotNet.Jobs.RunMode;

namespace Misnomer
{
    internal static class Program
    {
        private static readonly RunMode s_runMode = RunMode.Short;

        private static void Main()
        {
            // https://benchmarkdotnet.org/articles/configs/configs.html

            Job[] jobs = GetJobs();
            IConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .AddDiagnoser(MemoryDiagnoser.Default)
                .AddAnalyser(EnvironmentAnalyser.Default)
                .AddJob(jobs);

            Summary _ = BenchmarkRunner.Run<RistBenchmark>(config);
        }

        private static Job[] GetJobs()
        {
            Job[] jobs =
            {
                new Job(Job.Default).WithJit(Jit.LegacyJit).WithRuntime(ClrRuntime.Net461),
                new Job(Job.Default).WithJit(Jit.LegacyJit).WithRuntime(ClrRuntime.Net48),
                new Job(Job.Default).WithJit(Jit.RyuJit).WithRuntime(CoreRuntime.Core20),
                new Job(Job.Default).WithJit(Jit.RyuJit).WithRuntime(CoreRuntime.Core31),
            };

            foreach (Job job in jobs)
                job.ApplyAndFreeze(s_runMode);

            return jobs;
        }
    }
}
