using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode;

public static class Day08
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 8,
        Name: "Handheld Halting",
        PartI: input =>
        {
            return input
                .ParseInstructions()
                .Execute()
                .Accumulator
                .ToString();
        },
        PartII: input =>
        {
            var instructions = input.ParseInstructions();

            return instructions
                .Select((instruction, i) => (Index: i, Instruction: instruction))
                .Where(i => i.Instruction.Operation != "acc")
                .Select(x => instructions.Execute(x.Index))
                .First(r => r.Finished)
                .Accumulator
                .ToString();
        });

    private sealed record Instruction(string Operation, int Argument);

    private sealed record Result(bool Finished, int Accumulator);

    private static ImmutableArray<Instruction> ParseInstructions(this string input)
    {
        return input
            .SplitLines()
            .Select(line => line.Split(' '))
            .Select(line => new Instruction(line[0], int.Parse(line[1])))
            .ToImmutableArray();
    }

    private static Result Execute(this ImmutableArray<Instruction> instructions, int? swap = default)
    {
        var hash = new HashSet<int>(instructions.Length);
        var index = 0;
        var accumulator = 0;
        var failed = false;
        while (index < instructions.Length)
        {
            if (hash.Contains(index)) { failed = true; break; } else { hash.Add(index); }

            var instruction = instructions[index];
            instruction = swap == index ? new Instruction(instruction.Operation == "jmp" ? "nop" : "jmp", instruction.Argument) : instruction;
            switch (instruction.Operation)
            {
                case "jmp":
                    index += instruction.Argument;
                    break;
                case "acc":
                    accumulator += instruction.Argument;
                    index++;
                    break;
                case "nop":
                    index++;
                    break;
            }
        }
        return new Result(Finished: !failed, Accumulator: accumulator);
    }

}
