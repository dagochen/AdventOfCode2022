using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Test
{
    public class Day5Test
    {
        public Day5 Day5 { get; }

        public Day5Test()
        {
            this.Day5 = new Day5(Input.Day5Test);
            Day5.Process();
        }

        [Fact]
        public void TestDay5Read()
        {
            Day5.Stacks.Count().ShouldBe(3);
            Day5.Stacks[0].Count().ShouldBe(2);
            Day5.Stacks[1].Count().ShouldBe(3);
            Day5.Stacks[2].Count().ShouldBe(1);
            
            Day5.Stacks[0].Pop().ShouldBe('N');
            Day5.Stacks[0].Pop().ShouldBe('Z');

            Day5.Stacks[1].Pop().ShouldBe('D');
            Day5.Stacks[1].Pop().ShouldBe('C');
            Day5.Stacks[1].Pop().ShouldBe('M');

            Day5.Stacks[2].Pop().ShouldBe('P');
        }

        [Fact]
        public void TestDayMove()
        {

        }


    }
}
