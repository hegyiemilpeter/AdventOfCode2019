using AdventOfCode2019.InputReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Core
{
    public class Day1
    {
        public int CalculateFullAmount(string path)
        {
            List<int> inputs = ReadInput(path);
            return inputs.Sum(x => CalculateRequiredFuel(x));
        }

        public int CalculateAdvancedFullAmount(string path)
        {
            List<int> inputs = ReadInput(path);
            return inputs.Sum(x => CalculateAdvancedRequiredFuel(x));
        }

        public int CalculateAdvancedRequiredFuel(int mass)
        {
            int actualRequirement = CalculateRequiredFuel(mass);
            int fullRequirement = 0;
            while (actualRequirement > 0)
            {
                fullRequirement += actualRequirement;
                actualRequirement = CalculateRequiredFuel(actualRequirement);
            }

            return fullRequirement;
        }

        public int CalculateRequiredFuel(int mass)
        {
            return (int)(mass / 3) - 2;
        }

        private static List<int> ReadInput(string path)
        {
            Day1InputReader inputReader = new Day1InputReader();
            return inputReader.ReadArray(path, ' ').ToList();
        }
    }
}
