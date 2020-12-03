using System;
using System.Diagnostics;
using System.IO;

var day = args.Length < 1 ? string.Empty : args[0];

// read input if available
var binDirectory = AppDomain.CurrentDomain.BaseDirectory;
var path = Path.Combine(binDirectory, $"../../../input/Day{day}.txt");
if (!File.Exists(path))
{
    Console.WriteLine($"Day {day} input not found", Console.Error);
    return -1;
}

var input = File.Exists(path)
    ? File.ReadAllLines(path)
    : new string[0];

var stopwatch = Stopwatch.StartNew();
switch (day)
{
    case "1":
        Console.WriteLine("--- Day 1: Report Repair ---");
        Day1.Run(input);
        Console.WriteLine($"Finished in ({stopwatch.ElapsedMilliseconds}) ms");
        return 0;
    case "2":
        Console.WriteLine("--- Day 2: Password Philosophy ---");
        Day2.Run(input);
        Console.WriteLine($"Finished in ({stopwatch.ElapsedMilliseconds}) ms");
        return 0;
    case "3":
        Console.WriteLine("--- Day 3: TBD ---");
        Day2.Run(input);
        Console.WriteLine($"Finished in ({stopwatch.ElapsedMilliseconds}) ms");
        return 0;
    default:
        Console.WriteLine(
            string.IsNullOrWhiteSpace(day)
                ? $"Day '{day}', was not found."
                : "Please specify day such as '1' or '3'",
            Console.Error);
        return -1;
}
