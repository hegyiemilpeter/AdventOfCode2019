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
            List<int> inputs = new List<int>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    inputs.Add(int.Parse(line));
                }
            }

            return inputs.Sum(x => CalculateRequiredFuel(x));
        }

        public int CalculateFullAdvancedAmount(string path)
        {
            List<int> inputs = new List<int>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    inputs.Add(int.Parse(line));
                }
            }

            return inputs.Sum(x => CalculateAdvancedAmount(x));
        }

        public int CalculateAdvancedAmount(int mass)
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
    }
}
