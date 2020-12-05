using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day04Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var solution = Day04.Run(TestUtilities.ReadInputLines(4));

            Assert.AreEqual("202", solution.PartA);
            Assert.AreEqual("137", solution.PartB);
        }

    }

}
