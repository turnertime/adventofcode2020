using System;
using System.Diagnostics;
using System.IO;

// validate day
var rawDay = args.Length < 1 ? string.Empty : args[0];
if (!int.TryParse(rawDay, out var day) || day < 1 || day > 25)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Specified day must be between one and twenty five");
    Console.ResetColor();
    return;
}

// read input if available
var binDirectory = AppDomain.CurrentDomain.BaseDirectory;
var path = Path.Combine(binDirectory, $"../../../input/Day{day:00}.txt");
if (!File.Exists(path))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Day '{rawDay}' input not found");
    Console.ResetColor();
    return;
}
var input = File.Exists(path) ? File.ReadAllLines(path) : new string[0];

// solve the specified day
var stopwatch = Stopwatch.StartNew();
Solution solution;
switch (day)
{
    case 1:
        Console.WriteLine("--- Day 1: Report Repair ---");
        solution = Day01.Run(input);
        break;
    case 2:
        Console.WriteLine("--- Day 2: Password Philosophy ---");
        solution = Day02.Run(input);
        break;
    case 3:
        Console.WriteLine("--- Day 3: Toboggan Trajectory ---");
        solution = Day03.Run(input);
        break;
    default:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Day '{rawDay}', has not been solved yet.");
        Console.ResetColor();
        return;
}

// write solution to console
Console.WriteLine($" - A: {solution.PartA}");
Console.WriteLine($" - B: {solution.PartB}");
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine($"--- Finished in ({stopwatch.ElapsedMilliseconds}) ms ---");
Console.ResetColor();
