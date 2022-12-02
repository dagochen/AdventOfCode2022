using Shouldly;

namespace AdventOfCode.Test
{
    public class Day2Test
    {
        [Fact]
        public void Day2TestDataWorking()
        {
            var day2 = new Day2(Input.Day2Test);
            day2.Process();

            day2.Score.ShouldBe(15);
            day2.ScorePartTwo.ShouldBe(12);
           
        }
    }
}
