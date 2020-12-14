using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day10Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(10));
            var partI = Day10.Solution.PartI(input);
            var partII = Day10.Solution.PartII(input);

            Assert.AreEqual("2482", partI);
            Assert.AreEqual("96717311574016", partII);
        }

    }

}
