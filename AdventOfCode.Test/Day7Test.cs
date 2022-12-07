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
            Day.Directories["//a/e"].Size.ShouldBe(584);
            Day.Directories["//a"].Size.ShouldBe(94853);
            Day.Directories["//d"].Size.ShouldBe(24933642);
            Day.Directories["/"].Size.ShouldBe(48381165);
            Day.Part1.ShouldBe(95437);
        }

        [Fact]
        public void TestPart2()
        {
            Day.ProcessPart1();

            Day.ProcessPart2();
            Day.Part2.ShouldBe(24933642);
        }
    }
}
