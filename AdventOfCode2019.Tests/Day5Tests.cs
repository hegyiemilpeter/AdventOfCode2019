using AdventOfCode2019.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Tests
{
    public class Day5Tests
    {
        [Test]
        public void FirstStarTest()
        {
            Day5 day5Solution = new Day5();
            var response = day5Solution.GetuOutput(@"..\..\..\Inputs\day5.txt", 1);
            Assert.AreEqual(13285749, response);
        }

        [Test]
        [TestCase(@"..\..\..\Inputs\day5_2_0.txt", 8, ExpectedResult = 1)]
        [TestCase(@"..\..\..\Inputs\day5_2_0.txt", 3, ExpectedResult = 0)]
        [TestCase(@"..\..\..\Inputs\day5_2_1.txt", 0, ExpectedResult = 0)]
        [TestCase(@"..\..\..\Inputs\day5_2_1.txt", 1, ExpectedResult = 1)]
        [TestCase(@"..\..\..\Inputs\day5_2_1.txt", 5, ExpectedResult = 1)]
        [TestCase(@"..\..\..\Inputs\day5_2_2.txt", 1, ExpectedResult = 1)]
        [TestCase(@"..\..\..\Inputs\day5_2_2.txt", 5, ExpectedResult = 1)]
        [TestCase(@"..\..\..\Inputs\day5_2_2.txt", 0, ExpectedResult = 0)]
        [TestCase(@"..\..\..\Inputs\day5_2_3.txt", 7, ExpectedResult = 999)]
        [TestCase(@"..\..\..\Inputs\day5_2_3.txt", 8, ExpectedResult = 1000)]
        [TestCase(@"..\..\..\Inputs\day5_2_3.txt", 9, ExpectedResult = 1001)]
        public int SecondStart_DemoTests(string path, int start)
        {
            Day5 day5Solution = new Day5();
            var response = day5Solution.GetuOutput(path, start);
            return response;
        }

        [Test]
        public void SecondStarTest()
        {
            Day5 day5Solution = new Day5();
            var response = day5Solution.GetuOutput(@"..\..\..\Inputs\day5.txt", 5);
            Assert.AreEqual(5000972, response);
        }
    }
}
