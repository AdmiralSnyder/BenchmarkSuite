using BenchmarkDotNet.Attributes;

namespace BenchmarkSuite;

[RandomIntArgs(0x0, 0xf, nameof(I), RandSeed = 7)]
public class GetHexCharBenchmark : BenchmarkBase<GetHexCharBenchmark>
{
    private const string hexChars = "0123456789abcdef";

    [Benchmark]
    public char GetHexCharFromString() => hexChars[I];

    private int I;

    [Benchmark]
    public char GetHexCharAdd() => I switch
    {
        > 0x9 => (char)('a' + I >> 3),
        _ => (char)('0' + I),
    };

    [Benchmark]
    public char GetHexCharSwitch() => I switch
    {
        0x0 => '0',
        0x1 => '1',
        0x2 => '2',
        0x3 => '3',
        0x4 => '4',
        0x5 => '5',
        0x6 => '6',
        0x7 => '7',
        0x8 => '8',
        0x9 => '9',
        0xa => 'a',
        0xb => 'b',
        0xc => 'c',
        0xd => 'd',
        0xe => 'e',
        0xf => 'f',
        _ => '0',
    };

    //[Benchmark]
    private void OutputI()
    {
        Console.WriteLine(I);
    }
}
