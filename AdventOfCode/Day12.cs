using System.Diagnostics;
using System.Text;

namespace AdventOfCode;

public partial class Day12
{
    public Day12(string input) => this.Input = input;

    public long Part1 { get; set; }
    public long Part2 { get; set; }

    public string Input { get; }

    public Dictionary<int, Node> Nodes { get; set; } = new Dictionary<int, Node>();  

    public void Read()
    {
        var grid = new List<char[]>();
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.TrimEntries))
        {
            grid.Add(line.ToCharArray());
        }

        for (int i = 0; i < grid.Count; i++)
        {
            var array = grid[i];
            for (int j = 0; j < array.Length; j++)
            {
                var node = new Node(j,i, array[j]);
                Nodes.Add(j + i*(1000), node);
            }
        }
        AddNeigbors();
    }

    private void AddNeigbors()
    {
        foreach (var node in Nodes.Values)
        {
            Nodes.TryGetValue((node.X - 1) + node.Y * 1000, out var left);
            node.AddNeighbor(left);
            Nodes.TryGetValue((node.X + 1) + node.Y * 1000, out var right);
            node.AddNeighbor(right);
            Nodes.TryGetValue(node.X + (node.Y-1) * 1000, out var top);
            node.AddNeighbor(top);
            Nodes.TryGetValue(node.X + (node.Y+1) * 1000, out var bottom);
            node.AddNeighbor(bottom);
        }
    }

    public int PrintCount { get; set; } = 0;

    public void PrintGrid()
    {
        PrintCount++;

        var sb = new StringBuilder();
        sb.Append($"--- Begin Print: {PrintCount} ---");
        sb.Append(Environment.NewLine);
        int x = Nodes.Values.Select(n => n.X).Max();
        int y = Nodes.Values.Select(n => n.Y).Max();

        for (int row = 0; row <= y; row++)
        {
            for (int col = 0; col <= x; col++)
            {
                sb.Append(Nodes[col + row * 1000].Distance == int.MaxValue ? "0" : Nodes[col + row * 1000].Distance + " ");
            }
            sb.Append(Environment.NewLine);
        }
        sb.Append("--- End Print ---");
        sb.Append(Environment.NewLine);

        Console.Write(sb.ToString());
    }

    public void Calculate()
    {
        var sw = Stopwatch.StartNew();
        var dict = new Dictionary<int, int>();
        var startPoints = Nodes.Values.Where(n => n.Char == 'a' || n.Char == 'S').ToList();
        foreach (var start in startPoints)
        {
            ResetNodeDistances();
            start.Distance = 0;

            var neighbors = start.Neighbors.Where(n => n.Distance > start.Distance).ToList();
            ProcessNeighborsOf(neighbors, start.Distance);

            var end = Nodes.Values.Single(n => n.Char == 'E');

            dict.Add(start.X + start.Y * 10000, end.Distance);
        }
        var oldStart = Nodes.Values.Single(n => n.Char == 'S');

        Part1 = dict[oldStart.X + oldStart.Y * 10000];
        Part2 = dict.Values.Min();
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
    }

    private void ResetNodeDistances()
    {
        foreach (var node in Nodes.Values)
        {
            node.Distance = int.MaxValue;
        }
    }

    private void ProcessNeighborsOf(List<Node> neighbors, int i)
    {
        if (neighbors.Count == 0)
            return;
        PrintGrid();
        foreach (var neighbor in neighbors)
        {
            neighbor.Distance = Math.Min(neighbor.Distance, i + 1);
        }
        var nextNeighbors = neighbors.SelectMany(n => n.Neighbors.Where(n => n.Distance > i+1).Distinct()).Distinct().ToList();
        ProcessNeighborsOf(nextNeighbors, i+1);
    }

    public void PrintResult()
    {
        Console.WriteLine($"{nameof(Day12)} Part1: {Part1}");
        Console.WriteLine($"{nameof(Day12)} Part2: {Part2}");
    }
}

public class Node
{
    public Node(int x, int y, char c)
    {
        this.X = x;
        this.Y = y;
        this.Char = c;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public char Char { get; set; }
    public int Elevation => GetElevationFromChar(this.Char);
    public List<Node> Neighbors { get; private set; } = new List<Node>();
    public int Distance { get; internal set; } = int.MaxValue;

    internal void AddNeighbor(Node? node)
    {
        if (node is not null && (node.Elevation) <= (this.Elevation+1))
            this.Neighbors.Add(node);
    }

    private int GetElevationFromChar(char c)
       => c switch
       {
           'S' => 1,
           'E' => 26,
           _ => (c - 96)
       };
}
