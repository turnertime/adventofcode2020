using System.Collections.Immutable;
using System.Text.RegularExpressions;

public static class Utilities
{

    /// <summary>
    /// Removes newlines (cross platform) from specified string.
    /// </summary>
    public static string RemoveNewlines(this string value)
    {
        if (value is null) { return value; }
        return NewlinePattern.Replace(value, string.Empty);
    }

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
