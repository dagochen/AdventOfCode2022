using Shouldly;

namespace AdventOfCode.Test
{
    public class Day3Test
    {
        public Day3 Day3 { get; private set; }
        public Day3Test()
        {
            this.Day3 = new Day3(Input.Day3Test);
            Day3.Process();
        }

        [Fact]
        public void Day3TestDataWorking()
        {
            Day3.Rucksacks.Count.ShouldBe(6);
            Day3.SumOfPriorities.ShouldBe(157);
        }

        [Fact]
        public void TestValueOfChar()
        {
            Day3.PriorityOf('a').ShouldBe(1);
            Day3.PriorityOf('z').ShouldBe(26);
            Day3.PriorityOf('A').ShouldBe(27);
            Day3.PriorityOf('Z').ShouldBe(52);
        }

        [Fact]
        public void TestFindItemInRucksack()
        {
            var rucksack0 = Day3.GetRucksack(0);
            Day3.FindWrongItem(rucksack0).ShouldBe('p');
            var rucksack1 = Day3.GetRucksack(1);
            Day3.FindWrongItem(rucksack1).ShouldBe('L');
            var rucksack2 = Day3.GetRucksack(2);
            Day3.FindWrongItem(rucksack2).ShouldBe('P');
            var rucksack3 = Day3.GetRucksack(3);
            Day3.FindWrongItem(rucksack3).ShouldBe('v');
            var rucksack4 = Day3.GetRucksack(4);
            Day3.FindWrongItem(rucksack4).ShouldBe('t');
            var rucksack5 = Day3.GetRucksack(5);
            Day3.FindWrongItem(rucksack5).ShouldBe('s');
        }

        [Fact]
        public void TestGroupBadgeSum()
        {
            Day3.GroupBadgeSum.ShouldBe(70);
        }
    }
}
