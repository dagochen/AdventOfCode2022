namespace AdventOfCode
{
    public abstract class BaseDay
    {
        public BaseDay(string input, string day)
        {
            Input = input;
            Day = day;
        }

        public string Input { get; }
        public string Day { get; }
        public abstract long Part1 { get; }
        public abstract long Part2 { get; }


        public abstract void Read();
        public abstract void Calculate();

        public void PrintResult()
        {
            Console.WriteLine($"{Day} Part1: {Part1}");
            Console.WriteLine($"{Day} Part2: {Part2}");
        }
    }
}