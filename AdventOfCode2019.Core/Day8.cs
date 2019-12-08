using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Core
{
    public class Day8
    {
        List<int[,]> layers = new List<int[,]>();

        public int GetMaximumNumberOfOneAndTwo(string path, int width, int heigth)
        {
            GetLayers(path, width, heigth);

            int position = 0;
            int minimum = int.MaxValue;
            for (int i = 0; i < layers.Count; i++)
            {
                var numberOfZeros = NumberOfNumber(layers[i], 0, width, heigth);
                if (numberOfZeros < minimum)
                {
                    minimum = numberOfZeros;
                    position = i;
                }
            }

            int numberOfOne = NumberOfNumber(layers[position], 1, width, heigth);
            int numberOfTwo = NumberOfNumber(layers[position], 2, width, heigth);
            return numberOfOne * numberOfTwo;
        }

        public string GetMessage(string path, int width, int height)
        {
            GetLayers(path, width, height);

            int[,] m = new int[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int k = 0;
                    while (layers[k][j, i] == 2)
                    {
                        k++;
                    }

                    m[j, i] = layers[k][j, i];
                }
            }

            StringBuilder response = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (m[j, i] != 0)
                        Debug.Write(m[j, i]);
                    else
                        Debug.Write(" ");
                }
                Debug.WriteLine("");
            }

            return response.ToString();
        }

        private void GetLayers(string path, int width, int heigth)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    int[,] matrix = new int[width, heigth];
                    for (int i = 0; i < heigth; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            matrix[j, i] = int.Parse(((char)reader.Read()).ToString());
                        }
                    }

                    layers.Add(matrix);
                }
            }
        }

        private int NumberOfNumber(int[,] matrix, int number, int width, int height)
        {
            int sum = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (matrix[i, j] == number)
                        sum++;
                }
            }

            return sum;
        }

    }
}
