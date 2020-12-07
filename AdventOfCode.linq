<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
</Query>

void Main()
{
	var day = 7;
	var input = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), $"input/Day{day:00}.txt");
    
    // part I
    var bagRegex = new Regex("[a-z]+ [a-z]+ bag", RegexOptions.IgnoreCase);
    var bagLookup = System.IO.File.ReadAllLines(input)
        .Select(line => bagRegex.Matches(line))
        .Select(match => (Container: match.First().Value.Replace(" bag", ""), Contents: match.Skip(1).Select(c => c.Value.Replace(" bag", "")).ToImmutableArray()))
        .ToImmutableDictionary(match => match.Container, match => match.Contents, StringComparer.InvariantCultureIgnoreCase);
    
    bagLookup
        .Keys
        .Count(bag => ContainsGoldBag(bagLookup, bag))
        .Dump();


    // part II
    var bagNumberRegex = new Regex(@"(?:(?<number>\d+) )?(?<bagId>[a-z]+ [a-z]+) bag", RegexOptions.IgnoreCase);
    var bag2Lookup = System.IO.File.ReadAllLines(input)
        .Select(line => bagNumberRegex.Matches(line))
        .Select(match => (Container: match.First().Groups["bagId"].Value, Contents: match.Skip(1).Select(c => (Count: c.Groups["number"].Value, BagId: c.Groups["bagId"].Value)).ToImmutableArray()))
        .ToImmutableDictionary(match => match.Container, match => match.Contents, StringComparer.InvariantCultureIgnoreCase);
    
    (CountBags(bag2Lookup, "shiny gold") - 1).Dump();
}

public static bool ContainsGoldBag(ImmutableDictionary<string, ImmutableArray<string>> bags, string bagId) {
    
    foreach(var bag in bags.GetValueOrDefault(bagId, ImmutableArray<string>.Empty))
    {
        if (StringComparer.InvariantCultureIgnoreCase.Equals("shiny gold", bag)) { return true; }
        else {
            if (ContainsGoldBag(bags, bag)) { return true; }
        }
    }
    return false;
}

public static int CountBags(ImmutableDictionary<string, ImmutableArray<(string Count, string BagId)>> bags, string bagId) {
    var value = 1;
    foreach (var content in bags.GetValueOrDefault(bagId))
    {
        if (int.TryParse(content.Count, out var bagCount))
        {
            if (bagCount > 0)
            {
                value += bagCount * CountBags(bags, content.BagId);
            }
        }
    }
    return value;
}