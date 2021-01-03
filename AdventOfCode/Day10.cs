using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode;

public static class Day10
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 10,
        Name: "Adapter Array",
        PartI: input =>
        {
            var numbers = input
                .SplitLines()
                .Select(long.Parse)
                .OrderBy(x => x)
                .ToImmutableArray();
            var adapters = numbers
                .Concat(new[] { 0, numbers.Max() + 3 })
                .OrderBy(x => x)
                .Select(x => (Min: x, Max: x + 3))
                .ToArray();

            var differences = adapters
                .SkipLast(1)
                .Select((adapter, i) => adapters[i + 1].Min - adapter.Min)
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());

            return (differences[1] * differences[3]).ToString();
        },
        PartII: input =>
        {
            var numbers = input
                .SplitLines()
                .Select(long.Parse)
                .OrderBy(x => x)
                .ToImmutableArray();

            var adapters = numbers
                .Concat(new long[] { 0, numbers.Last() + 3 })
                .OrderBy(x => x)
                .Select((x, i) => (Index: i, Min: x, Max: x + 3))
                .ToArray();

            return FindPaths(adapters, adapters.First()).ToString();
        });

    private static long FindPaths(
        (int Index, long Min, long Max)[] adapters,
        (int Index, long Min, long Max) current,
        Dictionary<long, long> paths = null)
    {

        paths = paths ?? new Dictionary<long, long>(adapters.Length);

        if (current.Index == adapters.Length - 1)
        {
            return 1;
        }

        if (paths.ContainsKey(current.Index))
        {
            return paths[current.Index];
        }

        long pathCount = 0;
        var nextAdapters = adapters
            .Skip(current.Index + 1)
            .Where(adapter => adapter.Min > current.Min && adapter.Min <= current.Max);
        foreach (var adapter in nextAdapters)
        {
            pathCount += FindPaths(adapters, adapter, paths);
        }
        paths.Add(current.Index, pathCount);

        return pathCount;
    }

}
