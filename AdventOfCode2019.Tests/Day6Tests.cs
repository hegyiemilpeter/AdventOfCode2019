using AdventOfCode2019.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Tests
{
    public class Day6Tests
    {
        [Test]
        public void FirstStartTest_Demo()
        {
            Day6 day6Solution = new Day6();
            var response = day6Solution.NumberOfOrbits(@"..\..\..\Inputs\day6_demo1.txt");
            Assert.AreEqual(42, response);
        }

        [Test]
        public void FirstStartTest()
        {
            Day6 day6Solution = new Day6();
            var response = day6Solution.NumberOfOrbits(@"..\..\..\Inputs\day6_1.txt");
            Assert.AreEqual(200001, response);
        }

        [Test]
        public void SecondStartTest_Demo()
        {
            Day6 day6Solution = new Day6();
            var response = day6Solution.NumberOfTransfers(@"..\..\..\Inputs\day6_demo2.txt");
            Assert.AreEqual(4, response);
        }

        [Test]
        public void SecondStartTest()
        {
            Day6 day6Solution = new Day6();
            var response = day6Solution.NumberOfTransfers(@"..\..\..\Inputs\day6_1.txt");
            Assert.AreEqual(379, response);
        }
    }
}
