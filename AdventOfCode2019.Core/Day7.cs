using AdventOfCode2019.InputReader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Day7
    {
        List<int> testResult = new List<int>();

        public int GetuOutput(string path, int input)
        {
            Day2InputReader day2InputReader = new Day2InputReader();
            int[] fileContent = day2InputReader.ReadArray(path, ',');

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

                int output = GetOutputForPhase(fileContent, phase);
                Debug.WriteLine($"Found: {number} -> {output}");
                if (output > maximum)
                {
                    maximum = output;
                    Debug.WriteLine($"MAX: {number} -> {output}");
                }
            }
            return maximum;
        }
        public int GetOutputForPhase(string path, int[] phases)
        {
            Day2InputReader day2InputReader = new Day2InputReader();
            int[] fileContent = day2InputReader.ReadArray(path, ',');

            return GetOutputForPhase(fileContent, phases);
        }
        private int GetOutputForPhase(int[] fileContent, int[] phases)
        {
            var amplifierA = IntCode(fileContent, new int[] { phases[0], 0 });
            var amplifierB = IntCode(fileContent, new int[] { phases[1], amplifierA });
            var amplifierC = IntCode(fileContent, new int[] { phases[2], amplifierB });
            var amplifierD = IntCode(fileContent, new int[] { phases[3], amplifierC });
            var amplifierE = IntCode(fileContent, new int[] { phases[4], amplifierD });
            return amplifierE;
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

        private static string GetNumberAsString(int i)
        {
            var numberAsString = i.ToString();
            while (numberAsString.Length != 5)
            {
                numberAsString = numberAsString.Insert(0, "0");
            }

            return numberAsString;
        }

        private int IntCode(int[] input, int[] parameters)
        {
            int i = 0;
            int j = 0;
            while (i < input.Length)
            {
                int opcode = input[i] % 100;
                int parameterMode1 = (input[i] % 1000) / 100;
                int parameterMode2 = (input[i] % 10000) / 1000;
                int parameterMode3 = (input[i] % 100000) / 10000;
                int parameter1, parameter2, position;
                switch (opcode)
                {
                    case 1:
                        parameter1 = GetParameter(input, i + 1, parameterMode1);
                        parameter2 = GetParameter(input, i + 2, parameterMode2);
                        int sumOfParameters = parameter1 + parameter2;
                        if (parameterMode3 == 0)
                        {
                            input[input[i + 3]] = sumOfParameters;
                        }
                        else
                        {
                            input[i + 3] = sumOfParameters;
                        }
                        i += 4;
                        break;
                    case 2:
                        parameter1 = GetParameter(input, i + 1, parameterMode1);
                        parameter2 = GetParameter(input, i + 2, parameterMode2);
                        int multiplyOfParameters = parameter1 * parameter2;
                        if (parameterMode3 == 0)
                        {
                            input[input[i + 3]] = multiplyOfParameters;
                        }
                        else
                        {
                            input[i + 3] = multiplyOfParameters;
                        }
                        i += 4;
                        break;
                    case 3:
                        if (parameterMode1 == 0)
                        {
                            input[input[i + 1]] = parameters[j];
                        }
                        else
                        {
                            input[i + 1] = parameters[j];
                        }
                        i += 2;
                        j++;
                        break;
                    case 4:
                        if (parameterMode1 == 0)
                        {
                            testResult.Add(input[input[i + 1]]);
                        }
                        else
                        {
                            testResult.Add(input[i + 1]);
                        }
                        i += 2;
                        break;
                    case 5:
                        parameter1 = GetParameter(input, i + 1, parameterMode1);
                        if (parameter1 != 0)
                        {
                            i = GetParameter(input, i + 2, parameterMode2);
                        }
                        else
                        {
                            i += 3;
                        }
                        break;
                    case 6:
                        parameter1 = GetParameter(input, i + 1, parameterMode1);
                        if (parameter1 == 0)
                        {
                            i = GetParameter(input, i + 2, parameterMode2);
                        }
                        else
                        {
                            i += 3;
                        }
                        break;
                    case 7:
                        parameter1 = GetParameter(input, i + 1, parameterMode1);
                        parameter2 = GetParameter(input, i + 2, parameterMode2);
                        position = parameterMode3 == 0 ? input[i + 3] : input[input[i + 3]];
                        if (parameter1 < parameter2)
                        {
                            input[position] = 1;
                        }
                        else
                        {
                            input[position] = 0;
                        }
                        i += 4;
                        break;
                    case 8:
                        int nextParameter41 = GetParameter(input, i + 1, parameterMode1);
                        int nextParameter42 = GetParameter(input, i + 2, parameterMode2);
                        position = parameterMode3 == 0 ? input[i + 3] : input[input[i + 3]];
                        if (nextParameter41 == nextParameter42)
                        {
                            input[position] = 1;
                        }
                        else
                        {
                            input[position] = 0;
                        }
                        i += 4;
                        break;
                    case 99:
                        int response = testResult.Last();
                        testResult[testResult.Count - 1] = 0;
                        if (!testResult.All(x => x == 0))
                        {
                            throw new Exception();
                        }

                        return response;
                    default:
                        throw new Exception();
                }
            }

            throw new Exception();
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
