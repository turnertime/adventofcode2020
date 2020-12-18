using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode;

public static class Day14
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 14,
        Name: "Docking Data",
        PartI: input =>
        {
            return ParseMemoryOperations(input)
                .Select(operation =>
                {
                    var value = Convert.ToString(operation.Value, 2).PadLeft(36, '0');
                    var maskedNumber = new string(value.Zip(operation.Mask).Select(v => v.Second == 'X' ? v.First : v.Second).ToArray());

                    return KeyValuePair.Create(operation.Index, Convert.ToInt64(maskedNumber, 2));
                })
                .GroupBy(op => op.Key)
                .Select(g => g.Last().Value)
                .Sum()
                .ToString();
        },
        PartII: input =>
        {
            return ParseMemoryOperations(input)
                .SelectMany(operation =>
                {
                    var value = Convert.ToString(operation.Index, 2).PadLeft(36, '0');
                    var maskedNumber = new string(value
                        .Zip(operation.Mask)
                        .Select(v => v.Second == 'X' ? v.Second : v.Second == '0' ? v.First : '1')
                        .ToArray());
                    return ExpandMaskedNumber(maskedNumber)
                        .Select(index => KeyValuePair.Create(Convert.ToInt64(index, 2), operation.Value));
                })
                .GroupBy(op => op.Key)
                .Select(g => g.Last().Value)
                .Sum()
                .ToString();
        });

    /// <summary>
    /// Parses the list of memory operations.
    /// </summary>
    private static ImmutableArray<MemoryOperation> ParseMemoryOperations(string input)
    {
        var currentMask = string.Empty;
        return input
            .SplitLines()
            .Select(line =>
            {
                var memMatch = MemoryAllocationPatthern.Match(line);
                if (memMatch.Success)
                {
                    return new MemoryOperation(currentMask, long.Parse(memMatch.Groups[1].Value), long.Parse(memMatch.Groups[2].Value));
                }
                currentMask = MaskPattern.Match(line).Groups[1].Value;
                return null;
            })
            .Where(mem => !(mem is null))
            .ToImmutableArray();
    }

    /// <summary>
    /// Expands the masked number by replacing 'X' with (0, 1).
    /// </summary>
    private static IEnumerable<string> ExpandMaskedNumber(string value)
    {
        var xs = value
            .Select((c, i) => (c, i))
            .Where(x => x.c == 'X')
            .Aggregate(
                new[] { new (char c, int i)[] { } },
                (current, next) => new[] { (c: '0', next.i), (c: '1', next.i) }
                    .SelectMany(v => current.Select(x => x.Concat(new[] { v }).ToArray()).ToArray())
                    .ToArray());
        foreach (var group in xs)
        {
            var dictionary = group.ToDictionary(g => g.i, g => g.c);
            yield return new string(value.Select((v, i) => dictionary.GetValueOrDefault(i, v)).ToArray());
        }
    }

    /// <summary>
    /// Defines a memory operation.
    /// </summary>
    private sealed record MemoryOperation(string Mask, long Index, long Value);

    /// <summary>
    /// Regular expression to match a bit mask.
    /// </summary>
    private static Regex MaskPattern = new Regex(@"^mask = ([X10]+)$", RegexOptions.Compiled);

    /// <summary>
    /// Regular expression to match a memory allocation.
    /// </summary>
    private static Regex MemoryAllocationPatthern = new Regex(@"^mem\[(\d+)\] = (\d+)$", RegexOptions.Compiled);

}
