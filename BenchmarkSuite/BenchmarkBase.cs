using BenchmarkDotNet.Attributes;

namespace BenchmarkSuite
{

    /// <summary>
    /// A Benchmark base class that respects attributes that are Benchmark Prepratation steps.
    /// </summary>
    /// <typeparam name="TBenchmarkClass"></typeparam>
    public class BenchmarkBase<TBenchmarkClass>
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
            if (typeof(TBenchmarkClass).GetCustomAttributes(typeof(RandomIntArgsAttribute), true).FirstOrDefault() is IBenchmarkSetup p)
            {
                SetupSteps.Add(p);
            }

            foreach (var prep in SetupSteps)
            {
                prep.GlobalSetup(this);
            }
        }

        private readonly List<IBenchmarkSetup> SetupSteps = new();

        [IterationSetup]
        public void IterationSetup()
        {
            foreach (var prep in SetupSteps)
            {
                prep.IterationSetup(this);
            }
        }
    }
}
