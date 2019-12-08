﻿using AdventOfCode2019.Core;
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
            // // Day 4
            // Day4();

            // // Day 3
            // Day3();
            
            // // Day 8
            // Day8();

            Console.ReadLine();
        }

        private static void Day8()
        {
            Day8 day8_solution = new Day8();
            var reponse = day8_solution.GetMessage(@"Input\day8_1.txt", 25, 6);
        }

        private static void Day3()
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
        }

        private static void Day4()
        {
            int count = 0;
            for (int i = 128392; i <= 643281; i++)
            {
                if (Core.Day4.IsValidPasswordAdvanced(i))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
