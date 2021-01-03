using System;
using System.Collections.Immutable;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode;
using Spectre.Console;

var rootCommand = new RootCommand
{
    new Option<string>(
        aliases: new [] { "--dir", "-d" },
        getDefaultValue: () => Path.Combine(Environment.CurrentDirectory, "input/"),
        description: "Specifies the directory containing the input")
};

rootCommand.Description = "Solve Advent of Code 2020 Problem";

rootCommand.Handler = CommandHandler.Create<string>(async dir =>
{
    AnsiConsole.Render(
    new FigletText("ADVENT OF CODE")
        .LeftAligned()
        .Color(Color.Red));

    var solutions = ImmutableArray.Create(
        Day01.Solution,
        Day02.Solution,
        Day03.Solution,
        Day04.Solution,
        Day05.Solution,
        Day06.Solution,
        Day07.Solution,
        Day08.Solution,
        Day09.Solution,
        Day10.Solution,
        Day11.Solution,
        Day12.Solution,
        Day13.Solution,
        Day14.Solution,
        Day15.Solution,
        Day16.Solution,
        Day17.Solution,
        Day18.Solution,
        Day19.Solution
    );

    var results = ImmutableArray<(AdventSolution Solution, string PartI, string PartII, TimeSpan Timing)>.Empty;
    await AnsiConsole
        .Progress()
        .Columns(new ProgressColumn[]
        {
            new JustifiedTaskDescriptionColumn { Alignment = Justify.Left },
            new ProgressBarColumn(),
            new PercentageColumn(),
            new ElapsedTimeColumn { Format = "ss\\:ffffff" },
            new SpinnerColumn()
        })
        .StartAsync(async ctx =>
        {
            var tasks = solutions
                .Select(solution => new SolutionProgress(
                    ctx.AddTask($"[green]Day {solution.Day:00}[/] : {solution.Name}"),
                    solution,
                    Path.Combine(dir, $"Day{solution.Day:00}.txt")))
                .Select(solution =>
                {
                    return Task.Factory.StartNew(() =>
                    {
                        solution.Progress.StartTask();
                        var input = File.ReadAllText(solution.Path);
                        solution.Progress.Increment(30);
                        var stopwatch = Stopwatch.StartNew();
                        var partI = solution.Solution.PartI(input);
                        solution.Progress.Increment(30);
                        var partII = solution.Solution.PartII(input);
                        stopwatch.Stop();
                        solution.Progress.Increment(40);
                        solution.Progress.StopTask();
                        results = results.Add((solution.Solution, PartI: partI, PartII: partII, Timing: stopwatch.Elapsed));
                    });
                });
            await Task.WhenAll(tasks);
        })
        .ContinueWith(_ =>
        {
            var table = new Table();
            table.Border(TableBorder.Ascii);
            table.Width(83);
            table.AddColumn("Day");
            table.AddColumn("Part I");
            table.AddColumn("Part II");
            table.AddColumn("Time (ms)");
            table.Columns[^1].RightAligned();
            foreach (var result in results.OrderBy(result => result.Solution.Day))
            {
                table.AddRow(
                    $"{result.Solution.Day:00} : {result.Solution.Name}",
                    $"{result.PartI}",
                    $"{result.PartII}",
                    $"{result.Timing.TotalMilliseconds}");
            }
            AnsiConsole.Render(table);
        });
    return 0;
});

return rootCommand.InvokeAsync(args).Result;
