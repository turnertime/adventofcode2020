using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode.Tests
{

    internal static class Day04Tests
    {

        [Test]
        public static void Run_AssertExpectedOutput()
        {
            var input = File.ReadAllText(TestUtilities.GetInputPath(4));
            var partI = Day04.Solution.PartI(input);
            var partII = Day04.Solution.PartII(input);

            Assert.AreEqual("202", partI);
            Assert.AreEqual("137", partII);
        }

    }

}
