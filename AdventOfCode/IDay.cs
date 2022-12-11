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
        


        public abstract void Read();
        public abstract void Calculate();

        public abstract void PrintResult();
        
    }
}