using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day06
    {

        public static readonly AdventSolution Solution = new AdventSolution(
            Day: 6,
            Name: "Custom Customs",
            PartI: input => input
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(line => _whitespace.Replace(line, string.Empty))
                .Select(line => line.Distinct().Count())
                .Sum()
                .ToString(),
            PartII: input => input
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(group =>
                {
                    var distinct = _whitespace
                        .Replace(group, string.Empty)
                        .Distinct()
                        .ToImmutableHashSet();
                    var lines = Utilities.NewlinePattern.Split(group);
                    return distinct
                        .Count(value => lines.All(l => l.Contains(value)));
                })
                .Sum()
                .ToString());

        private static readonly Regex _whitespace = new Regex("\\s");

    }
}
