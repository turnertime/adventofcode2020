<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

static void Main()
{
	var day = 10;
	var input = System.IO.File.ReadAllText(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), $"input/Day{day:00}.txt"));

    input.Dump();
}
