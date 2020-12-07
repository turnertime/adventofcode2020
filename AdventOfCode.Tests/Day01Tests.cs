using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day01Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(1));
            var partI = Day01.Solution.PartI(input);
            var partII = Day01.Solution.PartII(input);

            Assert.AreEqual("926464", partI);
            Assert.AreEqual("65656536", partII);
        }

    }

}
