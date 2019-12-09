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
        //[Test]
        //[TestCase(@"..\..\..\Inputs\day7_demo1.txt", ExpectedResult = 43210)]
        //[TestCase(@"..\..\..\Inputs\day7_demo2.txt", ExpectedResult = 54321)]
        //[TestCase(@"..\..\..\Inputs\day7_demo3.txt", ExpectedResult = 65210)]
        //public async Task<int> GetMaximumThrusterSignal(string path)
        //{
        //    Day7 day7_solution = new Day7();
        //    return await day7_solution.GetOutput(path, 0);
        //}

        //[Test]
        //public void FirstStarTest()
        //{
        //    Day7 day7_solution = new Day7();
        //    var response = day7_solution.GetOutput(@"..\..\..\Inputs\day7_1.txt", 0);
        //    Assert.AreEqual(46014, response);
        //}

        [Test]
        public async Task SecondStarTest_Demo()
        {
            Day7 day7_solution = new Day7();
            var response = await day7_solution.GetOutput(@"..\..\..\inputs\day7_1.txt");
        }
    }
}
