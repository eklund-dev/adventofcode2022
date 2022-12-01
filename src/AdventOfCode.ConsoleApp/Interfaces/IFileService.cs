using AdventOfCode.ConsoleApp.Models.Base;
using CsvHelper.Configuration;

namespace AdventOfCode.ConsoleApp.Interfaces
{
    public interface IFileService<T> where T : AdventOfCodeEntity
    {
        public IEnumerable<T> GetFileData(string fileName, CsvConfiguration? configuration);
    }
}
