using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day15Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(15));
            var partI = Day15.Solution.PartI(input);
            var partII = Day15.Solution.PartII(input);

            Assert.AreEqual("1259", partI);
            Assert.AreEqual("689", partII);
        }

    }

}
