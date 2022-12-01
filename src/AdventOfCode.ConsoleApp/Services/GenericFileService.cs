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
            List<T> dataEntities = new();

            var basePath = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent?.Parent?.FullName;

            using (var reader = new StreamReader($"{basePath}/AdventOfCodeFiles/{fileName}.csv"))
            using (var csv = new CsvReader(reader, configuration))
            {
                var records = csv.GetRecords<T>();
                dataEntities.AddRange(records);
            }

            return dataEntities;
        }
    }
}
