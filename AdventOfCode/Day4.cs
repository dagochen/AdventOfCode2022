using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace AdventOfCode;

public class Day4
{
    private readonly string Input;

    public Day4(string input)
    {
        this.Input = input;
    }

    public int FullContainCount { get; set; } = 0;
    public int PartialOverlapCount { get; set; } = 0;

    public void Process()
    {
        var group = new GroupOfElves();
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.TrimEntries))
        {
            (string first, string second) = line.Split(',') switch { var a => (a[0], a[1]) };
            (int firstMin, int firstMax) = first.Split('-') switch { var a => (int.Parse(a[0]), int.Parse(a[1])) };
            (int secondMin, int secondMax) = second.Split('-') switch { var a => (int.Parse(a[0]), int.Parse(a[1])) };

            if ((firstMin >= secondMin && firstMax <= secondMax) || (secondMin >= firstMin && secondMax <= firstMax))
                FullContainCount++;

            if ((firstMin >= secondMin && firstMin <= secondMax) || (firstMax >= secondMin && firstMax <= secondMax))
                PartialOverlapCount++;
            else if ((secondMin >= firstMin && secondMin <= firstMax) || (secondMax >= firstMin && secondMax <= firstMax))
                PartialOverlapCount++;
        }
    }
}
