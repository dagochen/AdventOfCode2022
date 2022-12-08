using Shouldly;

namespace AdventOfCode.Test
{
    public class Day8Test
    {
        public Day8Test()
        {
            this.Day = new Day8(Input.Day8Test);
            Day.Read();
            Day.Calculate();
        }

        public Day8 Day { get; }

        [Fact] 
        public void TestPart1()
        {
            Day.Part1.ShouldBe(21);
        }

        [Fact]
        public void TestPart2()
        {
            Day.Part2.ShouldBe(8);
        }
    }
}
