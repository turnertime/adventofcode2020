using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day07Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(7));
            var partI = Day07.Solution.PartI(input);
            var partII = Day07.Solution.PartII(input);

            Assert.AreEqual("164", partI);
            Assert.AreEqual("7872", partII);
        }

    }

}
