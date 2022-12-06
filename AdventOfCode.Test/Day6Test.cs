using Shouldly;

namespace AdventOfCode.Test
{
    public class Day6Test
    {
        public Day6 Day6 { get; }

        public Day6Test()
        {
            this.Day6 = new Day6(Input.Day6Test);
            Day6.Part1();
        }

        [Fact]
        public void TestDay6Process()
        {
            Day6.MarkerPosition.ShouldBe(7);
        }

        [Fact]
        public void TestDay6OtherExamples()
        {
            var day6other = new Day6("bvwbjplbgvbhsrlpgdmjqwftvncz");
            day6other.Part1();
            day6other.MarkerPosition.ShouldBe(5);

            day6other = new Day6("nppdvjthqldpwncqszvftbrmjlhg");
            day6other.Part1();
            day6other.MarkerPosition.ShouldBe(6);

            day6other = new Day6("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            day6other.Part1();
            day6other.MarkerPosition.ShouldBe(10);

            day6other = new Day6("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
            day6other.Part1();
            day6other.MarkerPosition.ShouldBe(11);
        }

        [Fact]
        public void TestDay6OtherExamplesPart2()
        {
            var day6other = new Day6("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
            day6other.Part2();
            day6other.MessagePosition.ShouldBe(19);

            day6other = new Day6("bvwbjplbgvbhsrlpgdmjqwftvncz");
            day6other.Part2();
            day6other.MessagePosition.ShouldBe(23);

            day6other = new Day6("nppdvjthqldpwncqszvftbrmjlhg");
            day6other.Part2();
            day6other.MessagePosition.ShouldBe(23);

            day6other = new Day6("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            day6other.Part2();
            day6other.MessagePosition.ShouldBe(29);
        }
    }
}
