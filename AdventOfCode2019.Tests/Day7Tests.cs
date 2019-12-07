using AdventOfCode2019.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Tests
{
    public class Day7Tests
    {
        [Test]
        [TestCase(@"..\..\..\Inputs\day7_demo1.txt", new int[] { 4,3,2,1,0 }, ExpectedResult = 43210)]
        [TestCase(@"..\..\..\Inputs\day7_demo2.txt", new int[] { 0,1,2,3,4 }, ExpectedResult = 54321)]
        [TestCase(@"..\..\..\Inputs\day7_demo3.txt", new int[] { 1,0,4,3,2 }, ExpectedResult = 65210)]
        public int GetMaximumThrusterSignal(string path, int[] phase)
        {
            Day7 day7_solution = new Day7();
            return day7_solution.GetuOutput(path, 0);
        }

        [Test]
        public void FirstStarTest()
        {
            Day7 day7_solution = new Day7();
            var response = day7_solution.GetuOutput(@"..\..\..\Inputs\day7_1.txt", 0);
            Assert.AreEqual(0, response);
        }
    }
}
