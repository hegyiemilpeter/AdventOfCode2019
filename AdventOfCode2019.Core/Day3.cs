using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Day3
    {
        public int GetNearestCrossingPoint(string cable1, string cable2)
        {
            Console.WriteLine("Reading cables...");
            var cable1_Positions = GetCablePositions(cable1);
            var cable2_Positions = GetCablePositions(cable2);

            Console.WriteLine("Get crossing points");
            List<Tuple<int, int>> minimumPosition = GetCrossingPoints(cable1_Positions, cable2);
            Console.WriteLine("Finding minimum positions...");
            var response = minimumPosition.Min(x => Math.Abs(x.Item2) + Math.Abs(x.Item1));

            return response;
        }

        public List<Tuple<int,int>> GetCrossingPoints(List<Tuple<int,int>> cable1, string cable2)
        {
            List<Tuple<int, int>> c2 = new List<Tuple<int, int>>();
            int x = 0, y = 0;

            string[] splittedCable = cable2.Split(',');
            for (int i = 0; i < splittedCable.Length; i++)
            {
                Console.WriteLine($"{i} / {splittedCable.Length}");
                int value = int.Parse(splittedCable[i].Remove(0, 1));
                switch (splittedCable[i][0])
                {
                    case 'R':
                        var goodPoints = cable1.Where(p => p.Item2 == y);

                        for (int j = 0; j < value; j++)
                        {
                            x++;
                            if(goodPoints.Any(p => p.Item1 == x && p.Item2 == y))
                            {
                                c2.Add(new Tuple<int, int>(x, y));
                            }
                        }
                        break;
                    case 'U':
                        var goodPoints2 = cable1.Where(p => p.Item1 == x);

                        for (int j = 0; j < value; j++)
                        {
                            y++;
                            if (goodPoints2.Any(p => p.Item1 == x && p.Item2 == y))
                            {
                                c2.Add(new Tuple<int, int>(x, y));
                            }
                        }
                        break;
                    case 'L':
                        var goodPoints3 = cable1.Where(p => p.Item2 == y);

                        for (int j = 0; j < value; j++)
                        {
                            x--;
                            if (goodPoints3.Any(p => p.Item1 == x && p.Item2 == y))
                            {
                                c2.Add(new Tuple<int, int>(x, y));
                            }
                        }
                        break;
                    case 'D':
                        var goodPoints4 = cable1.Where(p => p.Item1 == x);
                        for (int j = 0; j < value; j++)
                        {
                            y--;
                            if (goodPoints4.Any(p => p.Item1 == x && p.Item2 == y))
                            {
                                c2.Add(new Tuple<int, int>(x, y));
                            }
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }

            return c2;

        }

        public List<Tuple<int,int>> GetCablePositions(string cable)
        {
            List<Tuple<int, int>> cable1 = new List<Tuple<int, int>>();
            int x = 0, y = 0;

            string[] splittedCable = cable.Split(',');
            for (int i = 0; i < splittedCable.Length; i++)
            {
                int value = int.Parse(splittedCable[i].Remove(0, 1));
                switch (splittedCable[i][0])
                {
                    case 'R':
                        for (int j = 0; j < value; j++)
                        {
                            x++;
                            cable1.Add(new Tuple<int, int>(x, y));
                        }
                        break;
                    case 'U':
                        for (int j = 0; j < value; j++)
                        {
                            y++;
                            cable1.Add(new Tuple<int, int>(x, y));
                        }
                        break;
                    case 'L':
                        for (int j = 0; j < value; j++)
                        {
                            x--;
                            cable1.Add(new Tuple<int, int>(x, y));
                        }
                        break;
                    case 'D':
                        for (int j = 0; j < value; j++)
                        {
                            y--;
                            cable1.Add(new Tuple<int, int>(x, y));
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }

            return cable1;
        }
    }
}
