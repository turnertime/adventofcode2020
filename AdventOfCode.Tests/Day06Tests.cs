using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day06Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(6));
            var partI = Day06.Solution.PartI(input);
            var partII = Day06.Solution.PartII(input);

            Assert.AreEqual("6662", partI);
            Assert.AreEqual("3382", partII);
        }

    }

}
