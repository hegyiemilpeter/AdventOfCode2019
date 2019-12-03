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

            Day3 day3_solution = new Day3();
            int min = day3_solution.SecondStar(cable1, cable2);

            Console.WriteLine("Hello World!");
        }
    }
}
