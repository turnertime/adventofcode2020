using System.IO;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day14Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(14));
            var partI = Day14.Solution.PartI(input);
            var partII = Day14.Solution.PartII(input);

            Assert.AreEqual("11327140210986", partI);
            Assert.AreEqual("2308180581795", partII);
        }

    }

}
