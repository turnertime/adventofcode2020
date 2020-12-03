using System;
using System.Linq;
using System.Text.RegularExpressions;

internal static class Day2
{

    /// <summary>
    /// <a href="https://adventofcode.com/2020/day/2">Day 2</a>: Password Philosophy
    /// </summary>
    public static void Run(string[] lines)
    {
        var partIAnswer = lines
            .Select(line => PasswordPattern.Match(line))
            .Select(pattern => (
                min: int.Parse(pattern.Groups["min"].Value),
                max: int.Parse(pattern.Groups["max"].Value),
                character: pattern.Groups["character"].Value[0],
                password: pattern.Groups["password"].Value))
            .Count(pattern =>
            {
                var occurrences = pattern.password.Count(c => c == pattern.character);
                return occurrences >= pattern.min && occurrences <= pattern.max;
            });


        var partIIAnswer = lines
            .Select(line => PasswordPattern.Match(line))
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
            });

        Console.WriteLine($"Part  I: {partIAnswer}");
        Console.WriteLine($"Part II: {partIIAnswer}");
    }

    private static Regex PasswordPattern = new Regex(
        @"^(?<min>\d+)-(?<max>\d+) (?<character>.): (?<password>.+)$",
        RegexOptions.Compiled | RegexOptions.Singleline
    );

}
