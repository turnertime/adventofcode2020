using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day11Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(11));
            var partI = Day11.Solution.PartI(input);
            var partII = Day11.Solution.PartII(input);

            Assert.AreEqual("2324", partI);
            Assert.AreEqual("2068", partII);
        }

    }

}
