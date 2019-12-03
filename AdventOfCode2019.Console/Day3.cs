using AdventOfCode2019.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            string cable1, cable2;
            using (StreamReader reader = new StreamReader(@"Input\day3_1.txt"))
            {
                cable1 = reader.ReadLine();
                cable2 = reader.ReadLine();
            }

            Core.Day3 day3_solution = new Core.Day3();
            int closestIntersectionDistance = day3_solution.ManhattanDistanceOfClosestIntersection(cable1, cable2);
            Console.WriteLine($"Manhattan distance of closest intersection: {closestIntersectionDistance}");
            int fewestCombinedSteps = day3_solution.FewestCombinedSteps(cable1, cable2);
            Console.WriteLine($"Fewest combined steps: {fewestCombinedSteps}");

            Console.ReadLine();
        }
    }
}
