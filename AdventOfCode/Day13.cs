using System.Collections.Immutable;
using System.Linq;
using AdventOfCode;

public static class Day13
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 13,
        Name: "Shuttle Search",
        PartI: input =>
        {
            var lines = input.SplitLines();
            var earliestTime = long.Parse(lines[0]);
            var result = lines[1]
                .Split(",")
                .Where(time => time != "x")
                .Select(long.Parse)
                .Select(busTime => (
                        BusId: busTime,
                        EarliestTime: ((earliestTime / busTime) * busTime) + busTime))
                .OrderBy(x => x.EarliestTime)
                .First();
            return (result.BusId * (result.EarliestTime - earliestTime)).ToString();
        },
        PartII: input =>
        {
            var lines = input.SplitLines();
            var buses = lines[1]
                .Split(",")
                .Select((busId, i) => busId == "x" ? (BusId: -1, Index: i) : (BusId: long.Parse(busId), Index: i))
                .Where(x => x.BusId > 0)
                .ToImmutableArray();

            long current = 0;
            var increment = buses.First().BusId;

            foreach (var bus in buses.Skip(1))
            {
                while ((current + bus.Index) % bus.BusId != 0)
                {
                    current = current + increment;
                }
                increment = increment * bus.BusId;
            }
            return current.ToString();
        });

}
