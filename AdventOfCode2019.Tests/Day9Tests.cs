﻿using AdventOfCode2019.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Tests
{
    public class Day9Tests
    {
        [Test]
        [TestCase(@"..\..\..\Inputs\day9_1.txt")]
        public void FirstStarTests_Demo(string path)
        {
            Day9 day9_solution = new Day9();
            var response = day9_solution.GetBoostCode(path, 1);
            Assert.AreEqual(1, response.Count);
        }

        //[Test]
        //[TestCase(@"..\..\..\Inputs\day9_1_demo0.txt", ExpectedResult = 1219071000000000)]
        //public decimal FirstStarTests_Demo0(string path)
        //{
        //    Day9 day9_solution = new Day9();
        //    var response = day9_solution.GetBoostCode(path, null).Last();
        //    return Convert.ToDecimal(response);
        //}

        [Test]
        [TestCase(@"..\..\..\Inputs\day9_1_demo1.txt")]
        public void FirstStarTests_Demo1(string path)
        {
            Day9 day9_solution = new Day9();
            var response = day9_solution.GetBoostCode(path, null);
            List<float> expected = new List<float> { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
            for (int i = 0; i < response.Count; i++)
            {
                Assert.AreEqual(expected[i], response[i]);
            }
        }

        [Test]
        [TestCase(@"..\..\..\Inputs\day9_1_demo2.txt", ExpectedResult = 1219071000000000)]
        public decimal FirstStarTests_Demo2(string path)
        {
            Day9 day9_solution = new Day9();
            var response =  day9_solution.GetBoostCode(path, null).Last();
            return Convert.ToDecimal(response);
        }

        [Test]
        [TestCase(@"..\..\..\Inputs\day9_1_demo3.txt", ExpectedResult = 1125899906842624)]
        public float FirstStarTests_Demo3(string path)
        {
            Day9 day9_solution = new Day9();
            return day9_solution.GetBoostCode(path, null).Last();
        }
    }
}
