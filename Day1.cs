using System.Linq;

internal static class Day1
{

    /// <summary>
    /// <a href="https://adventofcode.com/2020/day/1">Day 1</a>: Report Repair
    /// </summary>
    public static string Run(string[] input)
    {
        var numbers = input.Select(int.Parse).ToArray();
        for (var i = 0; i < numbers.Length; i++)
        {
            for (var j = 0; j < numbers.Length; j++)
            {
                if (numbers[i] + numbers[j] == 2020)
                {
                    return $"{numbers[i] * numbers[j]}";
                }
            }
        }
        System.Console.Beep();
        return "Inconclusive!";
    }

    public static string RunPartII(string[] input)
    {
        var numbers = input.Select(int.Parse).ToArray();
        for (var i = 0; i < numbers.Length; i++)
        {
            for (var j = 1; j < numbers.Length; j++)
            {
                for (var k = 0; k < numbers.Length; k++)
                {
                    if (numbers[i] + numbers[j] + numbers[k] == 2020)
                    {
                        return $"{numbers[i] * numbers[j] *  numbers[k]}";
                    }
                }
            }
        }
        System.Console.Beep();
        return "Inconclusive!";
    }

}