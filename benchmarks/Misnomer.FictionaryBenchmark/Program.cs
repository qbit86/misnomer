using System.Collections.Generic;
using System.Linq;
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
        private static readonly Runtime[] s_runtimes = { Runtime.Clr, Runtime.Core };
        private static readonly Jit[] s_jits = { Jit.LegacyJit, Jit.RyuJit };
        private static readonly Platform[] s_platforms = { Platform.X86, Platform.X64 };

        private static void Main()
        {
            // https://benchmarkdotnet.org/articles/configs/configs.html

            IEnumerable<Job> jobs = GetJobs();
            IConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .With(MemoryDiagnoser.Default)
                .With(jobs.ToArray());

            Summary _ = BenchmarkRunner.Run<TryGetValueBenchmark>(config);
        }

        private static IEnumerable<Job> GetJobs()
        {
            foreach (Runtime runtime in s_runtimes)
            foreach (Jit jit in s_jits)
            foreach (Platform platform in s_platforms)
                yield return new Job(Job.Default)
                    .With(runtime)
                    .With(jit)
                    .With(platform)
                    .ApplyAndFreeze(s_runMode);
        }
    }
}
