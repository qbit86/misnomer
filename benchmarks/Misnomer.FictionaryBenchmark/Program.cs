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
        private static readonly Platform[] s_platforms = { Platform.X86, Platform.X64 };
        private static readonly Runtime[] s_runtimes = { Runtime.Clr, Runtime.Core };

        private static void Main()
        {
            // https://benchmarkdotnet.org/articles/configs/configs.html

            IEnumerable<Job> jobs = GetJobs();
            IConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .With(EnvironmentAnalyser.Default)
                .With(jobs.ToArray());

            Summary _ = BenchmarkRunner.Run<DateTimeTryGetValueBenchmark>(config);
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
                    if (jit == Jit.LegacyJit && runtime.Equals(Runtime.Core))
                        continue;

                    yield return new Job(Job.Default)
                        .With(jit)
                        .With(platform)
                        .With(runtime)
                        .ApplyAndFreeze(s_runMode);
                }
            }
        }
    }
}
