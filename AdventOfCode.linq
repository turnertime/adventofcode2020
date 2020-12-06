<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
</Query>

void Main()
{
	var day = 6;
	var input = Path.Combine(
		Path.GetDirectoryName(Util.CurrentQueryPath),
		$"input/Day{day:00}.txt");
	System.IO.File.ReadAllText(input)
		.Split($"{Environment.NewLine}{Environment.NewLine}")
		.Select(line => Whitespace.Replace(line, string.Empty))
		.Select(line => line.Distinct().Count())
		.Sum()
		.Dump();
		
	System.IO.File.ReadAllText(input)
		.Split($"{Environment.NewLine}{Environment.NewLine}")
		.Select(group =>
		{
var distinct = Whitespace.Replace(group, string.Empty).Distinct().ToImmutableHashSet();
			var lines = NewlinePattern.Split(group);
			return distinct
				.Where(value => lines.All(l => l.Contains(value)))
				.Count();
		})
				.Sum()
		.Dump();
}

private static Regex Whitespace = new Regex("\\s");

/// <summary>
/// Computes the seat ID from the row and column.
/// </summary>
private static int CalculateSeat(int row, int column)
{
	return (row * 8) + column;
}

private static readonly Regex NewlinePattern = new Regex("\r\n|\n|\r", RegexOptions.Compiled);