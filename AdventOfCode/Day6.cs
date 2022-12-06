namespace AdventOfCode
{
    public class Day6
    {

        public Day6(string input)
        {
            this.Input = input;
        }

        public string Input { get; private set; }
        public int MarkerPosition { get; set; } = 0;
        public int MessagePosition { get; set; } = 0;

        public void Part1()
        {
            var set = new HashSet<char>();
            for (int i = 3; i < Input.Length; i++)
            {
               
                    if (set.Add(Input[i - 3]) && set.Add(Input[i - 2]) && set.Add(Input[i - 1]) && set.Add(Input[i]))
                    {
                        MarkerPosition = i + 1;
                        break;
                    }
                    set.Clear();
            }
        }

        public void Part2()
        {
            for (int i = 0; i < Input.Length - 14; i++)
            {
                if (Input.Substring(0 + i, 14).ToCharArray().Distinct().Count() == 14)
                {
                    MessagePosition = 14 + i ;
                    break;
                }
            }
        }
    }
}
