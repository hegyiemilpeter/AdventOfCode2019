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
        public void Test1()
        {
            int response = day2_solution.GetPositionAtZero(@"..\..\..\Inputs\day2_test1.txt", false);
            Assert.AreEqual(3500, response);
        }

        [Test]
        public void TestRelease()
        {
            int response = day2_solution.GetPositionAtZero(@"..\..\..\Inputs\day2_1.txt", true);
            Assert.AreEqual(9706670, response);
        }

        [Test]
        public void Day2_2Release()
        {
            int response = day2_solution.GetPairForResult(@"..\..\..\Inputs\day2_1.txt", 19690720);
        }
    }
}
