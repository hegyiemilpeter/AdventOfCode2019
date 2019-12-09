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
        public class Amplifier
        {
            private int[] memory;
            public int[] Memory
            {
                get
                {
                    return memory;
                }
                set
                {
                    memory = new int[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        memory[i] = value[i];
                    }
                }
            }

            public List<int> Input { get; set; }

            public List<int> Output { get; set; }

            public string Name { get; set; }

            public bool Finished { get; set; }

            public int Pointer { get; set; }

            public void IntCode()
            {
                int opcode = Memory[Pointer] % 100;
                int parameterMode1 = (Memory[Pointer] % 1000) / 100;
                int parameterMode2 = (Memory[Pointer] % 10000) / 1000;
                int parameterMode3 = (Memory[Pointer] % 100000) / 10000;
                int parameter1, parameter2, position;
                //Debug.WriteLine($"{Name} is processing {opcode}");
                switch (opcode)
                {
                    case 1:
                        parameter1 = GetParameter(Memory, Pointer + 1, parameterMode1);
                        parameter2 = GetParameter(Memory, Pointer + 2, parameterMode2);
                        int sumOfParameters = parameter1 + parameter2;
                        if (parameterMode3 == 0)
                        {
                            Memory[Memory[Pointer + 3]] = sumOfParameters;
                        }
                        else
                        {
                            Memory[Pointer + 3] = sumOfParameters;
                        }
                        Pointer += 4;
                        break;
                    case 2:
                        parameter1 = GetParameter(Memory, Pointer + 1, parameterMode1);
                        parameter2 = GetParameter(Memory, Pointer + 2, parameterMode2);
                        int multiplyOfParameters = parameter1 * parameter2;
                        if (parameterMode3 == 0)
                        {
                            Memory[Memory[Pointer + 3]] = multiplyOfParameters;
                        }
                        else
                        {
                            Memory[Pointer + 3] = multiplyOfParameters;
                        }
                        Pointer += 4;
                        break;
                    case 3:
                        while(Input.Count == 0)
                        {
                            //Debug.WriteLine($"{Name} is waiting for input");
                            return;
                        }

                        //Debug.WriteLine($"{Name} is taking input");
                        if (parameterMode1 == 0)
                        {
                            Memory[Memory[Pointer + 1]] = Input[0];
                            Input.RemoveAt(0);
                        }
                        else
                        {
                            Memory[Pointer + 1] = Input[0];
                            Input.RemoveAt(0);
                        }
                        Pointer += 2;
                        break;
                    case 4:
                        if (parameterMode1 == 0)
                        {
                            Output.Add(Memory[Memory[Pointer + 1]]);
                        }
                        else
                        {
                            Output.Add(Memory[Pointer + 1]);
                        }
                        //Debug.WriteLine($"{Name} processing output...");
                        Pointer += 2;
                        break;
                    case 5:
                        parameter1 = GetParameter(Memory, Pointer + 1, parameterMode1);
                        if (parameter1 != 0)
                        {
                            Pointer = GetParameter(Memory, Pointer + 2, parameterMode2);
                        }
                        else
                        {
                            Pointer += 3;
                        }
                        break;
                    case 6:
                        parameter1 = GetParameter(Memory, Pointer + 1, parameterMode1);
                        if (parameter1 == 0)
                        {
                            Pointer = GetParameter(Memory, Pointer + 2, parameterMode2);
                        }
                        else
                        {
                            Pointer += 3;
                        }
                        break;
                    case 7:
                        parameter1 = GetParameter(Memory, Pointer + 1, parameterMode1);
                        parameter2 = GetParameter(Memory, Pointer + 2, parameterMode2);
                        position = parameterMode3 == 0 ? Memory[Pointer + 3] : Memory[Memory[Pointer + 3]];
                        if (parameter1 < parameter2)
                        {
                            Memory[position] = 1;
                        }
                        else
                        {
                            Memory[position] = 0;
                        }
                        Pointer += 4;
                        break;
                    case 8:
                        int nextParameter41 = GetParameter(Memory, Pointer + 1, parameterMode1);
                        int nextParameter42 = GetParameter(Memory, Pointer + 2, parameterMode2);
                        position = parameterMode3 == 0 ? Memory[Pointer + 3] : Memory[Memory[Pointer + 3]];
                        if (nextParameter41 == nextParameter42)
                        {
                            Memory[position] = 1;
                        }
                        else
                        {
                            Memory[position] = 0;
                        }
                        Pointer += 4;
                        break;
                    case 99:
                        Finished = true;
                        break;
                    default:
                        throw new Exception();
                }
                
            }
        }

        public async Task<int> GetOutput(string path)
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
                //Debug.WriteLine($"Found: {number} -> {output}");
                if (output > maximum)
                {
                    maximum = output;
                    //Debug.WriteLine($"MAX: {number} -> {output}");
                }
            }
            return maximum;
        }
        public int GetOutputForPhase(string path, int[] phases)
        {
            Day2InputReader day2InputReader = new Day2InputReader();
            int[] Memory = day2InputReader.ReadArray(path, ',');

            return GetOutputForPhase(Memory, phases);
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

        private static void WriteInputToDebug(int[] input)
        {
            StringBuilder sb = new StringBuilder("VALUES: ");
            for (int t = 0; t < input.Length; t++)
            {
                sb.Append(input[t] + " ");
            }

            Debug.WriteLine(sb.ToString());
        }

        private static int GetParameter(int[] input, int i, int mode)
        {
            if (mode == 0)
                return input[input[i]];

            return input[i];
        }
    }
}
