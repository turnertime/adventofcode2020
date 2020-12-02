using System;

var day = args[0];

// read input if available
var binDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
var path = System.IO.Path.Combine(binDirectory, $"../../../Day{day}.txt");
var input = System.IO.File.Exists(path)
    ? System.IO.File.ReadAllLines(path)
    : new string[0];

var stopwatch = System.Diagnostics.Stopwatch.StartNew();
switch (day) {
    case "1":
        Console.WriteLine("--- Day 1: Report Repair ---");
        Console.WriteLine(Day1.Run(input));
        Console.WriteLine($"Finished in ({stopwatch.ElapsedMilliseconds}) ms");
        break;
    case "1-2":
        Console.WriteLine("--- Day 1: Part Two ---");
        Console.WriteLine(Day1.RunPartII(input));
        Console.WriteLine($"Finished in ({stopwatch.ElapsedMilliseconds}) ms");
        break;
    default:
        Console.Beep();
        Console.WriteLine($"Day '{day}', was not found.", Console.Error);
        break;
}
