using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Day2
    {
        public int GetPairForResult(string path, int expectedResult)
        {
            InputReader.Day2InputReader inputReader = new InputReader.Day2InputReader();
            int[] originalInput = inputReader.ReadArray(path, ',');

            int[] input = CloneOriginalInput(originalInput);

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    input = CloneOriginalInput(originalInput);
                    input[1] = i;
                    input[2] = j;

                    int result = CalculatePositionAtZero(input);
                    if (result == expectedResult)
                    {
                        return 100 * i + j;
                    }

                    if (i != j)
                    {
                        input = CloneOriginalInput(originalInput);
                        input[1] = j;
                        input[2] = i;
                        result = CalculatePositionAtZero(input);
                        if (result == expectedResult)
                        {
                            return 100 * j + i;
                        }
                    }
                }
            }

            return 0;
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

        public int GetPositionAtZero(string path, bool release)
        {
            InputReader.Day2InputReader inputReader = new InputReader.Day2InputReader();
            int[] input = inputReader.ReadArray(path, ',');

            if (release)
            {
                input[1] = 12;
                input[2] = 2;
            }

            return CalculatePositionAtZero(input);
        }

        private static int CalculatePositionAtZero(int[] input)
        {
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
    }
}
