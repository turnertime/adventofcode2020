using System.Collections.Immutable;
using System.Text.RegularExpressions;

public static class Utilities
{

    /// <summary>
    /// Splits the specified string by new line.
    /// </summary>
    public static IImmutableList<string> SplitLines(this string value)
    {
        return value is null
            ? ImmutableArray<string>.Empty
            : NewlinePattern.Split(value).ToImmutableArray();
    }

    /// <summary>
    /// Pattern to find cross-platform newlines.
    /// </summary>
    public static readonly Regex NewlinePattern = new Regex("\r\n|\n|\r", RegexOptions.Compiled);

}
