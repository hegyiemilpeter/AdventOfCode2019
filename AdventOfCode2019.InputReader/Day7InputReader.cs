using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.InputReader
{
    public class Day7InputReader : InputReader<float>
    {
        public override float[] ParseLine(string line, char? separator = ',')
        {
            float[] response = line.Split(separator.Value).Select(x => float.Parse(x)).ToArray();
            return response;
        }
    }
}
