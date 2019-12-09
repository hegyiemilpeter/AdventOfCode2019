using AdventOfCode2019.InputReader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Core
{
    public class Day7
    {
        public int RunInlineAmplifiers(string path)
        {
            Day2InputReader day2InputReader = new Day2InputReader();
            int[] Memory = day2InputReader.ReadArray(path, ',');

            int maximum = 0;
            int[] phase = new int[5] { 0, 0, 0, 0, 0 };
            for (int i = 0; i <= 44444; i++)
            {
                string number = GetNumberAsString(i);
                if (!NumberContains01234(number))
                {
                    continue;
                }

                for (int j = 0; j < 5; j++)
                {
                    phase[j] = int.Parse(number[j].ToString());
                }

                int output = GetOutputForPhase(Memory, phase);
                if (output > maximum)
                {
                    maximum = output;
                }
            }

            return maximum;
        }

        public int RunParalellAmplifiers(string path)
        {
            Day2InputReader day2InputReader = new Day2InputReader();
            int[] Memory = day2InputReader.ReadArray(path, ',');

            int maximum = 0;
            int[] phase = new int[5] { 0, 0, 0, 0, 0 };
            for (int i = 56789; i <= 98765; i++)
            {
                string number = GetNumberAsString(i);
                if (!NumberContains56789(number))
                {
                    continue;
                }

                for (int j = 0; j < 5; j++)
                {
                    phase[j] = int.Parse(number[j].ToString());
                }

                int output = GetOutputForPhase(Memory, phase);
                if (output > maximum)
                {
                    maximum = output;
                }
            }

            return maximum;
        }

        private int GetOutputForPhase(int[] fileContent, int[] phases)
        {
            List<int> signalsA = new List<int>(){ phases[0], 0 };
            List<int> signalsB = new List<int>(){ phases[1] };
            List<int> signalsC = new List<int>(){ phases[2] };
            List<int> signalsD = new List<int>(){ phases[3] };
            List<int> signalsE = new List<int>(){ phases[4] };

            Amplifier a = new Amplifier() { Input = signalsA, Memory = fileContent, Output = signalsB, Name="A" };
            Amplifier b = new Amplifier() { Input = signalsB, Memory = fileContent, Output = signalsC, Name="B" };
            Amplifier c = new Amplifier() { Input = signalsC, Memory = fileContent, Output = signalsD, Name="C" };
            Amplifier d = new Amplifier() { Input = signalsD, Memory = fileContent, Output = signalsE, Name="D" };
            Amplifier e = new Amplifier() { Input = signalsE, Memory = fileContent, Output = signalsA, Name="E" };

            List<Amplifier> amps = new List<Amplifier> { a, b, c, d, e };
            while (!e.Finished)
            {
                foreach (var amp in amps)
                {
                    amp.IntCode();
                }
            }

            a.Input.First();
            return e.Output.First();
        }

        private bool NumberContains01234(string input)
        {
            return input.All(c => c == '0' || c == '1' || c == '2' || c == '3' || c == '4')
                && input.Count(c => c == '0') == 1
                && input.Count(c => c == '1') == 1
                && input.Count(c => c == '2') == 1
                && input.Count(c => c == '3') == 1
                && input.Count(c => c == '4') == 1;
        }

        private bool NumberContains56789(string input)
        {
            return input.All(c => c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
                && input.Count(c => c == '5') == 1
                && input.Count(c => c == '6') == 1
                && input.Count(c => c == '7') == 1
                && input.Count(c => c == '8') == 1
                && input.Count(c => c == '9') == 1;
        }

        private static string GetNumberAsString(int i)
        {
            var numberAsString = i.ToString();
            while (numberAsString.Length != 5)
            {
                numberAsString = numberAsString.Insert(0, "0");
            }

            return numberAsString;
        }
    }
}
