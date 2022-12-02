namespace AdventOfCode.ConsoleApp.Interfaces
{
    public interface IAdventOfCodeEngine<T> where T : class
    {
        void Run(string adventOfCodeTask);
    }
}
