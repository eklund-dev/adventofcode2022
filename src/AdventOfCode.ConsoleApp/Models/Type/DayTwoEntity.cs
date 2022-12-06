using AdventOfCode.ConsoleApp.Models.Base;
using CsvHelper.Configuration.Attributes;

namespace AdventOfCode.ConsoleApp.Models.Type
{
    public class DayTwoEntity : AdventOfCodeEntity
    {
        [Index(0)]
        public string? Round { get; set; }

    }
}
