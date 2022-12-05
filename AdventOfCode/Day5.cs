using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day5
    {
        public string Input { get; }
        public List<Stack<char>> Stacks { get; set; } = new();
        public List<Instruction> Instructions { get; set; } = new();
        public string Solution { get; private set; } = "";

        public Day5(string input)
        {
            this.Input = input;
        }
    
        public void Process()
        {
            ReadInput();
            Part1Crane();
            CalculateSolution();
        }

        public void Part1Crane()
        {
            foreach (var instruction in Instructions)
            {
                MoveFromTo(instruction.Count, instruction.From, instruction.To);
            }
        }

        public void Part2Crane()
        {
            foreach (var instruction in Instructions)
            {
                MoveFromToNewCrane(instruction.Count, instruction.From, instruction.To);
            }
        }

        public void ReadInput()
        {
            var dict = new Dictionary<int, string>();
            var index = 0;
            var isStackRead = true;
            var regex = new Regex("\\d+");

            foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                if (line.Trim().StartsWith("1"))
                {
                    var anzahl = int.Parse(line.Substring(line.Length - 2));
                    for (int i = 0; i < anzahl; i++)
                        Stacks.Add(new());
                    isStackRead = false;
                    FillInitialStacks(dict);
                }
                if (isStackRead)
                    dict.Add(index, line);

                if (line.Trim().StartsWith("move"))
                {
                    var result = regex.Matches(line);
                    Instructions.Add(new(int.Parse(result[0].Value), int.Parse(result[1].Value), int.Parse(result[2].Value)));
                }

                index++;
            }
        }

        public void CalculateSolution()
        {
            foreach (var stack in Stacks)
            {
                this.Solution = String.Concat(this.Solution, stack.Peek());
            }
        }

        private void MoveFromToNewCrane(int count, int from, int to)
        {
            var s = new Stack<char>();
            for (int i = 1; i <= count; i++) 
            {
                s.Push(Stacks[from - 1].Pop()); 
            }

            foreach (var c in s)
                Stacks[to-1].Push(c);
          
        }

        private void FillInitialStacks(Dictionary<int, string> dict)
        {
            for (int i = dict.Count - 1; i >= 0; i--)
            {
                var line = dict[i].Replace("     ","   ").Replace("] [", "][");
                for (int j = 0; j < line.Length; j++)
                {
                    var c = line[j];
                    if (c >= 'A' && c <= 'Z')
                        Stacks[j / 3].Push(c);
                }
            }
        }

        private void MoveFromTo(int count, int from, int to)
        {
            for(int i=0; i < count; i++)
            {
                var move = Stacks[from-1].Pop();
                Stacks[to-1].Push(move);
            }
        }
    }

    public class Instruction
    {
        public Instruction(int count, int from, int to)
        {
            this.Count = count;
            this.From = from;
            this.To = to;
        }

        public int Count { get; set; } = 0;
        public int From { get; set; } = 0;
        public int To { get; set; } = 0;
    }
}
