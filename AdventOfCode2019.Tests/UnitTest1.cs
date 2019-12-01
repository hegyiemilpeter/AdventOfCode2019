using AdventOfCode2019.Core;
using NUnit.Framework;
using System.IO;

namespace AdventOfCode2019.Tests
{
    public class Tests
    {
        Day1 day1_solution = new Day1();

        [Test]
        public void Test1()
        {
            int amount = day1_solution.CalculateRequiredFuel(100756);
            Assert.AreEqual(33583, amount);
        }

        [Test]
        public void Test2()
        {
            int amount = day1_solution.CalculateFullAmount(@"C:\Users\emilh\source\repos\AdventOfCode2019\AdventOfCode2019.Tests\Inputs\day1_1");
            Assert.AreEqual(3323874, amount);
        }

        [Test]
        public void Test3()
        {
            int amount = day1_solution.CalculateAdvancedAmount(100756);
            Assert.AreEqual(50346, amount);
        }

        [Test]
        public void Test4()
        {
            int amount = day1_solution.CalculateFullAdvancedAmount(@"C:\Users\emilh\source\repos\AdventOfCode2019\AdventOfCode2019.Tests\Inputs\day1_2");
            Assert.AreEqual(4982961, amount);
        }
    }
}