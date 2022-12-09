using Shouldly;

namespace AdventOfCode.Test
{
    public class Day9Test
    {
        public Day9Test()
        {
            this.Day = new Day9(Input.Day9Test);
            Day.Read();
            Day.Calculate();
        }

        public Day9 Day { get; }

        [Fact] 
        public void TestPart1()
        {
            Day.Part1.ShouldBe(13);
        }

        [Fact]
        public void TestPart2()
        {
            Day.Part2.ShouldBe(1);
        }


        [Fact]
        public void TestPart2LongExample()
        {
            var day = new Day9(Input.Day9TestPart2);
            day.Read();
            day.Calculate();
            day.Part2.ShouldBe(36);
        }

        [Fact]
        public void TestOneCommand()
        {
            var d = new Day9(Input.Day9Test);
            d.Read();
            d.ExecuteCommand(d.Commands[0]);
            d.VisitedFields.Count.ShouldBe(4);
            d.VisitedFieldsPart2.Count.ShouldBe(1);
            d.VisitedFields.ToArray()[0].X.ShouldBe(0);
            d.VisitedFields.ToArray()[0].Y.ShouldBe(0);

            d.VisitedFields.ToArray()[1].X.ShouldBe(1);
            d.VisitedFields.ToArray()[1].Y.ShouldBe(0);

            d.VisitedFields.ToArray()[2].X.ShouldBe(2);
            d.VisitedFields.ToArray()[2].Y.ShouldBe(0);

            d.VisitedFields.ToArray()[3].X.ShouldBe(3);
            d.VisitedFields.ToArray()[3].Y.ShouldBe(0);
        }

        [Fact]
        public void TestOneCommand2()
        {
            var d = new Day9(Input.Day9Test);
            d.Read();
            d.ExecuteCommand(d.Commands[0]);
            d.ExecuteCommand(d.Commands[1]);
            d.VisitedFields.Count.ShouldBe(7);
            d.VisitedFieldsPart2.Count.ShouldBe(1);

            d.VisitedFields.ToArray()[4].X.ShouldBe(4);
            d.VisitedFields.ToArray()[4].Y.ShouldBe(1);

            d.VisitedFields.ToArray()[5].X.ShouldBe(4);
            d.VisitedFields.ToArray()[5].Y.ShouldBe(2);

            d.VisitedFields.ToArray()[6].X.ShouldBe(4);
            d.VisitedFields.ToArray()[6].Y.ShouldBe(3);
        }

        [Fact]
        public void TestOneCommand3()
        {
            var d = new Day9(Input.Day9Test);
            d.Read();
            d.ExecuteCommand(d.Commands[0]);
            d.ExecuteCommand(d.Commands[1]);
            d.ExecuteCommand(d.Commands[2]);
            d.VisitedFields.Count.ShouldBe(9);
            d.VisitedFieldsPart2.Count.ShouldBe(1);

            d.VisitedFields.ToArray()[7].X.ShouldBe(3);
            d.VisitedFields.ToArray()[7].Y.ShouldBe(4);

            d.VisitedFields.ToArray()[8].X.ShouldBe(2);
            d.VisitedFields.ToArray()[8].Y.ShouldBe(4);
        }

        [Fact] 
        public void TestOneCommand4()
        {
            var d = new Day9(Input.Day9Test);
            d.Read();
            d.ExecuteCommand(d.Commands[0]);
            d.ExecuteCommand(d.Commands[1]);
            d.ExecuteCommand(d.Commands[2]);
            d.ExecuteCommand(d.Commands[3]);
            d.VisitedFields.Count.ShouldBe(9);
            d.VisitedFieldsPart2.Count.ShouldBe(1);

        }

        [Fact]
        public void TestOneCommand5()
        {
            var d = new Day9(Input.Day9Test);
            d.Read();
            d.ExecuteCommand(d.Commands[0]);
            d.ExecuteCommand(d.Commands[1]);
            d.ExecuteCommand(d.Commands[2]);
            d.ExecuteCommand(d.Commands[3]);
            d.ExecuteCommand(d.Commands[4]);
            d.VisitedFields.Count.ShouldBe(10);
            d.VisitedFieldsPart2.Count.ShouldBe(1);

            d.VisitedFields.ToArray()[9].X.ShouldBe(3);
            d.VisitedFields.ToArray()[9].Y.ShouldBe(3);

        }
    }
}
