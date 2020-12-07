using System;
using System.Threading.Tasks;

/// <summary>
/// The solution to part I and II of an advent code day problem.
/// <summary>
public sealed record AdventSolution(
    int Day,
    string Name,
    Func<string, string> PartI,
    Func<string, string> PartII
);
