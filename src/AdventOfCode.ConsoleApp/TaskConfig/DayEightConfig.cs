using CsvHelper.Configuration;
using System.Globalization;

namespace AdventOfCode.ConsoleApp.TaskConfig
{
    internal class DayEightConfig : AdventOfCodeConfigBase
    {
        public override string FileName => "AdventOfCodeDayEight.csv";

        public override CsvConfiguration Configuration => GenerateConfig();

        private static CsvConfiguration GenerateConfig()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null,
                IgnoreBlankLines = true,
            };
        }
    }
}
