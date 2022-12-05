using Shouldly;

namespace AdventOfCode.Test
{
    public class Day5Test
    {
        public Day5 Day5 { get; }

        public Day5Test()
        {
            this.Day5 = new Day5(Input.Day5Test);
        }

        [Fact]
        public void TestDay5ReadInput()
        {
            this.Day5.ReadInput();

            this.Day5.Stacks.Count().ShouldBe(3);

            this.Day5.Stacks[0].Count().ShouldBe(2);
            this.Day5.Stacks[1].Count().ShouldBe(3);
            this.Day5.Stacks[2].Count().ShouldBe(1);

            this.Day5.Stacks[0].Pop().ShouldBe('N');
            this.Day5.Stacks[0].Pop().ShouldBe('Z');

            this.Day5.Stacks[1].Pop().ShouldBe('D');
            this.Day5.Stacks[1].Pop().ShouldBe('C');
            this.Day5.Stacks[1].Pop().ShouldBe('M');

            this.Day5.Stacks[2].Peek().ShouldBe('P');
        }

        [Fact]
        public void TestDay5Part1()
        { 
            this.Day5.ReadInput();
            this.Day5.Part1Crane();
            Day5.CalculateSolution();

            Day5.Stacks[0].Count().ShouldBe(1);
            Day5.Stacks[1].Count().ShouldBe(1);
            Day5.Stacks[2].Count().ShouldBe(4);

            Day5.Stacks[0].Pop().ShouldBe('C');

            Day5.Stacks[1].Pop().ShouldBe('M');

            Day5.Stacks[2].Pop().ShouldBe('Z');
            Day5.Stacks[2].Pop().ShouldBe('N');
            Day5.Stacks[2].Pop().ShouldBe('D');
            Day5.Stacks[2].Pop().ShouldBe('P');

            Day5.Solution.ShouldBe("CMZ");
        }

        [Fact]
        public void TestDay5Part2()
        {
            this.Day5.ReadInput();
            this.Day5.Part2Crane();
            Day5.CalculateSolution();

            Day5.Stacks[0].Count().ShouldBe(1);
            Day5.Stacks[1].Count().ShouldBe(1);
            Day5.Stacks[2].Count().ShouldBe(4);

            Day5.Stacks[0].Pop().ShouldBe('M');

            Day5.Stacks[1].Pop().ShouldBe('C');

            Day5.Stacks[2].Pop().ShouldBe('D');
            Day5.Stacks[2].Pop().ShouldBe('N');
            Day5.Stacks[2].Pop().ShouldBe('Z');
            Day5.Stacks[2].Pop().ShouldBe('P');

            Day5.Solution.ShouldBe("MCD");
        }



    }
}
