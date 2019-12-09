using AdventOfCode2019.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Tests
{
    public class Day7Tests
    {
        [Test]
        [TestCase(@"..\..\..\Inputs\day7_demo1.txt", ExpectedResult = 43210)]
        [TestCase(@"..\..\..\Inputs\day7_demo2.txt", ExpectedResult = 54321)]
        [TestCase(@"..\..\..\Inputs\day7_demo3.txt", ExpectedResult = 65210)]
        public float FirstStarTests_Demo(string path)
        {
            Day7 day7_solution = new Day7();
            return day7_solution.RunInlineAmplifiers(path);
        }

        [Test]
        public void FirstStarTest()
        {
            Day7 day7_solution = new Day7();
            var response = day7_solution.RunInlineAmplifiers(@"..\..\..\Inputs\day7_1.txt");
            Assert.AreEqual(46014, response);
        }

        [Test]
        [TestCase(@"..\..\..\inputs\day7_1.txt", ExpectedResult = 19581200)]
        [TestCase(@"..\..\..\inputs\day7_2_demo1.txt", ExpectedResult = 139629729)]
        [TestCase(@"..\..\..\inputs\day7_2_demo2.txt", ExpectedResult = 18216)]
        public float SecondStarTests(string path)
        {
            Day7 day7_solution = new Day7();
            float response = day7_solution.RunParalellAmplifiers(path);
            return response;
        }
    }
}
