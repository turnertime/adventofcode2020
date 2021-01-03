using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day03Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(3));
            var partI = Day03.Solution.PartI(input);
            var partII = Day03.Solution.PartII(input);

            Assert.AreEqual("225", partI);
            Assert.AreEqual("1115775000", partII);
        }

    }

}
