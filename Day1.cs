using System;
using System.Linq;

internal static class Day1
{

    /// <summary>
    /// <a href="https://adventofcode.com/2020/day/1">Day 1</a>: Report Repair
    /// </summary>
    public static void Run(string[] input)
    {
        var partIAnswer = "Inconclusive";
        var numbers = input.Select(int.Parse).ToArray();
        for (var i = 0; i < numbers.Length; i++)
        {
            for (var j = 0; j < numbers.Length; j++)
            {
                if (numbers[i] + numbers[j] == 2020)
                {
                    partIAnswer = $"{numbers[i] * numbers[j]}";
                    break;
                }
            }
        }

        var partIIAnswer = "Inconclusive";
        for (var i = 0; i < numbers.Length; i++)
        {
            for (var j = 1; j < numbers.Length; j++)
            {
                for (var k = 0; k < numbers.Length; k++)
                {
                    if (numbers[i] + numbers[j] + numbers[k] == 2020)
                    {
                        partIIAnswer = $"{numbers[i] * numbers[j] * numbers[k]}";
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"Part I:  {partIAnswer}");
        Console.WriteLine($"Part II: {partIIAnswer}");
    }

}
