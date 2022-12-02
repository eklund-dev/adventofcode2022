using CsvHelper.Configuration;
using System.Globalization;

namespace AdventOfCode.ConsoleApp.TaskConfig
{
    public class DayThreeConfig : AdventOfCodeConfigBase
    {
        public override string FileName => "AdventOfCodeDayThree.csv";

        public override CsvConfiguration Configuration { get; } = GenerateConfig();

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
