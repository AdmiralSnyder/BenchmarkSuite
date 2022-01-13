#if DEBUG
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
#else
using BDNRunner = BenchmarkDotNet.Running.BenchmarkRunner;
#endif

namespace BenchmarkSuite;

public class BenchmarkRunner
{
    public static void Run<TBenchmarkClass>()
    {
#if DEBUG
            BenchmarkSwitcher.FromAssembly(typeof(GetHexCharBenchmark).Assembly).Run(Environment.GetCommandLineArgs().Skip(1).ToArray(), new DebugInProcessConfig());
#else
        BDNRunner.Run<TBenchmarkClass>();
#endif
    }

}
