using System.Diagnostics;

namespace AdventOfCode;

public class Day3
{
    private readonly string Input;

    public List<Rucksack> Rucksacks { get; } = new();
    public List<GroupOfElves> Groups { get; } = new();
    public int SumOfPriorities => CalculateSum();

    public object GroupBadgeSum => CalculateGroupSum();

    private int CalculateGroupSum()
    {
        var sum = 0;
        foreach (var group in Groups)
        {
            var groupBadge = group.FindIntersectingBadge();
            sum += PriorityOf(groupBadge);
        }
        return sum;
    }

    private int CalculateSum()
    {
        var sum = 0;
        foreach (var rucksack in Rucksacks)
        {
            var wrongItem = FindWrongItem(rucksack);
            sum += PriorityOf(wrongItem);
        }
        return sum;
    }

    public static int PriorityOf(char item)
    {
        if (item >= 'A' && item <= 'Z')
            return item - 64 + 26;

        if (item >= 'a' && item <= 'z')
            return item - 96;

        throw new UnreachableException();
    }

    public Day3(string input)
    {
        this.Input = input;
    }

    public static char FindWrongItem(Rucksack rucksack)
    {
        var intersection = rucksack.FirstCompartment.Distinct().Intersect(rucksack.SecondCompartment.Distinct());
        return intersection.First();
    }

    public Rucksack GetRucksack(int index)
    {
        return Rucksacks[index];
    }

    public void Process()
    {
        var group = new GroupOfElves();
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.TrimEntries))
        {
            var rucksack = new Rucksack(line.ToCharArray());
            Rucksacks.Add(rucksack);
            group.AddRucksack(rucksack);
            if (group.GroupIsFull)
            {
                Groups.Add(group);
                group = new GroupOfElves();
            }
        }
    }
}

public class Rucksack
{
    public char[] Content { get; set; }
    public char[] FirstCompartment => Content.Take(Content.Length / 2).ToArray();
    public char[] SecondCompartment => Content.TakeLast(Content.Length / 2).ToArray();

    public Rucksack(char[] content)
    {
        this.Content = content;
    }
}

public class GroupOfElves
{
    private const int maxGroupSize = 3;
    private readonly List<Rucksack> rucksacks = new();
    public IReadOnlyList<Rucksack> Rucksacks => rucksacks.AsReadOnly<Rucksack>();

    public void AddRucksack(Rucksack rucksack) => this.rucksacks.Add(rucksack);

    internal char FindIntersectingBadge()
        => (rucksacks[0].Content.Intersect(rucksacks[1].Content)).Intersect(rucksacks[2].Content).First();

    public bool GroupIsFull => this.rucksacks.Count == maxGroupSize;
}
