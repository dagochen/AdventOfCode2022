namespace AdventOfCode;

public class Day2
{
    private readonly string Input;

    public Day2(string input)
    {
        this.Input = input;
        Part1.Add("A", RPS.Rock);
        Part1.Add("B", RPS.Paper);
        Part1.Add("C", RPS.Scissor);
        Part1.Add("X", RPS.Rock);
        Part1.Add("Y", RPS.Paper);
        Part1.Add("Z", RPS.Scissor);

        Part2.Add("X", Result.Loss);
        Part2.Add("Y", Result.Draw);
        Part2.Add("Z", Result.Win);
    }

    public int Score { get; set; } = 0;
    public int ScorePartTwo { get; set; } = 0;
  

    private Dictionary<string, RPS> Part1 = new Dictionary<string, RPS>();
    private Dictionary<string, Result> Part2 = new Dictionary<string, Result>();
    
    public void Process()
    {
        foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
        {
            (string first, string second) = line.Split(' ') switch { var a => (a[0], a[1]) };

            var enemyAction = Part1[first];
            var myAction = Part1[second];
            var outcome = GetOutcome(enemyAction, myAction);
            this.Score += (int)myAction + (int)outcome;

            outcome = Part2[second];
            myAction = GetAction(enemyAction, outcome);
            this.ScorePartTwo += (int)myAction + (int)outcome;
        }
    }

    private static Result GetOutcome(RPS enemyAction, RPS myAction) => (enemyAction, myAction) switch
    {
        (RPS.Paper, RPS.Rock) or (RPS.Scissor, RPS.Paper) or (RPS.Rock, RPS.Scissor) => Result.Loss,
        (RPS.Rock, RPS.Rock) or (RPS.Paper, RPS.Paper) or (RPS.Scissor, RPS.Scissor) => Result.Draw,
        (RPS.Scissor, RPS.Rock) or (RPS.Rock, RPS.Paper) or (RPS.Paper, RPS.Scissor) => Result.Win,
        _ => throw new ArgumentOutOfRangeException()
    };

    private static RPS GetAction(RPS enemyAction, Result outcome) => (enemyAction, outcome) switch
    {
        (RPS.Scissor, Result.Loss) or (RPS.Rock, Result.Win) or (RPS.Paper, Result.Draw) => RPS.Paper,
        (RPS.Paper, Result.Loss) or (RPS.Scissor, Result.Win)  or (RPS.Rock, Result.Draw) => RPS.Rock,
        (RPS.Paper, Result.Win) or (RPS.Rock, Result.Loss) or (RPS.Scissor, Result.Draw) => RPS.Scissor,
        _ => throw new ArgumentOutOfRangeException()
    };
}

internal enum RPS
{
    Rock = 1,
    Paper = 2,
    Scissor = 3
}

internal enum Result
{
    Win = 6,
    Loss = 0,
    Draw = 3
}
