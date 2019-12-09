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
        public float RunInlineAmplifiers(string path)
        {
            Day7InputReader day2InputReader = new Day7InputReader();
            List<float> Memory = day2InputReader.ReadArray(path, ',').ToList();

            float maximum = 0;
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

                float output = GetInlineOutput(Memory, phase);
                if (output > maximum)
                {
                    maximum = output;
                }
            }

            return maximum;
        }

        public float RunParalellAmplifiers(string path)
        {
            Day7InputReader day2InputReader = new Day7InputReader();
            List<float> Memory = day2InputReader.ReadArray(path, ',').ToList();

            float maximum = 0;
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

                float output = GetParalellOutput(Memory, phase);
                if (output > maximum)
                {
                    maximum = output;
                }
            }

            return maximum;
        }

        private float GetInlineOutput(List<float> fileContent, int[] phases)
        {
            List<float> signalsA = new List<float>(){ phases[0], 0 };
            List<float> signalsB = new List<float>(){ phases[1] };
            List<float> signalsC = new List<float>(){ phases[2] };
            List<float> signalsD = new List<float>(){ phases[3] };
            List<float> signalsE = new List<float>(){ phases[4] };

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
                    while(!amp.Finished)
                        amp.IntCode();
                }
            }

            a.Input.Last();
            return e.Output.Last();
        }

        private float GetParalellOutput(List<float> fileContent, int[] phases)
        {
            List<float> signalsA = new List<float>() { phases[0], 0 };
            List<float> signalsB = new List<float>() { phases[1] };
            List<float> signalsC = new List<float>() { phases[2] };
            List<float> signalsD = new List<float>() { phases[3] };
            List<float> signalsE = new List<float>() { phases[4] };

            Amplifier a = new Amplifier() { Input = signalsA, Memory = fileContent, Output = signalsB, Name = "A" };
            Amplifier b = new Amplifier() { Input = signalsB, Memory = fileContent, Output = signalsC, Name = "B" };
            Amplifier c = new Amplifier() { Input = signalsC, Memory = fileContent, Output = signalsD, Name = "C" };
            Amplifier d = new Amplifier() { Input = signalsD, Memory = fileContent, Output = signalsE, Name = "D" };
            Amplifier e = new Amplifier() { Input = signalsE, Memory = fileContent, Output = signalsA, Name = "E" };

            List<Amplifier> amps = new List<Amplifier> { a, b, c, d, e };
            while (!e.Finished)
            {
                foreach (var amp in amps)
                {
                    amp.IntCode();
                }
            }

            a.Input.Last();
            return e.Output.Last();
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
