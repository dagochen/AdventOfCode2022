using Shouldly;

namespace AdventOfCode.Test
{
    public class Day4Test
    {
        public Day4 Day4 { get; private set; }
        public Day4Test()
        {
            this.Day4 = new Day4(Input.Day4Test);
            Day4.Process();
        }

        [Fact]
        public void Day4TestDataWorking()
        {
            Day4.FullOverlapCount.ShouldBe(2);
            Day4.PartialOverlapCount.ShouldBe(4);
        }
    }
}
