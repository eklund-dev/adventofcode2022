namespace AdventOfCode.ConsoleApp.Interfaces
{
    public interface IOutputService<T> where T : class
    {
        void PrintOutput(T data);
    }
}
