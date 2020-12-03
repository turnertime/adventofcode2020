using System;
using System.Collections.Immutable;
using System.Linq;

internal static class Day03
{

    /// <summary>
    /// <a href="https://adventofcode.com/2020/day/3">Day 3</a>: Toboggan Trajectory
    /// </summary>
    public static void Run(string[] lines)
    {
        Func<Move, long> traverse = (m) => Day03.Traverse(m, lines);

        var partIAnswer = $"{traverse(new Move(Down: 1, Right: 3))}";
        var partIIAnswer = ImmutableArray
            .Create(
                new Move(Down: 1, Right: 1),
                new Move(Down: 1, Right: 3),
                new Move(Down: 1, Right: 5),
                new Move(Down: 1, Right: 7),
                new Move(Down: 2, Right: 1))
            .Select(traverse)
            .Aggregate((current, next) => current * next);

        Console.WriteLine($"Part  I: {partIAnswer}");
        Console.WriteLine($"Part II: {partIIAnswer}");
    }

    private sealed record Move(int Down, int Right);

    private static long Traverse(Move move, string[] lines)
    {
        var position = 0;
        long count = 0;
        for (var i = move.Down; i < lines.Length; i += move.Down)
        {
            var line = lines[i];
            position += move.Right;
            var remainder = position % line.Length;
            if (line[remainder] == '#') { count++; }
        }
        return count;
    }

}
