using AdventOfCode.ConsoleApp.Models.Base;
using CsvHelper.Configuration.Attributes;

namespace AdventOfCode.ConsoleApp.Models.Type
{
    public class DayOneEntity : AdventOfCodeEntity
    {
        [Index(0)]
        public int? Value { get; set; }
    }
}
