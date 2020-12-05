using System.Linq;

public static class Day01
{

    /// <summary>
    /// <a href="https://adventofcode.com/2020/day/1">Day 1</a>: Report Repair
    /// </summary>
    public static Solution Run(string[] input)
    {
        var partA = -1;
        var numbers = input.Select(int.Parse).ToArray();
        for (var i = 0; i < numbers.Length; i++)
        {
            for (var j = 0; j < numbers.Length; j++)
            {
                if (numbers[i] + numbers[j] == 2020)
                {
                    partA = numbers[i] * numbers[j];
                    break;
                }
            }
        }

        var partB = -1;
        for (var i = 0; i < numbers.Length; i++)
        {
            for (var j = 1; j < numbers.Length; j++)
            {
                for (var k = 0; k < numbers.Length; k++)
                {
                    if (numbers[i] + numbers[j] + numbers[k] == 2020)
                    {
                        partB = numbers[i] * numbers[j] * numbers[k];
                        break;
                    }
                }
            }
        }

        return new Solution($"{partA}", $"{partB}");
    }

}
