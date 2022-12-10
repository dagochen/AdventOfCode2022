using System.Diagnostics;

namespace AdventOfCode;

public class Day9 : BaseDay
{
    public Day9(string input) : base(input, nameof(Day9)) {}

    public override long Part1 => VisitedFields.Count;
    public override long Part2 => VisitedFieldsPart2.Count;

    public List<Command> Commands = new();

    public Knot Head { get; set; } = new Knot("H", null!);
    public List<Knot> Tails { get; set; } = new();

    public ISet<Field> VisitedFields { get; set; } = new HashSet<Field>() { new(0,0)};
    public ISet<Field> VisitedFieldsPart2 { get; set; } = new HashSet<Field>() { new(0,0)};

    public override void Read()
    {
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
        {
            if (String.IsNullOrEmpty(line)) continue;

            (var dir, var steps) = line.Split(' ') switch { var a => (a[0], int.Parse(a[1])) };
            var direction = MapToDirection(dir);
            Commands.Add(new(direction, steps));
        }

        Tails.Clear();
        Tails.Add(new("1", Head));
        Tails.Add(new("2", Tails[0]));
        Tails.Add(new("3", Tails[1]));
        Tails.Add(new("4", Tails[2]));
        Tails.Add(new("5", Tails[3]));
        Tails.Add(new("6", Tails[4]));
        Tails.Add(new("7", Tails[5]));
        Tails.Add(new("8", Tails[6]));
        Tails.Add(new("9", Tails[7]));
    }

    private static Direction MapToDirection(string dir) => dir switch
    {
        "R" => Direction.Right,
        "L" => Direction.Left,
        "D" => Direction.Down,
        "U" => Direction.Up,
        _ => throw new UnreachableException()
    };

    public override void Calculate()
    {
        foreach (var cmd in Commands)
        {
            ExecuteCommand(cmd);
            //PrintGrid(cmd);
        }
    }

    private void PrintGrid(Command cmd)
    {
        Console.WriteLine();
        Console.WriteLine($"== {cmd.Direction} {cmd.Steps} ==");
        Console.WriteLine();
        for (int y = 21; y >= 0; y--)
        {
            for (int x = 0; x < 26; x++)
            {
                Knot? k = Head.X == x && Head.Y == y ? Head : Tails.FirstOrDefault(t => t.X == x & t.Y == y);
                Console.Write(k?.Name ?? ".");
            }
            Console.WriteLine();
        }
    }

    public void ExecuteCommand(Command cmd)
    {
        for (int i = 0; i < cmd.Steps; i++)
        {
            Head.Move(cmd.Direction);
            foreach (var knot in Tails)
            {
                knot.Follow();
                if (knot.Name == "1")
                    VisitedFields.Add(new(knot.X, knot.Y));
                if (knot.Name == "9")
                    VisitedFieldsPart2.Add(new(knot.X, knot.Y));
            }
            //PrintStep(cmd, i);
        }
    }

    private void PrintStep(Command cmd, int i)
    {
        Console.WriteLine();
        Console.WriteLine($"XXX {cmd.Direction} {i + 1}/{cmd.Steps} XXX");
        Console.WriteLine();
        for (int y = 21; y >= 0; y--)
        {
            for (int x = 0; x < 26; x++)
            {
                Knot? k = Head.X == x && Head.Y == y ? Head : Tails.FirstOrDefault(t => t.X == x & t.Y == y);
                Console.Write(k?.Name ?? ".");
            }
            Console.WriteLine();
        }
    }
}

public record Command(Direction Direction, int Steps);

public class Knot
{
    public Knot(string name, Knot parent)
    {
        Name = name;
        X = 0;
        Y = 0;
        Parent = parent;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public Knot Parent { get; set; }
    public string Name { get; internal set; }

    public void Move(Direction direction) 
    {
        if (direction == Direction.Right)
            X++;
        else if (direction == Direction.Left)
            X--;
        else if (direction == Direction.Up)
            Y++;
        else if (direction == Direction.Down)
            Y--;
    }

    internal void Follow()
    {
        var distanceX = Parent.X - X;
        var distanceY = Parent.Y - Y;

        if (Math.Abs(distanceX) > 1 || Math.Abs(distanceY) > 1)
        {
            this.X += Math.Sign(distanceX);
            this.Y += Math.Sign(distanceY);
        }
    }
}

public record Field(int X, int Y);

public enum Direction
{
    Up,
    Down,
    Right,
    Left
}