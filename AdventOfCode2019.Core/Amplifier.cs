using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Core
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
            switch (opcode)
            {
                case 1:
                    parameter1 = GetValue(Memory, Pointer + 1, parameterMode1);
                    parameter2 = GetValue(Memory, Pointer + 2, parameterMode2);
                    Memory[GetPosition(Memory, Pointer + 3, parameterMode3)] = parameter1 + parameter2;
                    Pointer += 4;
                    break;
                case 2:
                    parameter1 = GetValue(Memory, Pointer + 1, parameterMode1);
                    parameter2 = GetValue(Memory, Pointer + 2, parameterMode2);
                    Memory[GetPosition(Memory, Pointer + 3, parameterMode3)] = parameter1 * parameter2;
                    Pointer += 4;
                    break;
                case 3:
                    while (Input.Count == 0)
                    {
                        return;
                    }

                    Memory[GetPosition(Memory, Pointer + 1, parameterMode1)] = Input[0];
                    Input.RemoveAt(0);
                    
                    Pointer += 2;
                    break;
                case 4:
                    Output.Add(Memory[GetPosition(Memory, Pointer + 1, parameterMode1)]);
                    Pointer += 2;
                    break;
                case 5:
                    parameter1 = GetValue(Memory, Pointer + 1, parameterMode1);
                    if (parameter1 != 0)
                    {
                        Pointer = GetValue(Memory, Pointer + 2, parameterMode2);
                    }
                    else
                    {
                        Pointer += 3;
                    }
                    break;
                case 6:
                    parameter1 = GetValue(Memory, Pointer + 1, parameterMode1);
                    if (parameter1 == 0)
                    {
                        Pointer = GetValue(Memory, Pointer + 2, parameterMode2);
                    }
                    else
                    {
                        Pointer += 3;
                    }
                    break;
                case 7:
                    parameter1 = GetValue(Memory, Pointer + 1, parameterMode1);
                    parameter2 = GetValue(Memory, Pointer + 2, parameterMode2);
                    position = GetPosition(Memory, Pointer + 3, parameterMode3);
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
                    int nextParameter41 = GetValue(Memory, Pointer + 1, parameterMode1);
                    int nextParameter42 = GetValue(Memory, Pointer + 2, parameterMode2);
                    position = GetPosition(Memory, Pointer + 3, parameterMode3);
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

        private static int GetValue(int[] input, int i, int mode)
        {
            if (mode == 0)
                return input[input[i]];

            return input[i];
        }

        private static int GetPosition(int[] input, int i, int mode)
        {
            if (mode == 0)
                return input[i];

            return i;
        }
    }
}
