// See https://aka.ms/new-console-template for more information
using AdventOfCode;

Console.WriteLine("Hello Advent of Code");

var day1 = new Day1(Input.Day1);
day1.Process();
Console.WriteLine(day1.MaxCalories);
Console.WriteLine(day1.TopThreeElves);

var day2 = new Day2(Input.Day2);
day2.Process();
Console.WriteLine(day2.Score);

var day3 = new Day3(Input.Day3);
day3.Process();
Console.WriteLine(day3.SumOfPriorities);
Console.WriteLine(day3.GroupBadgeSum);

var day4 = new Day4(Input.Day4);
day4.Process();
Console.WriteLine(day4.FullOverlapCount);
Console.WriteLine(day4.PartialOverlapCount);

var day5 = new Day5(Input.Day5);
day5.Process();
Console.WriteLine(day5.Solution);

var day6 = new Day6(Input.Day6);
day6.Part1();
Console.WriteLine(day6.MarkerPosition);
day6.Part2();
Console.WriteLine(day6.MessagePosition);

var day7 = new Day7(Input.Day7);
day7.ProcessPart1();
Console.WriteLine("Day 7 P1: " + day7.Part1);

day7.ProcessPart2();
Console.WriteLine(day7.Part2);


var day8 = new Day8(Input.Day8);
day8.Read();
day8.Calculate();
Console.WriteLine("Day 8 P1: " + day8.Part1);
Console.WriteLine("Day 8 P2: " + day8.Part2);

BaseDay day = new Day9(Input.Day9);
day.Read();
day.Calculate();
day.PrintResult();

day = new Day10(Input.Day10);
day.Read();
day.PrintResult();

Day11 day11 = new Day11(Input.Day11);
day11.Read();
day11.Calculate(20, true);
day11.PrintResult();

Day11 day11P2 = new Day11(Input.Day11);
day11P2.Read();
day11P2.Calculate(10000, false);
day11P2.PrintResult();

Console.Read();