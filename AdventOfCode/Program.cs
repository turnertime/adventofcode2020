using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.IO;
using Spectre.Console;

var rootCommand = new RootCommand
{
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
        AnsiConsole.Markup(":stop_sign: Specified [bold red]day[/] must be between one and twenty five.");
        return 87;
    }

    // read input if available
    var path = Path.Combine(dir, $"Day{day:00}.txt");
    var input = File.Exists(path) ? File.ReadAllText(path) : "";

    // solve the specified day
    var stopwatch = Stopwatch.StartNew();
    Solution solution;
    switch (day)
    {
        case 1:
            AnsiConsole.Render(new Rule("Day 1: Report Repair") { Alignment = Justify.Left });
            solution = new Solution(Day01.Solution.PartI(input), Day01.Solution.PartII(input));
            break;
        case 2:
            AnsiConsole.Render(new Rule("Day 2: Password Philosophy") { Alignment = Justify.Left });
            solution = new Solution(Day02.Solution.PartI(input), Day01.Solution.PartII(input));
            break;
        case 3:
            AnsiConsole.Render(new Rule("Day 3: Toboggan Trajectory") { Alignment = Justify.Left });
            solution = new Solution(Day03.Solution.PartI(input), Day01.Solution.PartII(input));
            break;
        case 4:
            AnsiConsole.Render(new Rule("Day 4: Passport Processing") { Alignment = Justify.Left });
            solution = new Solution(Day04.Solution.PartI(input), Day01.Solution.PartII(input));
            break;
        case 5:
            AnsiConsole.Render(new Rule("Day 5: Binary Boarding") { Alignment = Justify.Left });
            solution = new Solution(Day05.Solution.PartI(input), Day01.Solution.PartII(input));
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
    AnsiConsole.Markup($":stopwatch: [bold green]Finished[/] in {stopwatch.ElapsedMilliseconds} ms.");
    return 0;

});

return rootCommand.InvokeAsync(args).Result;


