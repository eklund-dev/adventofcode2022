using AdventOfCode.ConsoleApp.Models.Base;
using CsvHelper.Configuration.Attributes;

namespace AdventOfCode.ConsoleApp.Models.Type
{
    public class DayFiveEntity : AdventOfCodeEntity
    {
        [Index(0)]
        public string? Instruction { get; set; }
    }
}


