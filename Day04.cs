using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

internal static class Day04
{

    /// <summary>
    /// <a href="https://adventofcode.com/2020/day/4">Day 4</a>: Passport Processing 
    /// </summary>
    public static Solution Run(string[] lines)
    {
        var requiredFields = ImmutableHashSet.Create(
            StringComparer.InvariantCultureIgnoreCase,
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid");

        var passports = lines
            .GroupByBlankLines()
            .Select(passport => KeyValueRegex
                .Matches(passport)
                .Select(match => new KeyValuePair<string, string>(match.Groups["key"].Value, match.Groups["value"].Value))
                .ToImmutableDictionary(StringComparer.InvariantCultureIgnoreCase))
            .Where(passport => requiredFields.All(passport.ContainsKey))
            .ToImmutableArray();

        var partA = passports.Length;

        var validationRules = new Dictionary<string, string>
        {
            ["byr"] = "^(19[2-8][0-9]|199[0-9]|200[0-2])$", // 1920-2002
            ["iyr"] = "^(201[0-9]|2020)$", // 2010-2020
            ["eyr"] = "^(202[0-9]|2030)$", // 2020-2030
            ["hgt"] = "^((59|6[0-9]|7[0-6])in|(1[5-8][0-9]|19[0-3])cm)$", // 150-193cm 59-76in
            ["hcl"] = "^#[0-9A-F]{6}$", // #ffffff
            ["ecl"] = "^(amb|blu|brn|gry|grn|hzl|oth)$",
            ["pid"] = "^\\d{9}$" // 9 digit number with leading zeros
        }.ToImmutableDictionary(
            x => x.Key,
            x => new Regex(x.Value, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase),
            StringComparer.InvariantCultureIgnoreCase);

        var partB = passports
            .Count(passport => validationRules
                .All(rule => rule.Value.IsMatch(passport[rule.Key])));

        return new Solution(partA, partB);
    }

    private static IEnumerable<string> GroupByBlankLines(this IEnumerable<string> lines)
    {
        var window = ImmutableList<string>.Empty;
        foreach (var line in lines)
        {
            if (line.Length == 0)
            {
                yield return string.Join(" ", window);
                window = ImmutableList<string>.Empty;
            }
            else
            {
                window = window.Add(line);
            }
        }
        yield return string.Join(" ", window);
    }

    private static Regex KeyValueRegex = new Regex(@"(?<key>\w+):(?<value>[^ ]+)", RegexOptions.Compiled | RegexOptions.Singleline);

}
