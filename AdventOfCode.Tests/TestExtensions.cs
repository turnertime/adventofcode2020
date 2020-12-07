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

        public static string[] ReadInputLines(int day)
        {
            var inputPath = GetInputPath(day);
            Assert.IsTrue(File.Exists(inputPath), $"Required, advent day input '{inputPath}' does not exist.");
            return File.ReadAllLines(inputPath);
        }

    }

}
