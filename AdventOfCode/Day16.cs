using System;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode
{
    public static class Day16
    {

        public static readonly AdventSolution Solution = new AdventSolution(
            Day: 16,
            Name: "Ticket Translation",
            PartI: input =>
            {
                var data = ParseTicketData(input);

                return data.NearbyTickets
                    .SelectMany(ticket => ticket
                        .Where(field => !data.Rules.Any(r => r.Ranges.Any(range => range.Min <= field && range.Max >= field))))
                    .Sum()
                    .ToString();
            },
            PartII: input =>
            {
                var data = ParseTicketData(input);
                var validTickets = data.NearbyTickets
                    .Where(ticket => !ticket.Any(field => !data.Rules.Any(r => r.Ranges.Any(range => range.Min <= field && range.Max >= field))))
                    .Concat(new[] { data.YourTicket })
                    .ToImmutableArray();
                var length = validTickets.First().Length;

                var matchedRules = data.Rules
                    .SelectMany((rule, ruleIndex) =>
                        Enumerable.Range(0, length).Select(fieldIndex => (Rule: rule, RuleIndex: ruleIndex, FieldIndex: fieldIndex)))
                    .Where(rule => validTickets
                        .Select(fields => fields[rule.FieldIndex])
                        .All(field => rule.Rule.Ranges.Any(range => range.Min <= field && range.Max >= field)))
                    .Select(rule => new Match(RuleId: rule.Rule.Id, FieldIndex: rule.FieldIndex))
                    .GroupBy(x => x.FieldIndex)
                    .OrderBy(x => x.Count())
                    .Aggregate(
                        ImmutableHashSet<Match>.Empty,
                        (current, next) => current.Add(next.First(rule => current.All(existing => rule.RuleId != existing.RuleId))));

                return matchedRules
                    .Where(r => r.RuleId.StartsWith("departure"))
                    .Aggregate((long)1, (current, next) => current * data.YourTicket[next.FieldIndex])
                    .ToString();
            });


        private static TicketData ParseTicketData(string input)
        {
            var groups = input
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .ToImmutableArray();
            var rules = groups[0]
                .Split($"{Environment.NewLine}")
                .Select(rawRule =>
                {
                    var idSplit = rawRule.Split(":");
                    return new Rule(
                        Id: idSplit[0],
                        idSplit[1].Split(" or ")
                            .Select(rawRange =>
                            {
                                var range = rawRange.Split("-");
                                return new Range(long.Parse(range[0]), long.Parse(range[1]));
                            })
                            .ToImmutableArray());
                })
                .ToImmutableArray();
            var yourTicket = groups[1]
                .Split($"{Environment.NewLine}")
                .Skip(1)
                .First()
                .Split(",")
                .Select(long.Parse)
                .ToImmutableArray();
            var nearbyTickets = groups[2]
                .Split($"{Environment.NewLine}")
                .Skip(1)
                .Select(x => x.Split(",").Select(long.Parse).ToImmutableArray())
                .ToImmutableArray();

            return new TicketData(rules, yourTicket, nearbyTickets);
        }

        private sealed record Match(string RuleId, int FieldIndex);

        private sealed record Rule(string Id, ImmutableArray<Range> Ranges);

        private sealed record Range(long Min, long Max);

        private sealed record TicketData(ImmutableArray<Rule> Rules, ImmutableArray<long> YourTicket, ImmutableArray<ImmutableArray<long>> NearbyTickets);

    }
}
