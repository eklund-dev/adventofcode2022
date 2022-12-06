using CsvHelper.Configuration;
using System.Globalization;

namespace AdventOfCode.ConsoleApp.TaskConfig
{
    public class DaySevenConfig : AdventOfCodeConfigBase
    {
        public override string FileName => "AdventOfCodeDaySeven.csv";

        public override CsvConfiguration Configuration => GenerateConfig();

        private static CsvConfiguration GenerateConfig()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null,
                IgnoreBlankLines = false,
            };
        }
    }
}
