using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    internal static class TestUtilities
    {

        public static string[] ReadInputLines(int day)
        {
            var inputPath = Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                $"../../../../input/Day{day:00}.txt");
            Assert.IsTrue(File.Exists(inputPath), $"Required, advent day input '{inputPath}' does not exist.");

            return File.ReadAllLines(inputPath);
        }

    }
}
