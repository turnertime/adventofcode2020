using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day02
    {

        public static readonly AdventSolution Solution = new AdventSolution(
            Day: 2,
            Name: "Password Philosophy",
            PartI: input => input
                .SplitLines()
                .Select(line => _passwordPattern.Match(line))
                .Select(pattern => (
                    min: int.Parse(pattern.Groups["min"].Value),
                    max: int.Parse(pattern.Groups["max"].Value),
                    character: pattern.Groups["character"].Value[0],
                    password: pattern.Groups["password"].Value))
                .Count(pattern =>
                {
                    var occurrences = pattern.password.Count(c => c == pattern.character);
                    return occurrences >= pattern.min && occurrences <= pattern.max;
                })
                .ToString(),
            PartII: input => input
                .SplitLines()
                .Select(line => _passwordPattern.Match(line))
                .Select(pattern => (
                    first: int.Parse(pattern.Groups["min"].Value),
                    second: int.Parse(pattern.Groups["max"].Value),
                    character: pattern.Groups["character"].Value[0],
                    password: pattern.Groups["password"].Value))
                .Count(pattern =>
                {
                    var first = pattern.character == pattern.password[pattern.first - 1] ? 1 : 0;
                    var second = pattern.character == pattern.password[pattern.second - 1] ? 1 : 0;

                    return first + second == 1;
                })
                .ToString()
        );

        private static readonly Regex _passwordPattern = new Regex(
            @"^(?<min>\d+)-(?<max>\d+) (?<character>.): (?<password>.+)$",
            RegexOptions.Compiled | RegexOptions.Singleline
        );

    }
}
