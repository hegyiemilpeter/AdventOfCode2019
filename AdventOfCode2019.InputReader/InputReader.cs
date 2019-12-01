using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.InputReader
{
    public abstract class InputReader<T> : IInputReader<T>
    {
        public abstract T[] ParseLine(string line, char? separator = null);

        public T[][] ReadMatrix(string path, char separator)
        {
            return ReadFile(path, separator);
        }

        public T[] ReadArray(string path, char separator)
        {
            T[][] fileContent = ReadFile(path, separator);
            if (fileContent == null)
            {
                throw new FileLoadException("File content cannot be readed.");
            }

            if(fileContent.Length == 0)
            {
                return fileContent[0];
            }

            if(fileContent.All(x => x.Length == 1))
            {
                return fileContent.Select(x => x.First()).ToArray();
            }

            throw new Exception("File content is not an array.");
        }

        private T[][] ReadFile(string path, char? separator = null)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            List<T[]> response = new List<T[]>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                T[] parsedLine = ParseLine(line, separator);
                response.Add(parsedLine);
            }

            return response.ToArray();
        }
    }
}
