using AdventOfCode2019.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Tests
{
    public class Day3Tests
    {
        Day3 day3_solution = new Day3();

        [Test]
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", ExpectedResult = 6)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", ExpectedResult = 159)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", ExpectedResult = 135)]
        public int FirstStar_DemoCases(string c1, string c2)
        {
            return day3_solution.FirstStar(c1, c2);
        }

        [Test]
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", ExpectedResult = 30)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", ExpectedResult = 610)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", ExpectedResult = 410)]
        public int SecondStarTest(string c1, string c2)
        {
            return day3_solution.SecondStar(c1, c2);
        }
    }
}
