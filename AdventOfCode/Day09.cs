

public static class Day09
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 9,
        Name: "Encoding Error",
        PartI: input =>
        {
            return input
                .SplitLines()
                .Select(long.Parse)
                .ToArray()
                .FindWeakness()
                .ToString();
        },
        PartII: input =>
        {
            var numbers = input
                .SplitLines()
                .Select(long.Parse)
                .ToArray();
            var weakness = numbers.FindWeakness();

            long[] range = null;
            for (var i = 0; i < numbers.Length; i++)
            {
                var runningTotal = numbers[i];
                for (var j = i + 1; j < numbers.Length; j++)
                {
                    runningTotal += numbers[j];
                    if (runningTotal == weakness)
                    {
                        range = numbers[i..(j + 1)];
                        break;
                    }
                    else if (runningTotal > weakness)
                    {
                        break;
                    }
                }
            }

            return (range.Min() + range.Max()).ToString();
        });

    private static long FindWeakness(this long[] numbers, int preamble = 25)
    {
        return numbers
            .Skip(preamble)
            .Select((number, i) =>
            {
                var previous = numbers[i..(preamble + i)];
                var multiples = previous
                    .SelectMany(x => previous.Select(y => x + y))
                    .ToImmutableHashSet();
                return multiples.Contains(number)
                    ? -1
                    : number;
            })
            .First(number => number != -1);
    }

}
