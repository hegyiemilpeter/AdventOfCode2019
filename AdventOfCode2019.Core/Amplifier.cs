using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Amplifier
    {
        private List<decimal> memory;
        public List<decimal> Memory
        {
            get
            {
                return memory;
            }
            set
            {
                memory = new List<decimal>();
                for (int i = 0; i < value.Count; i++)
                {
                    memory.Add(value[i]);
                }
            }
        }

        public List<decimal> Input { get; set; }

        public List<decimal> Output { get; set; }

        public string Name { get; set; }

        public bool Finished { get; set; }

        public int Pointer { get; set; }

        public decimal RelativeBase { get; set; }

        public void IntCode()
        {
            int opcode = (int)Memory[Pointer] % 100;
            int parameterMode1 = (int)(Memory[Pointer] % 1000) / 100;
            int parameterMode2 = (int)(Memory[Pointer] % 10000) / 1000;
            int parameterMode3 = (int)(Memory[Pointer] % 100000) / 10000;
            decimal parameter1, parameter2;
            switch (opcode)
            {
                case 1:
                    parameter1 = GetValue(Pointer + 1, parameterMode1);
                    parameter2 = GetValue(Pointer + 2, parameterMode2);
                    Memory[GetPosition(Pointer + 3, parameterMode3)] = parameter1 + parameter2;
                    Pointer += 4;
                    break;
                case 2:
                    parameter1 = GetValue(Pointer + 1, parameterMode1);
                    parameter2 = GetValue(Pointer + 2, parameterMode2);
                    Memory[GetPosition(Pointer + 3, parameterMode3)] = parameter1 * parameter2;
                    Pointer += 4;
                    break;
                case 3:
                    while (Input.Count == 0)
                    {
                        return;
                    }
                    Memory[GetPosition(Pointer + 1, parameterMode1)] = Input[0];
                    Input.RemoveAt(0);
                    Pointer += 2;
                    break;
                case 4:
                    Output.Add(Memory[GetPosition(Pointer + 1, parameterMode1)]);
                    Pointer += 2;
                    break;
                case 5:
                    parameter1 = GetValue(Pointer + 1, parameterMode1);
                    if (parameter1 != 0)
                    {
                        Pointer = (int)GetValue(Pointer + 2, parameterMode2); ;
                    }
                    else
                    {
                        Pointer += 3;
                    }
                    break;
                case 6:
                    parameter1 = GetValue(Pointer + 1, parameterMode1);
                    if (parameter1 == 0)
                    {
                        Pointer = (int)GetValue(Pointer + 2, parameterMode2); ;
                    }
                    else
                    {
                        Pointer += 3;
                    }
                    break;
                case 7:
                    parameter1 = GetValue(Pointer + 1, parameterMode1);
                    parameter2 = GetValue(Pointer + 2, parameterMode2);
                    
                    if (parameter1 < parameter2)
                    {
                        Memory[GetPosition(Pointer + 3, parameterMode3)] = 1;
                    }
                    else
                    {
                        Memory[GetPosition(Pointer + 3, parameterMode3)] = 0;
                    }
                    Pointer += 4;
                    break;
                case 8:
                    parameter1 = GetValue(Pointer + 1, parameterMode1);
                    parameter2 = GetValue(Pointer + 2, parameterMode2);
                    
                    if (parameter1 == parameter2)
                    {
                        Memory[GetPosition(Pointer + 3, parameterMode3)] = 1;
                    }
                    else
                    {
                        Memory[GetPosition(Pointer + 3, parameterMode3)] = 0;
                    }
                    Pointer += 4;
                    break;
                case 9:
                    parameter1 = GetValue(Pointer + 1, parameterMode1);
                    RelativeBase += parameter1;
                    Pointer += 2;
                    break;
                case 99:
                    Finished = true;
                    break;
                default:
                    throw new Exception();
            }
        }

        private decimal GetValue(int i, int mode)
        {
            decimal response;
            if (mode == 0) // position mode
            {
                if (Memory[i] >= Memory.Count)
                {
                    ExtendMemory((int)Memory[i]);
                }

                response = Memory[(int)Memory[i]];
            }
            else if (mode == 1) // immediate mode
            {
                if (i >= Memory.Count)
                {
                    ExtendMemory(i);
                }

                response = Memory[i];
            }
            else // relative mode
            {
                if (Memory[i] >= Memory.Count)
                {
                    ExtendMemory((int)Memory[i]);
                }

                response =  Memory[(int)(RelativeBase + Memory[i])];
            }
            return response;
        }

        private  int GetPosition(int i, int mode)
        {
            int response;
            if (mode == 0) // position mode
                response = (int)Memory[i];
            else if (mode == 1) // immediate mode
                response = i;
            else // relative mode
                response = (int)(RelativeBase + Memory[i]);

            if (response >= Memory.Count)
            {
                ExtendMemory(response);
            }

            return response; 
        }

        private void ExtendMemory(int goal)
        {
            for (int k = Memory.Count + 1; k <= goal + 1; k++)
            {
                Memory.Add(0);
            }
        }
    }
}
