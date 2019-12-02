using AdventOfCode2019.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Tests
{
    public class Day2Tests
    {
        Day2 day2_solution = new Day2();

        [Test]
        public void Day2_TestDemoInput()
        {
            int response = day2_solution.GetPositionAtZero(@"..\..\..\Inputs\day2_test1.txt", null, null);
            Assert.AreEqual(3500, response);
        }

        [Test]
        public void FirstStarTest()
        {
            int response = day2_solution.GetPositionAtZero(@"..\..\..\Inputs\day2_1.txt", 12, 02);
            Assert.AreEqual(9706670, response);
        }

        [Test]
        public void SecondStarTest()
        {
            int response = day2_solution.GetNounVerbCombination(@"..\..\..\Inputs\day2_1.txt", 19690720);
            Assert.AreEqual(2552, response);
        }
    }
}
