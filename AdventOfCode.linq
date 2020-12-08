<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
</Query>

static void Main()
{
	var day = 8;
	var input = System.IO.File.ReadAllText(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), $"input/Day{day:00}.txt"));

    input.Dump();
}

