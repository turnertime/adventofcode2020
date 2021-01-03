using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day19Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(19));
            var partI = Day19.Solution.PartI(input);
            var partII = Day19.Solution.PartII(input);

            Assert.AreEqual("269", partI);
            Assert.AreEqual("403", partII);
        }

    }

}
