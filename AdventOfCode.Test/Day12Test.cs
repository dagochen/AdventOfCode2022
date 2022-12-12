using Shouldly;

namespace AdventOfCode.Test
{
    public class Day12Test
    {
        public Day12 Day { get; }

        public Day12Test()
        {
            this.Day = new Day12(Input.Day12Test);
            Day.Read();
            Day.Calculate();
        }

        [Fact]
        public void TestPart1()
        {
            Day.Part1.ShouldBe(31);
        }

        [Fact]
        public void TestPart2()
        {
            Day.Part2.ShouldBe(29);
        }
    }
}
