using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.IO;
using Spectre.Console;

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
        AnsiConsole.Render(new Markup(":stop_sign: Specified [bold red]day[/] must be between one and twenty five."));
        return 87;
    }

    // read input if available
    var path = Path.Combine(dir, $"Day{day:00}.txt");
    var input = File.Exists(path) ? File.ReadAllLines(path) : new string[0];

    // solve the specified day
    var stopwatch = Stopwatch.StartNew();
    Solution solution;
    switch (day)
    {
        case 1:
            AnsiConsole.Render(new Rule("Day 1: Report Repair") { Alignment = Justify.Left });
            solution = Day01.Run(input);
            break;
        case 2:
            AnsiConsole.Render(new Rule("Day 1: Password Philosophy") { Alignment = Justify.Left });
            solution = Day02.Run(input);
            break;
        case 3:
            AnsiConsole.Render(new Rule("Day 1: Toboggan Trajectory") { Alignment = Justify.Left });
            solution = Day03.Run(input);
            break;
        case 4:
            AnsiConsole.Render(new Rule("Day 4: Passport Processing") { Alignment = Justify.Left });
            solution = Day04.Run(input);
            break;
        case 5:
            AnsiConsole.Render(new Rule("Day 5: Binary Boarding") { Alignment = Justify.Left });
            solution = Day05.Run(input);
            break;
        default:
            AnsiConsole.Render(new Markup($":warning: [bold yellow]Day '{day}', has not been solved yet.[/]"));
            return 87;
    }

    // write solution to console
    var table = new Table();
    table.AddColumn("Part I");
    table.AddColumn("Part II");
    table.AddRow($"{solution.PartA}", $"{solution.PartB}");
    AnsiConsole.Render(table);
    AnsiConsole.Render(new Markup($":stopwatch: [bold green]Finished[/] in {stopwatch.ElapsedMilliseconds} ms."));
    return 0;

});

return rootCommand.InvokeAsync(args).Result;


