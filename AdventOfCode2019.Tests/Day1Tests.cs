using AdventOfCode2019.Core;
using NUnit.Framework;

namespace AdventOfCode2019.Tests
{
    public class Day1Tests
    {
        Day1 day1_solution = new Day1();

        [Test]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(14, ExpectedResult = 2)]
        [TestCase(1969, ExpectedResult = 654)]
        [TestCase(100756, ExpectedResult = 33583)]
        public int CalculateFullAmount_SingleCases(int input)
        {
            int amount = day1_solution.CalculateRequiredFuel(input);
            return amount;
        }

        [Test]
        public void FirstStarTest()
        {
            int amount = day1_solution.CalculateFullAmount(@"..\..\..\Inputs\day1_1");
            Assert.AreEqual(3323874, amount);
        }

        [Test]
        [TestCase(14, ExpectedResult = 2)]
        [TestCase(1969, ExpectedResult = 966)]
        [TestCase(100756, ExpectedResult = 50346)]
        public int CalculateFullAdvancedAmount_SingleCases(int input)
        {
            int amount = day1_solution.CalculateAdvancedRequiredFuel(input);
            return amount;
        }

        [Test]
        public void SecondStarTest()
        {
            int amount = day1_solution.CalculateAdvancedFullAmount(@"..\..\..\Inputs\day1_2");
            Assert.AreEqual(4982961, amount);
        }
    }
}