using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day12Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(12));
            var partI = Day12.Solution.PartI(input);
            var partII = Day12.Solution.PartII(input);

            Assert.AreEqual("1294", partI);
            Assert.AreEqual("20592", partII);
        }

    }

}
