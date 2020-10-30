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
        private static void Main()
        {
            // https://benchmarkdotnet.org/articles/configs/configs.html
            Job clrLegacyJitJob = new Job(Job.Default)
                .WithRuntime(ClrRuntime.Net48)
                .WithPlatform(Platform.X86)
                .WithJit(Jit.LegacyJit)
                .ApplyAndFreeze(RunMode.Short);

            Job clrRyuJitJob = new Job(Job.Default)
                .WithRuntime(ClrRuntime.Net48)
                .WithPlatform(Platform.X64)
                .WithJit(Jit.RyuJit)
                .ApplyAndFreeze(RunMode.Short);

            Job coreRyuJitJob = new Job(Job.Default)
                .WithRuntime(CoreRuntime.Core31)
                .WithPlatform(Platform.X64)
                .WithJit(Jit.RyuJit)
                .WithBaseline(true)
                .ApplyAndFreeze(RunMode.Short);

            IConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .AddDiagnoser(MemoryDiagnoser.Default)
                .AddJob(clrLegacyJitJob)
                .AddJob(clrRyuJitJob)
                .AddJob(coreRyuJitJob);

            Summary _ = BenchmarkRunner.Run<StringJoinBenchmark>(config);
        }
    }
}
