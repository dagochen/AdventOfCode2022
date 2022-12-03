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
Console.WriteLine(day3.GroupSum);

Console.Read();