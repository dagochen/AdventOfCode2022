namespace AdventOfCode;

public class Day3
{
    private readonly string Input;

    public List<Tuple<char[], char[]>> Rucksacks { get; } = new List<Tuple<char[], char[]>>();
    public int SumOfPriorities => CalculateSum();

    public object GroupSum => CalculateGroupSum();

    private int CalculateGroupSum()
    {
        var sum = 0;
        for (int i = 1; i <= Rucksacks.Count / 3; i++)
        {
            var groupRucksacks = Rucksacks.Take(i * 3).Skip((i - 1) * 3).ToList();
            var rucksack1 = groupRucksacks[0].Item1.Union(groupRucksacks[0].Item2);
            var rucksack2 = groupRucksacks[1].Item1.Union(groupRucksacks[1].Item2);
            var rucksack3 = groupRucksacks[2].Item1.Union(groupRucksacks[2].Item2);


            var groupBadge = (rucksack1.Intersect(rucksack2)).Intersect(rucksack3).First();
            sum += ValueOf(groupBadge);
        }
        return sum;
    }

    private int CalculateSum()
    {
        var sum = 0;
        foreach (var rucksack in Rucksacks)
        {
            var wrongItem = FindWrongItem(rucksack);
            sum += ValueOf(wrongItem);
        }
        return sum;
    }

    public static int ValueOf(char wrongItem)
    {
        if (wrongItem >= 'A' && wrongItem <= 'Z')
            return wrongItem - 64 + 26;

        if (wrongItem >= 'a' && wrongItem <= 'z')
            return wrongItem - 96;
        
        return -1;
    }

    public Day3(string input)
    {
        this.Input = input;
    }

    public char FindWrongItem(Tuple<char[], char[]> rucksack)
    {
        var intersection = rucksack.Item1.Distinct().Intersect(rucksack.Item2.Distinct());
        return intersection.First();
    }

    public Tuple<char[], char[]> GetRucksack(int index)
    {
        return Rucksacks[index];
    }

    public void Process()
    {
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.TrimEntries))
        {
            var first = line.Substring(0, line.Length / 2).ToCharArray();
            var second = line.Substring(line.Length / 2).ToCharArray();
            Rucksacks.Add(Tuple.Create(first, second));
        }
    }
}
