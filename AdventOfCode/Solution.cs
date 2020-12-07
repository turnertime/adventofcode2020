using Spectre.Console;
/// <summary>
/// Defines the solution to part I and II.
/// </summary>
public sealed record Solution(string PartA, string PartB);

public sealed record SolutionProgress(ProgressTask Progress, AdventSolution Solution, string Path);
