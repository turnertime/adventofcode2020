using System;
using System.Diagnostics;
using System.IO;

// validate day
var rawDay = args.Length < 1 ? string.Empty : args[0];
if (!int.TryParse(rawDay, out var day) || day < 1 || day > 31)
{
    Console.WriteLine("Specified day must be between 1-30");
    return;
}

// read input if available
var binDirectory = AppDomain.CurrentDomain.BaseDirectory;
var path = Path.Combine(binDirectory, $"../../../input/Day{day:00}.txt");
if (!File.Exists(path))
{
    Console.WriteLine($"Day {rawDay} input not found", Console.Error);
    return;
}

var input = File.Exists(path) ? File.ReadAllLines(path) : new string[0];

var stopwatch = Stopwatch.StartNew();
switch (day)
{
    case 1:
        Console.WriteLine("--- Day 1: Report Repair ---");
        Day01.Run(input);
        break;
    case 2:
        Console.WriteLine("--- Day 2: Password Philosophy ---");
        Day02.Run(input);
        break;
    case 3:
        Console.WriteLine("--- Day 3: Toboggan Trajectory ---");
        Day03.Run(input);
        break;
    default:
        Console.WriteLine($"Day '{rawDay}', has not been solved yet.", Console.Error);
        return;
}
Console.WriteLine($"Finished in ({stopwatch.ElapsedMilliseconds}) ms");
