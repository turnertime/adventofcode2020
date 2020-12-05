using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day03Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var solution = Day03.Run(TestUtilities.ReadInputLines(3));

            Assert.AreEqual("225", solution.PartA);
            Assert.AreEqual("1115775000", solution.PartB);
        }

    }

}
