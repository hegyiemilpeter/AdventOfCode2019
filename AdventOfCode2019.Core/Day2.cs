using AdventOfCode2019.InputReader;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Core
{
    // https://adventofcode.com/2019/day/2
    public class Day2
    {
        public int GetNounVerbCombination(string path, int expectedResult)
        {
            Day2InputReader inputReader = new Day2InputReader();
            int[] originalInput = inputReader.ReadArray(path, ',');
            int[] input = new int[originalInput.Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    input = CloneOriginalInput(originalInput);
                    int result = CalculatePositionAtZero(input, i, j);
                    if (result == expectedResult)
                    {
                        return 100 * i + j;
                    }

                    if (i != j)
                    {
                        input = CloneOriginalInput(originalInput);
                        result = CalculatePositionAtZero(input, j, i);
                        if (result == expectedResult)
                        {
                            return 100 * j + i;
                        }
                    }
                }
            }

            return 0;
        }

        public int GetPositionAtZero(string path, int? overwrite1, int? overwrite2)
        {
            Day2InputReader inputReader = new Day2InputReader();
            int[] input = inputReader.ReadArray(path, ',');

            return CalculatePositionAtZero(input, overwrite1, overwrite2);
        }

        private static int CalculatePositionAtZero(int[] input, int? overwrite1, int? overwrite2)
        {
            if(overwrite1.HasValue && overwrite2.HasValue)
            {
                input[1] = overwrite1.Value;
                input[2] = overwrite2.Value;
            }

            for (int i = 0; i < input.Length; i += 4)
            {
                switch (input[i])
                {
                    case 1:
                        input[input[i + 3]] = input[input[i + 1]] + input[input[i + 2]];
                        break;
                    case 2:
                        input[input[i + 3]] = input[input[i + 1]] * input[input[i + 2]];
                        break;
                    case 99:
                        return input[0];
                    default:
                        throw new Exception();
                }
            }

            throw new Exception();
        }

        private static int[] CloneOriginalInput(int[] originalInput)
        {
            int[] input = new int[originalInput.Length];
            for (int i = 0; i < originalInput.Length; i++)
            {
                input[i] = originalInput[i];
            }

            return input;
        }
    }
}
