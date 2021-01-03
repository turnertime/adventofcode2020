using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class TestUtilities
    {

        public static string GetInputPath(int day)
        {
            return Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                $"../../../../input/Day{day:00}.txt");
        }

    }

}
