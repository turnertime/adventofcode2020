using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day18Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(18));
            var partI = Day18.Solution.PartI(input);
            var partII = Day18.Solution.PartII(input);

            Assert.AreEqual("1402255785165", partI);
            Assert.AreEqual("119224703255966", partII);
        }

    }

}
