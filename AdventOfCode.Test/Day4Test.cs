using Shouldly;

namespace AdventOfCode.Test
{
    public class Day4Test
    {
        public Day4 Day4WithTestData { get; private set; }
        public Day4 Day4 { get; }

        public Day4Test()
        {
            this.Day4WithTestData = new Day4(Input.Day4Test);
            Day4WithTestData.Process();

            this.Day4 = new Day4(Input.Day4);
            Day4.Process();
        }

        [Fact]
        public void Day4TestDataWorking()
        {
            Day4WithTestData.FullOverlapCount.ShouldBe(2);
            Day4WithTestData.PartialOverlapCount.ShouldBe(4);
            
            Day4.FullOverlapCount.ShouldBe(513);
            Day4.PartialOverlapCount.ShouldBe(878);
        }
    }
}
