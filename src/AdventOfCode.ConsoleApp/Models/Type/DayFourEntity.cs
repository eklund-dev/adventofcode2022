using AdventOfCode.ConsoleApp.Models.Base;
using CsvHelper.Configuration.Attributes;

namespace AdventOfCode.ConsoleApp.Models.Type
{
    public class DayFourEntity : AdventOfCodeEntity
    {
        [Index(0)]
        public string? RangeOne { get; set; }
        [Index(1)]
        public string? RangeTwo { get; set; }
    }
}
