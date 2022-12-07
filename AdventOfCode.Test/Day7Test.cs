using Shouldly;

namespace AdventOfCode.Test
{
    public class Day7Test
    {
        public Day7Test()
        {
            this.Day = new Day7(Input.Day7Test);
        }

        public Day7 Day { get; }

        [Fact] 
        public void TestPart1()
        {
            Day.ProcessPart1();
            Day.SumSizeFor("e").ShouldBe(584);
            Day.SumSizeFor("a").ShouldBe(94853);
            Day.SumSizeFor("d").ShouldBe(24933642);
            Day.SumSizeFor("/").ShouldBe(48381165);
        }

        [Fact]
        public void TestPart2()
        {
            Day.ProcessPart2();
            Day.Part2.ShouldBe(2);
        }
    }
}
