using AdventOfCode2019.InputReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Day9
    {
        public List<decimal> GetBoostCode(string path, int? input)
        {
            Day7InputReader day2InputReader = new Day7InputReader();
            List<decimal> fileContent = day2InputReader.ReadArray(path, ',').ToList();

            Amplifier amp = new Amplifier();
            amp.Memory = fileContent;
            amp.Input = new List<decimal>();
            if (input.HasValue)
            {
                amp.Input.Add(input.Value);
            }

            amp.Output = new List<decimal>();
            while (!amp.Finished)
            {
                amp.IntCode();
            }

            return amp.Output;
        }
    }
}
