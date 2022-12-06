using CsvHelper.Configuration;
using System.Globalization;

namespace AdventOfCode.ConsoleApp.TaskConfig
{
    public class DayFiveConfig : AdventOfCodeConfigBase
    {
        public override string FileName => "AdventOfCodeDayFive.csv";

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
