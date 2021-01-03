using System;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode
{
    public static class Day05
    {

        public static readonly AdventSolution Solution = new AdventSolution(
            Day: 5,
            Name: "Binary Boarding",
            PartI: input => input
                .SplitLines()
                .Select(line => CalculateSeat(
                    SearchSeat(line.Substring(0, 7), 0, 127, isRow: true),
                    SearchSeat(line.Substring(7, 3), 0, 7, isRow: false)))
                .Max()
                .ToString(),
            PartII: input =>
            {
                var seats = input
                    .SplitLines()
                    .Select(line => CalculateSeat(
                        SearchSeat(line.Substring(0, 7), 0, 127, isRow: true),
                        SearchSeat(line.Substring(7, 3), 0, 7, isRow: false)))
                    .ToImmutableHashSet();
                return Enumerable
                    .Range(0, 127)
                    .SelectMany(row => Enumerable
                        .Range(0, 8)
                        .Select(column => CalculateSeat(row, column)))
                    .Single(seatId => !seats.Contains(seatId)
                                      && seats.Contains(seatId + 1)
                                      && seats.Contains(seatId - 1))
                    .ToString();
            });

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
}
