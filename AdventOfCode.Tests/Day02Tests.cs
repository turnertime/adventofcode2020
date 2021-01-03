using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day02Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(2));
            var partI = Day02.Solution.PartI(input);
            var partII = Day02.Solution.PartII(input);

            Assert.AreEqual("434", partI);
            Assert.AreEqual("509", partII);
        }

    }

}
