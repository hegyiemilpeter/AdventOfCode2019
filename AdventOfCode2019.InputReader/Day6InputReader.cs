using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.InputReader
{
    public class Day6InputReader : InputReader<string>
    {
        public override string[] ParseLine(string line, char? separator = null)
        {
            return new string[] { line };
        }
    }
}
