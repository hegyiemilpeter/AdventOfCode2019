using AdventOfCode2019.InputReader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Day5
    {
        List<int> testResult = new List<int>();

        public int GetuOutput(string path, int input)
        {
            Day2InputReader day2InputReader = new Day2InputReader();
            int[] fileContent = day2InputReader.ReadArray(path, ',');
            return IntCode(fileContent, input);
        }

        private int IntCode(int[] input, int parameter)
        {
            int i = 0;
            while(i < input.Length)
            {
                WriteInputToDebug(input);

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
                            input[input[i + 1]] = parameter;
                        }
                        else
                        {
                            input[i + 1] = parameter;
                        }
                        i += 2;
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
            if(mode==0)
             return input[input[i]];

            return input[i];
        }
    }
}
