using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
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
            Job clrLegacyJitJob = new Job(Job.Default)
                .With(Runtime.Clr)
                .With(Platform.X86)
                .With(Jit.LegacyJit)
                .ApplyAndFreeze(RunMode.Short);

            Job coreRyuJitJob = new Job(Job.Default)
                .With(Runtime.Core)
                .With(Platform.X64)
                .With(Jit.RyuJit)
                .ApplyAndFreeze(RunMode.Short);

            IConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .With(clrLegacyJitJob)
                .With(coreRyuJitJob);

            Summary _ = BenchmarkRunner.Run<RistBenchmark>(config);
        }
    }
}
