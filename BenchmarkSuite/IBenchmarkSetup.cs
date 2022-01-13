namespace BenchmarkSuite;

internal interface IBenchmarkSetup
{
    void GlobalSetup(object instance);
    void IterationSetup(object instance);
}
