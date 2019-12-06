using AdventOfCode2019.InputReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Orbit
    {
        public string Id { get; set; }
        public string Parent { get; set; }
    }

    public class Day6
    {
        public int NumberOfOrbits(string path)
        {
            List<Orbit> orbits = ListOrbits(path);

            int fullCount = 0;
            foreach (var orbit in orbits)
            {
                Orbit temp = orbit;
                int count = 0;
                while (temp.Parent != null)
                {
                    count++;
                    temp = orbits.SingleOrDefault(x => x.Id == temp.Parent);
                }

                fullCount += count;
            }

            return fullCount;
        }
        
        public int NumberOfTransfers(string path)
        {
            List<Orbit> orbits = ListOrbits(path);

            Orbit santaTemp = orbits.Single(x => x.Id == "SAN");
            List<Orbit> santaToRoot = new List<Orbit>();
            while (santaTemp.Parent != null)
            {
                santaToRoot.Add(santaTemp);
                santaTemp = orbits.SingleOrDefault(x => x.Id == santaTemp.Parent);
            }

            int fullCount = 0;
            Orbit meTemp = orbits.SingleOrDefault(x => x.Id == "YOU");
            while (!santaToRoot.Any(x => x.Id == meTemp.Id))
            {
                fullCount++;
                meTemp = orbits.Single(x => x.Id == meTemp.Parent);
            }

            while (meTemp.Id != "SAN")
            {
                meTemp = santaToRoot.Single(y => y.Parent == meTemp.Id);
                fullCount++;
            }

            return fullCount - 2;
        }
        private static List<Orbit> ListOrbits(string path)
        {
            Day6InputReader ir = new Day6InputReader();
            string[] input = ir.ReadArray(path, ' ');

            List<Orbit> orbits = new List<Orbit>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] item = input[i].Split(')');

                var parent = orbits.SingleOrDefault(x => x.Id == item[0]);
                if (parent == null)
                {
                    parent = new Orbit() { Id = item[0] };
                    orbits.Add(parent);
                }

                var child = orbits.SingleOrDefault(x => x.Id == item[1]);
                if (child != null)
                {
                    if (child.Parent != null)
                    {
                        throw new Exception();
                    }

                    orbits.Remove(child);
                }

                child = new Orbit() { Id = item[1], Parent = parent.Id };
                orbits.Add(child);
            }

            return orbits;
        }
    }
}
