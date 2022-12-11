using System.Diagnostics;
using System.Text;

namespace AdventOfCode;

public partial class Day11 
{
    public Day11(string input) => this.Input = input;

    public ulong Part1 { get; set; }
    public ulong Part2 { get; set; }

    public List<Monkey> Monkeys { get; private set; } = new List<Monkey>();
    public string Input { get; }

    public ulong Divisor { get; set; } = 1;

    public void Read()
    {
        var monkey = default(Monkey);
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.TrimEntries))
        {
            if (line.StartsWith("Monkey"))
                monkey = new Monkey(ulong.Parse(line.Split(" ")[1].Substring(0,1)));

            if (line.StartsWith("Starting items:"))
            {
                var itemsString = line.Split(":")[1];
                var items = itemsString.Split(",");
                foreach (var item in items)
                {
                    monkey.Items.Add(ulong.Parse(item));
                }
            }
            if( line.StartsWith("Operation"))
            {
                var operationString = line.Split("= old")[1].Trim();
                
                if (operationString.Equals("* old"))
                {
                    monkey.Operation = (x) => x * x;
                }
                else if (operationString.StartsWith("+"))
                {
                    var amount = ulong.Parse(operationString.Split(" ")[1]);
                    monkey.Operation = (x) => x + amount;
                }
                else if (operationString.StartsWith("*"))
                {
                    var amount = ulong.Parse(operationString.Split(" ")[1]);
                    monkey.Operation = (x) => x * amount;
                }
            }
            if (line.StartsWith("Test"))
            {
                var divisor = ulong.Parse(line.Replace("Test: divisible by ", ""));
                monkey.Test = (x) => x % divisor == 0;
                this.Divisor = this.Divisor * divisor;
            }
            if (line.StartsWith("If true"))
            {
                var targetTrue = ulong.Parse(line.Replace("If true: throw to monkey ", ""));
                monkey.ThrowToWhenTrue = targetTrue;
            }
            if (line.StartsWith("If false"))
            {
                var targetfalse = ulong.Parse(line.Replace("If false: throw to monkey ", ""));
                monkey.ThrowToWhenFalse = targetfalse;
            }
            if (string.IsNullOrEmpty(line))
            {
                Monkeys.Add(monkey);
            }

        }
        Monkeys.Add(monkey);
    }

    public void Calculate(int rounds, bool withDivision = false)
    {
        for (int i = 0; i < rounds; i++) 
        { 
            StartRound(withDivision);
        }
        var toptwo = Monkeys.OrderByDescending(m => m.InspectedItemsCount).Take(2);
        Part2 = toptwo.First().InspectedItemsCount * toptwo.Last().InspectedItemsCount;
        Part1 = toptwo.First().InspectedItemsCount * toptwo.Last().InspectedItemsCount;
    }

    public void StartRound(bool withDivision = false)
    {
        foreach (var monkey in Monkeys)
        {
            monkey.InspectItems(this.Divisor, withDivision);
            foreach (var moveItem in monkey.MoveItemList)
            {
                (ulong item, ulong monk) = moveItem;
                Monkeys.First(m => m.Id == monk).Items.Add(item);
            }
            monkey.MoveItemList.Clear();
        }
    }

    public void PrintResult()
    {
        Console.WriteLine($"{nameof(Day11)} Part1: {Part1}");
        Console.WriteLine($"{nameof(Day11)} Part2: {Part2}");
    }
}

public class Monkey
{
    public Monkey(ulong id)
    {
        this.Id = id;
    }
    public ulong Id { get; set; }
    public List<ulong> Items { get; set; } = new List<ulong>();

    public Func<ulong, ulong> Operation { get; set; }

    public Func<ulong, bool> Test { get; set; }

    public ulong ThrowToWhenTrue { get; set; }
    public ulong ThrowToWhenFalse { get; set; }
    public List<(ulong, ulong)> MoveItemList { get; private set; } = new();

    public ulong InspectedItemsCount = 0;
    internal void InspectItems(ulong divisor, bool withDivision = false)
    {
        foreach (var item in Items)
        {
            InspectedItemsCount++;
            var newItemValue = item;
            if (!withDivision)
                newItemValue = newItemValue % divisor;
            newItemValue = Operation(newItemValue);
            if (newItemValue < 0)
                throw new ArgumentOutOfRangeException(nameof(newItemValue));
            if (withDivision)
                newItemValue /= 3;

            var testResult = Test(newItemValue);
            MoveItemList.Add(new(newItemValue, testResult ? ThrowToWhenTrue : ThrowToWhenFalse));
        }
        Items.Clear();
    }
}