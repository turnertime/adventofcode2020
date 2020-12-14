<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
</Query>

static void Main()
{
	var day = 11;
	var input = System.IO.File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), $"input/Day{day:00}.txt"));

}
