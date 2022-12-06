﻿using AdventOfCode.ConsoleApp.Models.Base;
using CsvHelper.Configuration.Attributes;

namespace AdventOfCode.ConsoleApp.Models.Type
{
    public class DayThreeEntity : AdventOfCodeEntity
    {
        [Index(0)]
        public string? Data { get; set; }
    }
}
