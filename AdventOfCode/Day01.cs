using System.Collections.Immutable;
using System.Linq;

public static class Day01
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 1,
        Name: "Report Repair",
        PartI: (input) =>
        {
            var numbers = input
                .SplitLines()
                .Select(int.Parse)
                .ToImmutableArray();
            int partA = -1;
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
            return $"{partA}";
        },
        PartII: input =>
        {
            var numbers = input
                .SplitLines()
                .Select(int.Parse)
                .ToImmutableArray();
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
            return $"{partB}";
        }
    );

}
