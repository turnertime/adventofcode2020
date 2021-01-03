using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day19
    {

        public static readonly AdventSolution Solution = new AdventSolution(
            Day: 19,
            Name: "Monster Messages",
            PartI: input =>
            {
                var lines = input.SplitLines();
                var splitIndex = lines.IndexOf(string.Empty);
                var ruleLookup = lines
                    .Take(splitIndex)
                    .Select(ParseRule)
                    .ToImmutableDictionary();
                var messages = lines
                    .Skip(splitIndex + 1)
                    .ToImmutableArray();
                return messages
                    .Count(x => FindNextMatches(ruleLookup, x, 0, 0).Any(length => length == x.Length))
                    .ToString();
            },
            PartII: input =>
            {
                var lines = input
                    .Replace("8: 42", "8: 42 | 42 8")
                    .Replace("11: 42 31", "11: 42 31 | 42 11 31")
                    .SplitLines();
                var splitIndex = lines.IndexOf(string.Empty);
                var ruleLookup = lines
                    .Take(splitIndex)
                    .Select(ParseRule)
                    .ToImmutableDictionary();
                var messages = lines
                    .Skip(splitIndex + 1)
                    .ToImmutableArray();
                return messages
                    .Count(x => FindNextMatches(ruleLookup, x, 0, 0).Any(length => length == x.Length))
                    .ToString();
            });


        private static KeyValuePair<int, Rule> ParseRule(string rawRule)
        {
            var match = _rulePattern.Match(rawRule);
            var ruleId = int.Parse(match.Groups["RuleId"].Value);
            var matchValue = match.Groups["Match"].Value.FirstOrDefault();
            var redirectValue = match.Groups["Redirect"].Value;
            var orGroups = string.IsNullOrEmpty(redirectValue)
                ? ImmutableArray<ImmutableArray<int>>.Empty
                : match.Groups["Redirect"].Value
                    .Split(" | ")
                    .Select(orGroup =>
                        orGroup
                            .Split(" ")
                            .Select(int.Parse)
                            .ToImmutableArray())
                    .ToImmutableArray();
            return KeyValuePair.Create(
                ruleId,
                new Rule(matchValue, orGroups));
        }

        private static ImmutableArray<int> FindNextMatches(
            ImmutableDictionary<int, Rule> ruleLookup,
            string message,
            int ruleId,
            int position)
        {
            var rule = ruleLookup[ruleId];
            return rule.OrGroup.IsEmpty
                ? message.ElementAtOrDefault(position) == rule.MatchValue
                    ? ImmutableArray.Create(position + 1)
                    : ImmutableArray<int>.Empty
                : rule.OrGroup
                    .SelectMany(rules => rules
                        .Aggregate(
                            ImmutableArray.Create(position),
                            (current, next) => current.SelectMany(i => FindNextMatches(ruleLookup, message, next, i))
                                .ToImmutableArray()))
                    .ToImmutableArray();
        }

        private sealed record Rule(char MatchValue, ImmutableArray<ImmutableArray<int>> OrGroup);

        private static readonly Regex _rulePattern = new(
            @"^(?<RuleId>\d+): (""(?<Match>[ab])""|(?<Redirect>.+))$",
            RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

    }
}
