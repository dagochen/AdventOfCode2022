namespace AdventOfCode;

public class Day4
{
    private readonly string Input;

    public Day4(string input) => this.Input = input;

    public int FullOverlapCount { get; set; } = 0;
    public int PartialOverlapCount { get; set; } = 0;

    public void Process()
    {
        var group = new GroupOfElves();
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.TrimEntries))
        {
            (string first, string second) = line.Split(',') switch { var a => (a[0], a[1]) };
            (int firstMin, int firstMax) = first.Split('-') switch { var a => (int.Parse(a[0]), int.Parse(a[1])) };
            (int secondMin, int secondMax) = second.Split('-') switch { var a => (int.Parse(a[0]), int.Parse(a[1])) };

            var pair = new PairOfElves(firstMin, firstMax, secondMin, secondMax);

            if (pair.IsFullOverlap)
                FullOverlapCount++;

            if (pair.IsPartialOverlap)
                PartialOverlapCount++;
        }
    }
}

public class PairOfElves
{
    public PairOfElves(int firstMin, int firstMax, int secondMin, int secondMax)
    {
        this.First = Enumerable.Range(firstMin, (firstMax - firstMin + 1)).ToHashSet();
        this.Second = Enumerable.Range(secondMin, (secondMax - secondMin + 1)).ToHashSet();
    }
    public ISet<int> First { get; set; }
    public ISet<int> Second { get; set; }

    public bool IsFullOverlap => First.IsSubsetOf(Second) || Second.IsSubsetOf(First);

    public bool IsPartialOverlap => First.Overlaps(Second);
}