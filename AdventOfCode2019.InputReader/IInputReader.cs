namespace AdventOfCode2019.InputReader
{
    public interface IInputReader<T>
    {
        T[] ReadArray(string path, char separator);

        T[][] ReadMatrix(string path, char separator);
    }
}
