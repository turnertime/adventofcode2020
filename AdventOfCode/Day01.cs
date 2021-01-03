using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode
{
    public static class Day01
    {

        public static readonly AdventSolution Solution = new AdventSolution(
            Day: 1,
            Name: "Report Repair",
            PartI: (input) =>
            {
                var numbers = input
                    .SplitLines()
                    .Select(int.Parse)
                    .ToImmutableArray();
                var partA = -1;
                foreach (var first in numbers)
                {
                    foreach (var second in numbers)
                    {
                        if (first + second == 2020)
                        {
                            partA = first * second;
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
                foreach (var first in numbers)
                {
                    foreach (var second in numbers)
                    {
                        foreach (var third in numbers)
                        {
                            if (first + second + third == 2020)
                            {
                                partB = first * second * third;
                                break;
                            }
                        }
                    }
                }
                return $"{partB}";
            }
        );

    }
}
