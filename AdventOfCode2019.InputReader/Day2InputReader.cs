using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.InputReader
{
    public class Day2InputReader : InputReader<int>
    {
        public override int[] ParseLine(string line, char? separator = ',')
        {
            int[] response = line.Split(separator.Value).Select(x => int.Parse(x)).ToArray();
            return response;
        }
    }
}
