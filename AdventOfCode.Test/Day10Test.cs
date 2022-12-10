using Shouldly;

namespace AdventOfCode.Test
{
    public class Day10Test
    {
        public Day10 Day { get; }

        public Day10Test()
        {
            this.Day = new Day10(Input.Day10Test);
            Day.Read();
            Day.Calculate();
        }

        [Fact] 
        public void TestPart1()
        {
            Day.Part1.ShouldBe(13140);
        }

        [Theory]
        [InlineData(20, 21, 420)]
        [InlineData(60, 19, 1140)]
        [InlineData(100, 18, 1800)]
        [InlineData(140, 21, 2940)]
        [InlineData(180, 16, 2880)]
        [InlineData(220, 18, 3960)]
        public void TestAfter20Cycles(int testvalue, int expectedX, int expectedCycle)
        {
            Day.ValuesOfX[testvalue].ShouldBe(expectedX);
            Day.ValuesOfCycle[testvalue].ShouldBe(expectedCycle);
        }

        [Fact]
        public void TestPart2()
        {
            Day.PrintLine(0).ShouldBe("##..##..##..##..##..##..##..##..##..##..");
            Day.PrintLine(1).ShouldBe("###...###...###...###...###...###...###.");
            Day.PrintLine(2).ShouldBe("####....####....####....####....####....");
            Day.PrintLine(3).ShouldBe("#####.....#####.....#####.....#####.....");
            Day.PrintLine(4).ShouldBe("######......######......######......####");
            Day.PrintLine(5).ShouldBe("#######.......#######.......#######.....");
        }
    }
}
