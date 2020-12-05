using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day05Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var solution = Day05.Run(TestUtilities.ReadInputLines(5));

            Assert.AreEqual("861", solution.PartA);
            Assert.AreEqual("633", solution.PartB);
        }

    }

}
