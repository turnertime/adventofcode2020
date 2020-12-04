using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

internal static class Day03
{

    /// <summary>
    /// <a href="https://adventofcode.com/2020/day/3">Day 3</a>: Toboggan Trajectory
    /// </summary>
    public static Solution Run(string[] lines)
    {
        var partA = Traverse(new Move(Down: 1, Right: 3), lines);

        var partB = ImmutableArray
            .Create(
                new Move(Down: 1, Right: 1),
                new Move(Down: 1, Right: 3),
                new Move(Down: 1, Right: 5),
                new Move(Down: 1, Right: 7),
                new Move(Down: 2, Right: 1))
            .Select(move => Traverse(move, lines))
            .Aggregate((current, next) => current * next);

        return new Solution(partA, partB);
    }

    /// <summary>
    /// Defines a move down the slope
    /// </summary>
    private sealed record Move(int Down, int Right);

    /// <summary>
    /// Traverses the slope
    /// </summary>
    private static long Traverse(Move move, string[] lines)
    {
        var length = lines[0].Length;
        return Enumerable
            .Range(1, Math.DivRem(lines.Length, move.Down, out _) - 1)
            .Select(i => new Move(move.Down * i, move.Right * i))
            .Count(x => lines[x.Down][x.Right % length] == '#');
    }

}
