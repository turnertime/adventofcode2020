using System;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;

public static class Day12
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 12,
        Name: "Rain Risk",
        PartI: input =>
        {
            var destination = input
                .SplitLines()
                .Select(ParseMovement)
                .Aggregate(
                    new Position(1, new Point(0, 0)),
                    (current, next) => Move(current, next)
                );

            return (Math.Abs(destination.Coordinates.X) + Math.Abs(destination.Coordinates.Y)).ToString();
        },
        PartII: input =>
        {
            var destination = input
                .SplitLines()
                .Select(ParseMovement)
                .Aggregate(
                    new PositionWithWaypoint(new Point(0, 0), new Point(-10, -1)),
                    (current, next) => Move(current, next)
                );

            return (Math.Abs(destination.Coordinates.X) + Math.Abs(destination.Coordinates.Y)).ToString();
        });

    /// <summary>
    /// Defines the type of action to move the ship.
    /// </summary>
    public enum Action
    {
        North,
        South,
        East,
        West,
        Left,
        Right,
        Forward
    }

    public static int ChangeDirection(int direction, int value, bool isClockwise)
    {
        var rotations = (value / 90);
        for (var i = 0; i < rotations; i++)
        {
            direction = isClockwise ? direction + 1 : direction - 1;
            direction = direction < 0
                ? 3
                : direction > 3
                    ? 0
                    : direction;
        }
        return direction;
    }

    public static Position Move(Position current, Movement movement)
    {
        return movement.Action switch
        {
            Action.North => new Position(current.Orientation, MoveDirection(current.Coordinates, North, movement.Value)),
            Action.East => new Position(current.Orientation, MoveDirection(current.Coordinates, East, movement.Value)),
            Action.South => new Position(current.Orientation, MoveDirection(current.Coordinates, South, movement.Value)),
            Action.West => new Position(current.Orientation, MoveDirection(current.Coordinates, West, movement.Value)),
            Action.Left => new Position(ChangeDirection(current.Orientation, movement.Value, false), current.Coordinates),
            Action.Right => new Position(ChangeDirection(current.Orientation, movement.Value, true), current.Coordinates),
            Action.Forward => new Position(current.Orientation, MoveDirection(current.Coordinates, Directions[current.Orientation], movement.Value)),
            _ => throw new NotSupportedException()
        };
    }

    /// <summary>
    /// Moves the ship using the way point.
    /// </summary>
    private static PositionWithWaypoint Move(PositionWithWaypoint current, Movement movement)
    {
        return movement.Action switch
        {
            Action.North => new PositionWithWaypoint(current.Coordinates, new Point(current.Waypoint.X, current.Waypoint.Y - movement.Value)),
            Action.East => new PositionWithWaypoint(current.Coordinates, new Point(current.Waypoint.X - movement.Value, current.Waypoint.Y)),
            Action.South => new PositionWithWaypoint(current.Coordinates, new Point(current.Waypoint.X, current.Waypoint.Y + movement.Value)),
            Action.West => new PositionWithWaypoint(current.Coordinates, new Point(current.Waypoint.X + movement.Value, current.Waypoint.Y)),
            Action.Left => movement.Value switch
            {
                90 => new PositionWithWaypoint(current.Coordinates, new Point(-current.Waypoint.Y, current.Waypoint.X)),
                180 => new PositionWithWaypoint(current.Coordinates, new Point(-current.Waypoint.X, -current.Waypoint.Y)),
                270 => new PositionWithWaypoint(current.Coordinates, new Point(current.Waypoint.Y, -current.Waypoint.X)),
                _ => throw new NotSupportedException()
            },
            Action.Right => movement.Value switch
            {
                90 => new PositionWithWaypoint(current.Coordinates, new Point(current.Waypoint.Y, -current.Waypoint.X)),
                180 => new PositionWithWaypoint(current.Coordinates, new Point(-current.Waypoint.X, -current.Waypoint.Y)),
                270 => new PositionWithWaypoint(current.Coordinates, new Point(-current.Waypoint.Y, current.Waypoint.X)),
                _ => throw new NotSupportedException()
            },
            Action.Forward => new PositionWithWaypoint(
                new Point(
                    current.Coordinates.X + (current.Waypoint.X * movement.Value),
                    current.Coordinates.Y + (current.Waypoint.Y * movement.Value)),
                current.Waypoint),
            _ => throw new NotSupportedException()
        };
    }

    /// <summary>
    /// Moves the ship in the specified direction
    /// </summary>
    public static Point MoveDirection(Point position, Point direction, int value)
    {
        return new Point(
            x: position.X + (direction.X * value),
            y: position.Y + (direction.Y * value));
    }

    /// <summary>
    /// The ship's movement.
    /// </summary>
    public sealed record Movement(Action Action, int Value);

    /// <summary>
    /// Parses the raw string (action + value) for the ships movement.
    /// </summary>
    private static Movement ParseMovement(string line)
    {
        return new Movement(
            line[0] switch
            {
                'N' => Action.North,
                'S' => Action.South,
                'E' => Action.East,
                'W' => Action.West,
                'L' => Action.Left,
                'R' => Action.Right,
                'F' => Action.Forward,
                _ => throw new NotSupportedException()
            },
            int.Parse(line.Substring(1, line.Length - 1)));
    }

    /// <summary>
    /// Defines the ship's position
    /// </summary>
    public sealed record Position(int Orientation, Point Coordinates);

    /// <summary>
    /// Defines the ship's position with the way point.
    /// </summary>
    private sealed record PositionWithWaypoint(Point Coordinates, Point Waypoint);

    private static Point East = new Point(x: 1, y: 0);
    private static Point North = new Point(x: 0, y: -1);
    private static Point South = new Point(x: 0, y: 1);
    private static Point West = new Point(x: -1, y: 0);
    private static ImmutableArray<Point> Directions = ImmutableArray
        .Create(
            North,
            East,
            South,
            West);

}
