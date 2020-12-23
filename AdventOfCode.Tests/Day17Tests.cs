using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day17Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(17));
            var partI = Day17.Solution.PartI(input);
            var partII = Day17.Solution.PartII(input);

            Assert.AreEqual("395", partI);
            Assert.AreEqual("2296", partII);
        }

    }

}
