namespace AdventOfCode
{
    public class Day5
    {
        public string Input { get; }
        public List<Stack<char>> Stacks { get; set; } = new();

        public Day5(string input)
        {
            this.Input = input;
        }

        public void Process()
        {
            Read();
            //Move();
        }

        private void Move()
        {
            throw new NotImplementedException();
        }

        private void Read()
        {
            var dict = new Dictionary<int, string>();
            var index = 0;
            foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                dict.Add(index, line);
                if (line.Trim().StartsWith("1"))
                {
                    var anzahl = int.Parse(line.Substring(line.Length-2));
                    for (int i = 0; i < 3; i++)
                        Stacks.Add(new());
                }

                index++;
            }
        }

        
    }
}
