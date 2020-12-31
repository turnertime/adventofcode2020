using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Day18
{

    public static AdventSolution Solution = new AdventSolution(
        Day: 18,
        Name: "Operation Order",
        PartI: input =>
        {
            return input
                .SplitLines()
                .Select(line => line.Replace(" ", string.Empty))
                .Select(Solve)
                .Sum()
                .ToString();
        },
        PartII: input =>
        {
            return input
                .SplitLines()
                .Select(line => line.Replace(" ", string.Empty))
                .Select(SolvePartII)
                .Sum()
                .ToString();
        });

    public enum MathOperator
    {
        Add,
        Multiply
    }

    private static long Solve(string expression)
    {
        long amount = 0;
        var lastOperator = MathOperator.Add;
        var position = 0;
        while (position < expression.Length)
        {
            switch (expression[position])
            {
                case '(':
                    var subexpression = ReadSubexpression(expression, position);
                    var result = Solve(subexpression);
                    amount = lastOperator == MathOperator.Add
                        ? amount + result
                        : amount * result;
                    position += subexpression.Length + 1;
                    break;
                case '*':
                    lastOperator = MathOperator.Multiply;
                    break;
                case '+':
                    lastOperator = MathOperator.Add;
                    break;
                default:
                    var number = long.Parse(expression[position].ToString());
                    amount = lastOperator == MathOperator.Add
                        ? amount + number
                        : amount * number;
                    break;
            }
            position++;
        }
        return amount;
    }

    private static string ReadSubexpression(string expression, int position)
    {
        var depth = 0;
        var end = 0;
        foreach (var c in expression.Skip(position + 1))
        {
            switch (c)
            {
                case '(':
                    depth++;
                    break;
                case ')':
                    if (depth == 0) { return expression.Substring(position + 1, end); }
                    depth--;
                    break;
            }
            end++;
        }
        throw new InvalidOperationException("No end in sight");
    }

    private static long SolvePartII(string expression)
    {
        // replace sub expression
        var withSubs = "";
        var position = 0;
        while (position < expression.Length)
        {
            if (expression[position] == '(')
            {
                var result = ReadSubexpression(expression, position);
                withSubs += SolvePartII(result).ToString();
                position += result.Length + 2;
            }
            else
            {
                withSubs += expression[position].ToString();
                position++;
            }
        }

        // replace additions
        var addPattern = @"(\d+)\+(\d+)";
        var withAdds = withSubs;
        do
        {
            withAdds = Regex.Replace(
                withAdds,
                addPattern,
                m => (long.Parse(m.Groups[1].Value) + long.Parse(m.Groups[2].Value)).ToString());
        } while (withAdds.Contains("+"));


        // replace multiplications
        return withAdds
            .Split("*")
            .Select(long.Parse)
            .Aggregate((current, next) => current * next);
    }

}
