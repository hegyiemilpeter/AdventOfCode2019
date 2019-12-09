using System;
using System.Collections.Generic;

namespace test
{
    class Intcode
    {
        public List<int> inputQueue = new List<int>();
        public int output = 0;

        public Intcode outputDest = null;

        public int[] memory;
        public int ip = 0;

        public bool waiting = false;
        public bool halted = false;
        public bool sentOutput = false;

        public int id = 0;
        public static int nextID = 0;

        public Intcode()
        {
            id = nextID;
            nextID++;
        }

        public override string ToString()
        {
            return ("Intcode" + id);
        }

        public void SendInput(int input)
        {
            inputQueue.Add(input);
            if (waiting)
            {
            }
            waiting = false;
        }

        public void Output(int i)
        {
            output = i;
            if (outputDest != null)
            {
                outputDest.SendInput(i);
            }
            sentOutput = true;
        }

        public int GetAddress(int idx)
        {
            return memory[ip + idx];
        }

        public int GetValue(int idx)
        {
            int param = memory[ip + idx];

            int mode = memory[ip] / 100;
            for (int i = 1; i < idx; i++)
                mode = mode / 10;
            mode = mode % 10;

            switch (mode)
            {
                case 0: // position mode
                    return memory[param];
                case 1: // immediate mode
                    return param;
                default:
                    throw new System.Exception("Invalid Intcode parameter mode: " + mode);
            }

        }

        public void Step()
        {
            int opcode = memory[ip] % 100;
            switch (opcode)
            {
                case 1: // add
                    memory[GetAddress(3)] = GetValue(1) + GetValue(2);
                    ip += 4;
                    break;
                case 2: // multiply
                    memory[GetAddress(3)] = GetValue(1) * GetValue(2);
                    ip += 4;
                    break;
                case 3: // input
                    if (inputQueue.Count > 0)
                    {
                        memory[GetAddress(1)] = inputQueue[0];
                        inputQueue.RemoveAt(0);
                        ip += 2;
                    }
                    else
                    {
                        waiting = true;
                    }
                    break;
                case 4: // output
                    Output(GetValue(1));
                    ip += 2;
                    break;
                case 5: // jump-if-true
                    if (GetValue(1) == 0)
                        ip += 3;
                    else
                        ip = GetValue(2);
                    break;
                case 6: // jump-if-false
                    if (GetValue(1) == 0)
                        ip = GetValue(2);
                    else
                        ip += 3;
                    break;
                case 7: // less-than
                    if (GetValue(1) < GetValue(2))
                        memory[GetAddress(3)] = 1;
                    else
                        memory[GetAddress(3)] = 0;
                    ip += 4;
                    break;
                case 8: // equals
                    if (GetValue(1) == GetValue(2))
                        memory[GetAddress(3)] = 1;
                    else
                        memory[GetAddress(3)] = 0;
                    ip += 4;
                    break;
                case 99:
                    halted = true;
                    break;
                default:
                    throw new System.Exception("Unknown Intcode opcode " + opcode + " at position " + ip);
            }

        }

        public void RunToOutput()
        {
            sentOutput = false;
            while (!halted && !waiting && !sentOutput)
                Step();
        }

        public void Run()
        {
            while (!halted && !waiting)
                Step();
        }

        public void SetMemory(List<int> input)
        {
            memory = input.ToArray();
        }

        public void SetParams(int noun, int verb)
        {
            memory[1] = noun;
            memory[2] = verb;
        }
    }


    class MainClass
    {

        public static IEnumerable<List<int>> Permutations(List<int> elements)
        {
            if (elements.Count == 1)
                yield return elements;
            else
            {
                int head = elements[0];
                elements.RemoveAt(0);
                foreach (List<int> sublist in Permutations(elements))
                {
                    for (int i = 0; i <= sublist.Count; i++)
                    {
                        sublist.Insert(i, head);
                        yield return sublist;
                        sublist.RemoveAt(i);
                    }
                }
            }
            yield break;
        }

        public static void pipe(Intcode a, Intcode b)
        {
            a.outputDest = b;
        }

        public static int linearRun(List<int> memory, List<int> phases)
        {
            List<Intcode> nodes = new List<Intcode>();
            foreach (int phase in phases)
            {
                Intcode m = new Intcode();
                m.SetMemory(memory);
                m.SendInput(phase);
                if (nodes.Count > 0)
                    pipe(nodes[nodes.Count - 1], m);
                nodes.Add(m);
            }
            nodes[0].SendInput(0);

            foreach (Intcode m in nodes)
            {
                m.RunToOutput();
            }

            Intcode tail = nodes[nodes.Count - 1];
            return tail.output;
        }

        public static int circularRun(List<int> memory, List<int> phases)
        {
            List<Intcode> nodes = new List<Intcode>();
            foreach (int phase in phases)
            {
                Intcode m = new Intcode();
                m.SetMemory(memory);
                m.SendInput(phase);
                if (nodes.Count > 0)
                    pipe(nodes[nodes.Count - 1], m);
                nodes.Add(m);
            }
            pipe(nodes[nodes.Count - 1], nodes[0]);
            nodes[0].SendInput(0);

            Intcode tail = nodes[nodes.Count - 1];
            while (!tail.halted)
            {
                foreach (Intcode m in nodes)
                    m.Run();
            }
            return tail.output;
        }

        public static void Main(string[] args)
        {
            List<int> input = new List<int>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                foreach (string token in line.Split(','))
                {
                    input.Add(Int32.Parse(token));
                }
            }

            int maxout = 0;

            List<int> phases = new List<int> { 0, 1, 2, 3, 4 };
            foreach (List<int> p in Permutations(phases))
            {
                int signal = linearRun(input, p);
                if (signal > maxout) maxout = signal;
            }

            Console.WriteLine(maxout);

            phases = new List<int> { 5, 6, 7, 8, 9 };
            maxout = 0;
            foreach (List<int> p in Permutations(phases))
            {
                int signal = circularRun(input, p);
                if (signal > maxout) maxout = signal;
            }

            Console.WriteLine(maxout);
        }

    }
}

