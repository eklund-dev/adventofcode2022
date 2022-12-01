using AdventOfCode.ConsoleApp.Interfaces;
using AdventOfCode.ConsoleApp.Models;

namespace AdventOfCode.ConsoleApp.Services
{
    public class GenericFileService<T> : IFileService<T> where T : AdventOfCodeEntity
    {
        public IEnumerable<T> GetFileData()
        {
            return new List<T>();
        }
    }
}
