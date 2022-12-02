using AdventOfCode.ConsoleApp.Interfaces;
using AdventOfCode.ConsoleApp.Models.Base;
using CsvHelper;
using CsvHelper.Configuration;

namespace AdventOfCode.ConsoleApp.Services
{
    public class GenericFileService<T> : IFileService<T> where T : AdventOfCodeEntity
    {
        public IEnumerable<T> GetFileData(string fileName, CsvConfiguration? configuration)
        {
            IEnumerable<T> dataEntities;
            var basePath = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent?.Parent?.FullName;

            using (var reader = new StreamReader($"{basePath}/AdventOfCodeFiles/{fileName}"))
            using (var csv = new CsvReader(reader, configuration))
            {
                dataEntities = csv.GetRecords<T>().ToList();
            }

            return dataEntities;
        }

    }
}
