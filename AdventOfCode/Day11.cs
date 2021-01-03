using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using AdventOfCode;

public static class Day11
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 11,
        Name: "Seating System",
        PartI: input =>
        {
            var seatLayout = input
                .SplitLines()
                .SelectMany((row, y) => row
                    .Select((seat, x) => (Position: new Point(x, y), Seat: seat)))
                .ToImmutableDictionary(
                    x => x.Position,
                    x => x.Seat == '.'
                        ? SeatStatus.Floor
                        : x.Seat == '#'
                            ? SeatStatus.Occupied
                            : SeatStatus.Empty);
            var newSeatLayout = seatLayout;

            do
            {
                seatLayout = newSeatLayout;
                newSeatLayout = seatLayout
                    .Select(seat =>
                    {
                        if (seat.Value == SeatStatus.Floor) { return seat; }
                        var occupiedAdjacentSeats = Directions
                            .Count(d => IsOccupied(seatLayout, seat.Key, d));
                        if (seat.Value == SeatStatus.Empty && occupiedAdjacentSeats == 0)
                        {
                            return KeyValuePair.Create(seat.Key, SeatStatus.Occupied);
                        }
                        else if (seat.Value == SeatStatus.Occupied && occupiedAdjacentSeats >= 4)
                        {
                            return KeyValuePair.Create(seat.Key, SeatStatus.Empty);
                        }
                        return seat;
                    })
                    .ToImmutableDictionary();
            } while (!Enumerable.SequenceEqual(seatLayout.Values, newSeatLayout.Values));

            return newSeatLayout.Count(seat => seat.Value == SeatStatus.Occupied).ToString();
        },
        PartII: input =>
        {
            var seatLayout = input
                .SplitLines()
                .SelectMany((row, y) => row
                    .Select((seat, x) => (Position: new Point(x, y), Seat: seat)))
                .ToImmutableDictionary(
                    x => x.Position,
                    x => x.Seat == '.'
                        ? SeatStatus.Floor
                        : x.Seat == '#'
                            ? SeatStatus.Occupied
                            : SeatStatus.Empty);
            var newSeatLayout = seatLayout;

            do
            {
                seatLayout = newSeatLayout;
                newSeatLayout = seatLayout
                    .Select(seat =>
                    {
                        if (seat.Value == SeatStatus.Floor)
                        {
                            return seat;
                        }
                        var occupiedAdjacentSeats = Directions
                            .Count(d => IsOccupied(seatLayout, seat.Key, d, checkVisible: true));
                        if (seat.Value == SeatStatus.Empty && occupiedAdjacentSeats == 0)
                        {
                            return KeyValuePair.Create(seat.Key, SeatStatus.Occupied);
                        }
                        else if (seat.Value == SeatStatus.Occupied && occupiedAdjacentSeats >= 5)
                        {
                            return KeyValuePair.Create(seat.Key, SeatStatus.Empty);
                        }
                        return seat;
                    })
                    .ToImmutableDictionary();
            } while (!Enumerable.SequenceEqual(seatLayout.Values, newSeatLayout.Values));

            return newSeatLayout.Count(seat => seat.Value == SeatStatus.Occupied).ToString();
        });

    /// <summary>
    /// Determines if the seat is occupied.
    /// </summary>
    private static bool IsOccupied(
        ImmutableDictionary<Point, SeatStatus> seatLayout,
        Point currentSeat,
        Point direction,
        bool checkVisible = false,
        int count = 1)
    {
        var adjacentPosition = new Point(currentSeat.X + (direction.X * count), currentSeat.Y + (direction.Y * count));
        var adjacentSeat = seatLayout.GetValueOrDefault(adjacentPosition);
        if (adjacentSeat == SeatStatus.NotDefined)
        {
            return false;
        }
        else if (adjacentSeat == SeatStatus.Occupied)
        {
            return true;
        }
        else if (adjacentSeat == SeatStatus.Empty)
        {
            return false;
        }
        else
        {
            return checkVisible
                ? IsOccupied(seatLayout, currentSeat, direction, checkVisible, count + 1)
                : false;
        }
    }


    private static Point East = new Point(x: 1, y: 0);
    private static Point North = new Point(x: 0, y: -1);
    private static Point NorthEast = new Point(x: 1, y: -1);
    private static Point NorthWest = new Point(x: -1, y: -1);
    private static Point South = new Point(x: 0, y: 1);
    private static Point SouthEast = new Point(x: 1, y: 1);
    private static Point SouthWest = new Point(x: -1, y: 1);
    private static Point West = new Point(x: -1, y: 0);

    private static ImmutableArray<Point> Directions = ImmutableArray
        .Create(
            East,
            North,
            NorthEast,
            NorthWest,
            South,
            SouthEast,
            SouthWest,
            West);

    private enum SeatStatus
    {
        NotDefined = 0,
        Floor,
        Empty,
        Occupied
    }

}
