using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using BDNRunner = BenchmarkDotNet.Running.BenchmarkRunner;

namespace BenchmarkSuite;

public class BenchmarkRunner
{
    public static void Run<TBenchmarkClass>(bool runInDebug = false)
    {
#if DEBUG
        if (runInDebug)
        {
            BenchmarkSwitcher.FromAssembly(typeof(GetHexCharBenchmark).Assembly)
                .Run(Environment.GetCommandLineArgs().Skip(1).ToArray(), new DebugInProcessConfig());
            return;
        }
#endif
        BDNRunner.Run<TBenchmarkClass>();
    }

}
