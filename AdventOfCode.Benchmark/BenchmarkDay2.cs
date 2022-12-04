// See https://aka.ms/new-console-template for more information
using AdventOfCode;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers.Clr;

var summary = BenchmarkRunner.Run<BenchmarkDay2>();

[MemoryDiagnoser(true)]
public class BenchmarkDay2
{
    [Benchmark(Baseline = true)]
    public void Day2Benchmark()
    {
        var day2 = new Day2(Input.Day2);
        day2.Process();
    }

    [Benchmark]
    public void Day2MinimalBenchmark()
    {
        var day2 = new Day2Minimal(Input.Day2);
        day2.Process();
    }
}

//| Method               | Mean     | Error   | StdDev  | Gen0    | Gen1    | Allocated |
//| ---------------------| ---------| --------| --------| --------| --------| ----------|
//| Day2Benchmark        | 270.5 us | 1.14 us | 1.01 us | 50.7813 | 16.6016 | 313.27 KB |
//| Day2MinimalBenchmark | 106.7 us | 0.37 us | 0.34 us | 16.2354 | 4.0283  | 99.7 KB   |