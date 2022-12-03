namespace AdventOfCode;

public class Day2Minimal : IDay2
{
    private readonly string Input;

    public Day2Minimal(string input)
    {
        this.Input = input;
        Part1.Add("A X", 1 + 3);
        Part1.Add("A Y", 2 + 6);
        Part1.Add("A Z", 3 + 0);
        Part1.Add("B X", 1 + 0);
        Part1.Add("B Y", 2 + 3);
        Part1.Add("B Z", 3 + 6);
        Part1.Add("C X", 1 + 6);
        Part1.Add("C Y", 2 + 0);
        Part1.Add("C Z", 3 + 3);

        Part2.Add("A X", 0 + 3);
        Part2.Add("A Y", 3 + 1);
        Part2.Add("A Z", 6 + 2);
        Part2.Add("B X", 0 + 1);
        Part2.Add("B Y", 3 + 2);
        Part2.Add("B Z", 6 + 3);
        Part2.Add("C X", 0 + 2);
        Part2.Add("C Y", 3 + 3);
        Part2.Add("C Z", 6 + 1);
    }

    public int Score { get; set; } = 0;
    public int ScorePartTwo { get; set; } = 0;
  

    private Dictionary<string, int> Part1 = new Dictionary<string, int>();
    private Dictionary<string, int> Part2 = new Dictionary<string, int>();
    
    public void Process()
    {
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
        {
            this.Score += Part1[line];
            this.ScorePartTwo += Part2[line];
        }
    }
}
