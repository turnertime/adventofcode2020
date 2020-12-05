using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.IO;

var rootCommand = new RootCommand
{
    new Argument<int>("day", "Indicates 25 days of christmas") { Arity = ArgumentArity.ExactlyOne },
    new Option<string>(
        aliases: new [] { "--dir", "-d" },
        getDefaultValue: () => Path.Combine(Environment.CurrentDirectory, "input/"),
        description: "Specifies the directory containing the input")
};

rootCommand.Description = "Solve Advent of Code 2020 Problem";

rootCommand.Handler = CommandHandler.Create<int, string>((day, dir) =>
{
    // validate day
    if (day < 1 || day > 25)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Specified day must be between one and twenty five");
        Console.ResetColor();
        return 87;
    }

    // read input if available
    var path = Path.Combine(dir, $"Day{day:00}.txt");
    if (!File.Exists(path))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Day '{day}' input not found");
        Console.ResetColor();
        return 2;
    }
    var input = File.ReadAllLines(path);

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
        case 4:
            Console.WriteLine("--- Day 4: Passport Processing ---");
            solution = Day04.Run(input);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Day '{day}', has not been solved yet.");
            Console.ResetColor();
            return 87;
    }

    // write solution to console
    Console.WriteLine($" - A: {solution.PartA}");
    Console.WriteLine($" - B: {solution.PartB}");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"--- Finished in ({stopwatch.ElapsedMilliseconds}) ms ---");
    Console.ResetColor();
    return 0;

});

return rootCommand.InvokeAsync(args).Result;


