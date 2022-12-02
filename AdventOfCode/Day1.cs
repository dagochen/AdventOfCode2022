namespace AdventOfCode
{
    public class Day1
    {
        public Day1(string input)
        {
            Input = input;
        }

        public List<int> Calories { get; set; } = new List<int>();
        public int ElfWithMaxCalories => Calories.IndexOf(MaxCalories) + 1;
        public int MaxCalories => Calories.Max();
        public string Input { get; } = string.Empty;
        public int TopThreeElves => Calories.OrderByDescending(c => c).Take(3).Sum();

        public void Process()
        {
            var calories = 0;
            foreach (var line in Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    Calories.Add(calories);
                    calories = 0;
                }
                else
                    calories += int.Parse(line);
            }
            Calories.Add(calories);
        }
    }
}
