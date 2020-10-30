using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Misnomer
{
    internal static class Program
    {
        private static readonly RunMode s_runMode = RunMode.Short;
        private static readonly Jit[] s_jits = { Jit.LegacyJit, Jit.RyuJit };
        private static readonly Platform[] s_platforms = { Platform.X64 };

        private static readonly Runtime[] s_runtimes =
            { ClrRuntime.Net461, ClrRuntime.Net48, CoreRuntime.Core20, CoreRuntime.Core31 };

        private static void Main()
        {
            // https://benchmarkdotnet.org/articles/configs/configs.html

            IEnumerable<Job> jobs = GetJobs();
            IConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .AddAnalyser(EnvironmentAnalyser.Default)
                .AddJob(jobs.ToArray());

            Summary _ = BenchmarkRunner.Run<DateTimePutBenchmark>(config);
        }

        private static IEnumerable<Job> GetJobs()
        {
            foreach (Jit jit in s_jits)
            foreach (Platform platform in s_platforms)
            {
                if (jit == Jit.RyuJit && platform == Platform.X86)
                    continue;

                foreach (Runtime runtime in s_runtimes)
                {
                    if (jit == Jit.LegacyJit &&
                        (runtime.Equals(CoreRuntime.Core20) || runtime.Equals(CoreRuntime.Core31)))
                        continue;

                    yield return new Job(Job.Default)
                        .WithJit(jit)
                        .WithPlatform(platform)
                        .WithRuntime(runtime)
                        .ApplyAndFreeze(s_runMode);
                }
            }
        }
    }
}
