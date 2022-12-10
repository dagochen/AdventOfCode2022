using System.Diagnostics;
using System.Text;

namespace AdventOfCode;

public partial class Day10 : BaseDay
{
    public Day10(string input) : base(input, nameof(Day10)) {}

    public int X { get; set; } = 1;
    public int Cycle { get; set; } = 1;

    private const string LitPixel = "#";
    private const string DarkPixel = ".";
    public string[,] Display = new string[6,41];

    public override long Part1 => ValuesOfCycle[20] + ValuesOfCycle[60] + ValuesOfCycle[100] 
        + ValuesOfCycle[140] + ValuesOfCycle[180] + ValuesOfCycle[220];

    public override long Part2 => 0;

    public Dictionary<int, int> ValuesOfX { get; private set; } = new();
    public Dictionary<int, int> ValuesOfCycle { get; private set; } = new();

    public override void Read()
    {
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
        {
            if (line.Equals("noop"))
                IncreaseCycle();
            if (line.StartsWith("addx"))
            {
                var amount = int.Parse(line.Split(" ")[1]);
                IncreaseCycle();
                IncreaseCycle();
                X += amount;
            }
        }
        PrintDisplay();
    }

    private void PrintDisplay()
    {
        var sb = new StringBuilder();
        for (int row = 0; row < 6; row++) 
        {
            sb.Append(PrintLine(row));
            sb.Append(Environment.NewLine);

        }
        Console.WriteLine(sb.ToString());
    }

    private void IncreaseCycle()
    {
        if (Cycle < 241)
        {
            var c = Cycle - 1;
            int y = c / 40;
            int x = c % 40;
            bool isPixelActive = (X-1) == x || X == x || (X+1) == x;
            Display[y, x] = isPixelActive ? LitPixel : DarkPixel;
        }

        ValuesOfX.Add(Cycle, X);
        ValuesOfCycle.Add(Cycle, Cycle * X);
        Cycle++;
    }

    public override void Calculate()
    {
        // Calculation is done in read (on the fly)
    }

    public string PrintLine(int index)
    {
        var sb = new StringBuilder();
            for (int col = 0; col < 40; col++)
            {
                sb.Append(Display[index, col]);
            }
        return sb.ToString();
    }
}

    