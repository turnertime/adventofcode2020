using System;
using System.Diagnostics;
using System.IO;

var day = args.Length < 1 ? string.Empty : args[0];

// read input if available
var binDirectory = AppDomain.CurrentDomain.BaseDirectory;
var path = Path.Combine(binDirectory, $"../../../input/Day{day}.txt");
var input = File.Exists(path)
    ? System.IO.File.ReadAllLines(path)
    : new string[0];

var stopwatch = Stopwatch.StartNew();
switch (day) {
    case "1":
        Console.WriteLine("--- Day 1: Report Repair ---");
        Day1.Run(input);
        Console.WriteLine($"Finished in ({stopwatch.ElapsedMilliseconds}) ms");
        break;
    case "2":
        Console.WriteLine("--- Day 2: Password Philosophy ---");
        Day2.Run(input);
        Console.WriteLine($"Finished in ({stopwatch.ElapsedMilliseconds}) ms");
        break;
    default:
        Console.Beep();
        Console.WriteLine($"Day '{day}', was not found.", Console.Error);
        break;
}
