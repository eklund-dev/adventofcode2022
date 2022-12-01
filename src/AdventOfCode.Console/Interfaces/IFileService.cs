using AdventOfCode.ConsoleApp.Models;

namespace AdventOfCode.ConsoleApp.Interfaces
{
    public interface IFileService<T> where T : AdventOfCodeEntity
    {
        public IEnumerable<T> GetFileData();
    }
}
