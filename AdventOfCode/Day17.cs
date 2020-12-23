using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

public static class Day17
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 17,
        Name: "Conway Cubes",
        PartI: input =>
        {
            var activeCubes = input
                .SplitLines()
                .SelectMany((line, y) => line
                    .Select((c, x) => (x, y, c == '#')))
                .Where(x => x.Item3)
                .Select(x => new Cube(x.Item1, x.Item2, 0))
                .ToImmutableHashSet();

            return Enumerable.Range(1, 6)
                .Aggregate(
                    activeCubes,
                    (current, _) => RunCycle(current, GetNeighbouringCubes).ToImmutableHashSet())
                .LongCount()
                .ToString();
        },
        PartII: input =>
        {
            var activeCubes = input
                .SplitLines()
                .SelectMany((line, y) => line
                    .Select((c, x) => (x, y, c == '#')))
                .Where(x => x.Item3)
                .Select(x => new HyperCube(x.Item1, x.Item2, 0, 0))
                .ToImmutableHashSet();

            return Enumerable.Range(1, 6)
                .Aggregate(
                    activeCubes,
                    (current, _) => RunCycle(current, GetNeighbouringHyperCubes).ToImmutableHashSet())
                .LongCount()
                .ToString();
        });

    /// <summary>
    /// Represents the position cube in 3 dimensions.
    /// </summary>
    private sealed record Cube(int X, int Y, int Z);


    /// <summary>
    /// Represents the position cube in 4 dimensions.
    /// </summary>

    private sealed record HyperCube(int X, int Y, int Z, int W);

    /// <summary>
    /// Runs a power cycle determining active cubes.
    /// </summary>
    private static IEnumerable<T> RunCycle<T>(ImmutableHashSet<T> activeCubes, Func<T, ImmutableArray<T>> getNeighbouringCubes)
    {
        var inactiveDictionary = new Dictionary<T, int>(2 * activeCubes.Count);
        foreach (var activeCube in activeCubes)
        {
            var activeCount = 0;
            foreach (var neighbour in getNeighbouringCubes(activeCube))
            {
                if (activeCubes.Contains(neighbour))
                {
                    activeCount += 1;
                }
                else
                {
                    if (!inactiveDictionary.ContainsKey(neighbour))
                    {
                        inactiveDictionary.Add(neighbour, 0);
                    }
                    inactiveDictionary[neighbour] += 1;
                }
            }
            if (activeCount == 2 || activeCount == 3)
            {
                yield return activeCube;
            }
        }
        foreach (var inactiveCube in inactiveDictionary)
        {
            if (inactiveCube.Value == 3)
            {
                yield return inactiveCube.Key;
            }
        }
    }

    /// <summary>
    /// Gets neighbouring cubes in 3 dimensions.
    /// </summary>
    private static ImmutableArray<Cube> GetNeighbouringCubes(Cube cube)
    {
        return Enumerable.Range(-1, 3)
            .SelectMany(x => Enumerable.Range(-1, 3)
                .SelectMany(y => Enumerable.Range(-1, 3)
                    .Select(z => new Cube(x, y, z))))
            .Where(cube => !(cube.X == 0 && cube.Y == 0 && cube.Z == 0))
            .Select(offset => new Cube(cube.X + offset.X, cube.Y + offset.Y, cube.Z + offset.Z))
            .ToImmutableArray();
    }

    /// <summary>
    /// Gets neighbouring cubes in 4 dimensions.
    /// </summary>
    private static ImmutableArray<HyperCube> GetNeighbouringHyperCubes(HyperCube cube)
    {
        return Enumerable.Range(-1, 3)
            .SelectMany(x => Enumerable.Range(-1, 3)
                .SelectMany(y => Enumerable.Range(-1, 3)
                    .SelectMany(z => Enumerable.Range(-1, 3)
                        .Select(w => new HyperCube(x, y, z, w)))))
            .Where(cube => !(cube.X == 0 && cube.Y == 0 && cube.Z == 0 && cube.W == 0))
            .Select(offset => new HyperCube(cube.X + offset.X, cube.Y + offset.Y, cube.Z + offset.Z, cube.W + offset.W))
            .ToImmutableArray();
    }

}
