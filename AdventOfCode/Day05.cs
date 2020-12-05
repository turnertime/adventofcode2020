using System;
using System.Collections.Immutable;
using System.Linq;

public static class Day05
{

    /// <summary>
    /// <a href="https://adventofcode.com/2020/day/5">Day 5</a>: Binary Boarding
    /// </summary>
    public static Solution Run(string[] lines)
    {
        var seats = lines
            .Select(line => CalculateSeat(
                SearchSeat(line.Substring(0, 7), 0, 127, isRow: true),
                SearchSeat(line.Substring(7, 3), 0, 7, isRow: false)))
            .ToImmutableHashSet();

        var partA = seats.Max();

        var partB = Enumerable.Range(0, 127)
            .SelectMany(row => Enumerable
                .Range(0, 8)
                .Select(column => CalculateSeat(row, column)))
            .Where(seatId => !seats.Contains(seatId)
                && seats.Contains(seatId + 1)
                && seats.Contains(seatId - 1))
            .Single();

        return new Solution($"{partA}", $"{partB}");
    }

    /// <summary>
    /// Computes the seat ID from the row and column.
    /// </summary>
    private static int CalculateSeat(int row, int column)
    {
        return (row * 8) + column;
    }

    /// <summary>
    /// Finds the seat row or column.
    /// </summary>
    private static int SearchSeat(string positions, int min, int max, bool isRow)
    {
        foreach (var position in positions)
        {
            var mid = ((max - min) / 2) + 1;
            if (position == 'B' || position == 'R')
            {
                min += mid;
            }
            else
            {
                max -= mid;
            }
        }
        return isRow ? Math.Min(min, max) : Math.Max(min, max);
    }

}
