using Shouldly;

namespace AdventOfCode.Test
{
    public class Day1Test
    {
        [Fact]
        public void Day1TestDataWorking()
        {
            var day1 = new Day1(Input.Day1Test);
            
            day1.Process();

            day1.Calories.Count.ShouldBe(5);
            day1.MaxCalories.ShouldBe(24000);
            day1.ElfWithMaxCalories.ShouldBe(4);
            day1.TopThreeElves.ShouldBe(45000);
        }
    }
}