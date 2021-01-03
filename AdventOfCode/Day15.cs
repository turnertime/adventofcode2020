using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode
{
    public static class Day15
    {

        public static readonly AdventSolution Solution = new AdventSolution(
            Day: 15,
            Name: "Rambunctious Recitation",
            PartI: input => Play(2020, input),
            PartII: input => Play(30000000, input));

        /// <summary>
        /// Plays the memory game the specified number of times.
        /// </summary>
        private static string Play(int turnCount, string input)
        {
            var numbers = input
                .Split(",")
                .Select(long.Parse)
                .ToImmutableArray();

            long previousNumber = -1;
            var history = new Dictionary<long, (long last, long diff)>(turnCount);
            return Enumerable
                .Range(0, (turnCount / numbers.Length) + 1)
                .SelectMany(_ => numbers)
                .Take(turnCount)
                .Select((e, i) =>
                {
                    long result;
                    if (!history.ContainsKey(e))
                    {
                        result = e;
                    }
                    else
                    {
                        var prevHistory = history[previousNumber];
                        result = prevHistory.diff == -1
                            ? 0
                            : prevHistory.diff;
                    }
                    if (history.ContainsKey(result))
                    {
                        history[result] = (i, i - history[result].last);
                    }
                    else
                    {
                        history.Add(result, (i, -1));
                    }
                    previousNumber = result;
                    return result;
                })
                .Last()
                .ToString();
        }

    }
}
