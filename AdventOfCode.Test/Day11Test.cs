using Shouldly;

namespace AdventOfCode.Test
{
    public class Day11Test
    {
        public Day11 Day { get; }

        public Day11Test()
        {
            this.Day = new Day11(Input.Day11Test);
            Day.Read();
            
        }

        [Fact] 
        public void TestPart1()
        {
            Day.Calculate(20, true);
            Day.Monkeys[0].InspectedItemsCount.ShouldBe(101);
            Day.Monkeys[1].InspectedItemsCount.ShouldBe(95);
            Day.Monkeys[2].InspectedItemsCount.ShouldBe(7);
            Day.Monkeys[3].InspectedItemsCount.ShouldBe(105);

            Day.Part1.ShouldBe(10605);
        }

        [Fact] public void TestPart1After1Round() 
        {
            Day.StartRound(true);
            Day.Monkeys.Count.ShouldBe(4);

            Day.Monkeys[0].Items.ShouldContain(20);
            Day.Monkeys[0].Items.ShouldContain(23);
            Day.Monkeys[0].Items.ShouldContain(27);
            Day.Monkeys[0].Items.ShouldContain(26);

            Day.Monkeys[1].Items.ShouldContain(2080);
            Day.Monkeys[1].Items.ShouldContain(25);
            Day.Monkeys[1].Items.ShouldContain(167);
            Day.Monkeys[1].Items.ShouldContain(207);
            Day.Monkeys[1].Items.ShouldContain(401);
            Day.Monkeys[1].Items.ShouldContain(1046);

            Day.Monkeys[2].Items.ShouldBeEmpty();
            Day.Monkeys[3].Items.ShouldBeEmpty();
        }
      

        [Theory]
        [InlineData(1, 2, 4, 3, 6, 24)]
        [InlineData(20, 99, 97, 8, 103, 10197)]
        [InlineData(1000, 5204, 4792, 199, 5192, 27019168)]
        [InlineData(2000, 10419, 9577, 392, 10391, 108263829)]
        [InlineData(3000, 15638, 14358, 587, 15593, 243843334)]
        [InlineData(4000, 20858, 19138, 780, 20797, 433783826)]
        [InlineData(5000, 26075, 23921, 974, 26000, 677950000)]
        [InlineData(6000, 31294, 28702, 1165, 31204, 976497976)]
        [InlineData(7000, 36508, 33488, 1360, 36400, 1328891200)]
        [InlineData(8000, 41728, 38268, 1553, 41606, 1736135168)]
        [InlineData(9000, 46945, 43051, 1746, 46807, 2197354615)]
        [InlineData(10000, 52166, 47830, 1938, 52013, 2713310158)]
        public void TestPart2(int rounds, long monkey0, long monkey1, long monkey2, long monkey3, long monkeybusiness)
        {
            Day.Calculate(rounds);
            Day.Monkeys[0].InspectedItemsCount.ShouldBe(monkey0);
            Day.Monkeys[1].InspectedItemsCount.ShouldBe(monkey1);
            Day.Monkeys[2].InspectedItemsCount.ShouldBe(monkey2);
            Day.Monkeys[3].InspectedItemsCount.ShouldBe(monkey3);

            Day.Part2.ShouldBe(monkeybusiness);
        }
    }
}
