using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day05Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(5));
            var partI = Day05.Solution.PartI(input);
            var partII = Day05.Solution.PartII(input);

            Assert.AreEqual("861", partI);
            Assert.AreEqual("633", partII);
        }

    }

}
