using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day13Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(13));
            var partI = Day13.Solution.PartI(input);
            var partII = Day13.Solution.PartII(input);

            Assert.AreEqual("8063", partI);
            Assert.AreEqual("775230782877242", partII);
        }

    }

}
