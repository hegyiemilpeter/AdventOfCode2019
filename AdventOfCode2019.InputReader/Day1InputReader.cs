using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.InputReader
{
    public class Day1InputReader : InputReader<int>
    {
        public override int[] ParseLine(string line, char? separator = null)
        {
            return new int[] { int.Parse(line) };
        }
    }
}
