using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day02Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var solution = Day02.Run(TestUtilities.ReadInputLines(2));

            Assert.AreEqual("434", solution.PartA);
            Assert.AreEqual("509", solution.PartB);
        }

    }

}
