using System;
using System.Collections.Generic;
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
        var length = lines[0].Length;
        return Enumerable
            .Range(1, Math.DivRem(lines.Length, move.Down, out _) - 1)
            .Select(i => new Move(move.Down * i, move.Right * i))
            .Count(x => lines[x.Down][x.Right % length] == '#');
    }

}
