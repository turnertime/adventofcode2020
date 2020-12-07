<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
</Query>

void Main()
{
	var day = 6;
	var input = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), $"input/Day{day:00}.txt");
    
    // part I
    System.IO.File.ReadAllText(input)
        .Dump();
        
    // part II
}
