using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.InputReader
{
    public class Day7InputReader : InputReader<decimal>
    {
        public override decimal[] ParseLine(string line, char? separator = ',')
        {
            decimal[] response = line.Split(separator.Value).Select(x => decimal.Parse(x)).ToArray();
            return response;
        }
    }
}
