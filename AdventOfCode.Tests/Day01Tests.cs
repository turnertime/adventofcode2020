using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day01Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = TestUtilities.ReadInputLines(1);

            var solution = Day01.Run(input);

            Assert.AreEqual("926464", solution.PartA);
            Assert.AreEqual("65656536", solution.PartB);
        }

    }

}
