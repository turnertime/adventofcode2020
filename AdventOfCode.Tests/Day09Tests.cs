using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day09Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(9));
            var partI = Day09.Solution.PartI(input);
            var partII = Day09.Solution.PartII(input);

            Assert.AreEqual("1309761972", partI);
            Assert.AreEqual("177989832", partII);
        }

    }

}
