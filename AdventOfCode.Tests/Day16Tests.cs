using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day16Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(16));
            var partI = Day16.Solution.PartI(input);
            var partII = Day16.Solution.PartII(input);

            Assert.AreEqual("20231", partI);
            Assert.AreEqual("1940065747861", partII);
        }

    }

}
