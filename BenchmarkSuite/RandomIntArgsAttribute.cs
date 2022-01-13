using System.Reflection;

namespace BenchmarkSuite;

/// <summary>
/// initializes a field with a random int value from an interval
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
internal class RandomIntArgsAttribute : Attribute, IBenchmarkSetup
{
    public RandomIntArgsAttribute(int from, int to, string fieldName) => (From, To, FieldName) = (from, to, fieldName);

    public int RandSeed { get; set; } = Environment.TickCount;

    public int To { get; }
    public int From { get; }
    public string FieldName { get; }

    private Random? Rand;

    private FieldInfo? Field;

    public void IterationSetup(object instance)
    {
        var value = Rand!.Next(From, To + 1);
        Field?.SetValue(instance, value);
    }

    public void GlobalSetup(object instance)
    {
        Rand = new Random(RandSeed);
        Field = instance.GetType().BaseType?.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
            .SingleOrDefault(f => f.Name == FieldName);
    }
}
