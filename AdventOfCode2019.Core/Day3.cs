using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Day3
    {
        public int FirstStar(string c1, string c2)
        {
            var c1Points = GetCablePositions(c1);
            var crossingPoints = GetCrossingPoints(c1Points, c2);
            return GetNearestCrossingPoint(crossingPoints);
        }

        public int SecondStar(string c1, string c2)
        {
            var c1Points = GetCablePositions(c1);
            var c2Points = GetCablePositions(c2);
            var crossingPoints = GetCrossingPoints(c1Points, c2);

            int minimum = 1000000;
            foreach (var cp in crossingPoints)
            {
                int c1Step = GetSteps(c1Points, cp);
                int c2Step = GetSteps(c2Points, cp);
                if (minimum > c1Step + c2Step)
                {
                    minimum = c1Step + c2Step;
                }
            }

            return minimum;
        }

        public int GetNearestCrossingPoint(List<Tuple<int,int>> crossingPoints)
        {
            int minimumPositions = crossingPoints.Min(x => Math.Abs(x.Item2) + Math.Abs(x.Item1));
            return minimumPositions;
        }

        public List<Tuple<int,int>> GetCrossingPoints(List<Tuple<int,int>> cable1, string cable2)
        {
            List<Tuple<int, int>> crossingPoints = new List<Tuple<int, int>>();
            int x = 0, y = 0;

            string[] splittedCable = cable2.Split(',');
            for (int i = 0; i < splittedCable.Length; i++)
            {
                Console.WriteLine($"{i} / {splittedCable.Length}");
                int value = int.Parse(splittedCable[i].Remove(0, 1));
                switch (splittedCable[i][0])
                {
                    case 'R':
                        for (int j = 0; j < value; j++)
                        {
                            x++;
                            if(IsCrossingPoint(x,y,cable1))
                            {
                                crossingPoints.Add(new Tuple<int, int>(x, y));
                            }
                        }
                        break;
                    case 'U':
                        for (int j = 0; j < value; j++)
                        {
                            y++;
                            if (IsCrossingPoint(x, y, cable1))
                            {
                                crossingPoints.Add(new Tuple<int, int>(x, y));
                            }
                        }
                        break;
                    case 'L':
                        for (int j = 0; j < value; j++)
                        {
                            x--;
                            if (IsCrossingPoint(x, y, cable1))
                            {
                                crossingPoints.Add(new Tuple<int, int>(x, y));
                            }
                        }
                        break;
                    case 'D':
                        for (int j = 0; j < value; j++)
                        {
                            y--;
                            if (IsCrossingPoint(x, y, cable1))
                            {
                                crossingPoints.Add(new Tuple<int, int>(x, y));
                            }
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }

            return crossingPoints;
        }

        private static bool IsCrossingPoint(int x, int y, List<Tuple<int,int>> otherCable)
        {
            return otherCable.Any(c => c.Item1 == x && c.Item2 == y);
        }

        public List<Tuple<int,int>> GetCablePositions(string cable)
        {
            List<Tuple<int, int>> response = new List<Tuple<int, int>>();
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
                            response.Add(new Tuple<int, int>(x, y));
                        }
                        break;
                    case 'U':
                        for (int j = 0; j < value; j++)
                        {
                            y++;
                            response.Add(new Tuple<int, int>(x, y));
                        }
                        break;
                    case 'L':
                        for (int j = 0; j < value; j++)
                        {
                            x--;
                            response.Add(new Tuple<int, int>(x, y));
                        }
                        break;
                    case 'D':
                        for (int j = 0; j < value; j++)
                        {
                            y--;
                            response.Add(new Tuple<int, int>(x, y));
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }

            return response;
        }

        private int GetSteps(List<Tuple<int, int>> c1, Tuple<int, int> cp)
        {
            int i = 0;
            Tuple<int, int> actualPoint = new Tuple<int, int>(0, 0);
            while (actualPoint.Item1 != cp.Item1 || actualPoint.Item2 != cp.Item2)
            {
                actualPoint = c1[i];
                i++;
            }

            return i;
        }
    }
}
