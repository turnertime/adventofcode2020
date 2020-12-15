<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

static void Main()
{
	var day = 13;
	var path = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), $"input/Day{day:00}.txt");
	var lines = System.IO.File.ReadAllLines(path);

}



