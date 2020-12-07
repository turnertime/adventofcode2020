using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

public static class Day03
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 3,
        Name: "Toboggan Trajectory",
        PartI: input => Traverse(
            new Move(Down: 1, Right: 3),
            input.SplitLines())
            .ToString(),
        PartII: input =>
        {
            var lines = input.SplitLines();
            return ImmutableArray
                .Create(
                    new Move(Down: 1, Right: 1),
                    new Move(Down: 1, Right: 3),
                    new Move(Down: 1, Right: 5),
                    new Move(Down: 1, Right: 7),
                    new Move(Down: 2, Right: 1))
                .Select(move => Traverse(move, lines))
                .Aggregate((current, next) => current * next)
                .ToString();
        }
    );

    /// <summary>
    /// Defines a move down the slope
    /// </summary>
    private sealed record Move(int Down, int Right);

    /// <summary>
    /// Traverses the slope
    /// </summary>
    private static long Traverse(Move move, IImmutableList<string> lines)
    {
        var length = lines[0].Length;
        return Enumerable
            .Range(1, Math.DivRem(lines.Count, move.Down, out _) - 1)
            .Select(i => new Move(move.Down * i, move.Right * i))
            .Count(x => lines[x.Down][x.Right % length] == '#');
    }

}
