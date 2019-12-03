using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Day3
    {
        public List<Tuple<int,int>> Cable1Points { get; set; }
        public List<Tuple<int,int>> Cable2Points { get; set; }
        public List<Tuple<int,int>> CrossingPoints { get; set; }

        public int ManhattanDistanceOfClosestIntersection(string cable1, string cable2)
        {
            Cable1Points = GetCablePositions(cable1);
            CrossingPoints = GetCrossingPoints(Cable1Points, cable2);
            return DistanceOfClosestIntersection(CrossingPoints);
        }

        public int FewestCombinedSteps(string cable1, string cable2)
        {
            if (Cable1Points == null)
                Cable1Points = GetCablePositions(cable1);
            if(Cable2Points == null)
                Cable2Points = GetCablePositions(cable2);
            if(CrossingPoints == null)
                CrossingPoints = GetCrossingPoints(Cable1Points, cable2);


            int minimum = int.MaxValue;
            foreach (var crossingPoint in CrossingPoints)
            {
                int c1Step = GetCombinedStep(Cable1Points, crossingPoint);
                int c2Step = GetCombinedStep(Cable2Points, crossingPoint);
                if (minimum > c1Step + c2Step)
                {
                    minimum = c1Step + c2Step;
                }
            }

            return minimum;
        }

        private int DistanceOfClosestIntersection(List<Tuple<int,int>> crossingPoints)
        {
            int minimumPositions = crossingPoints.Min(x => Math.Abs(x.Item2) + Math.Abs(x.Item1));
            return minimumPositions;
        }

        private List<Tuple<int,int>> GetCrossingPoints(List<Tuple<int,int>> cable1, string cable2)
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

        private bool IsCrossingPoint(int x, int y, List<Tuple<int,int>> cable)
        {
            return cable.Any(c => c.Item1 == x && c.Item2 == y);
        }

        private List<Tuple<int,int>> GetCablePositions(string cable)
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

        private int GetCombinedStep(List<Tuple<int, int>> cable, Tuple<int, int> crossingPoint)
        {
            int i = 0;
            Tuple<int, int> actualPoint = new Tuple<int, int>(0, 0);
            while (actualPoint.Item1 != crossingPoint.Item1 || actualPoint.Item2 != crossingPoint.Item2)
            {
                actualPoint = cable[i];
                i++;
            }

            return i;
        }
    }
}
