using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day08Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(8));
            var partI = Day08.Solution.PartI(input);
            var partII = Day08.Solution.PartII(input);

            Assert.AreEqual("1134", partI);
            Assert.AreEqual("1205", partII);
        }

    }

}
