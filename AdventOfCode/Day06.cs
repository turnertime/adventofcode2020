using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

public static class Day06
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 6,
        Name: "Custom Customs",
        PartI: input => input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(line => Whitespace.Replace(line, string.Empty))
            .Select(line => line.Distinct().Count())
            .Sum()
            .ToString(),
        PartII: input => input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(group =>
            {
                var distinct = Whitespace
                    .Replace(group, string.Empty)
                    .Distinct()
                    .ToImmutableHashSet();
                var lines = Utilities.NewlinePattern.Split(group);
                return distinct
                    .Where(value => lines.All(l => l.Contains(value)))
                    .Count();
            })
            .Sum()
            .ToString());

    private static Regex Whitespace = new Regex("\\s");

}
