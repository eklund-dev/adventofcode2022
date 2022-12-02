using CsvHelper.Configuration;
using System.Globalization;

namespace AdventOfCode.ConsoleApp.TaskConfig
{
    public class DayTwoConfig : AdventOfCodeConfigBase
    {
        public override string FileName => "AdventOfCodeDayTwo.csv";

        public override CsvConfiguration Configuration { get; } = GenerateConfig();

        private static CsvConfiguration GenerateConfig()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null,
                IgnoreBlankLines = false,
                TrimOptions = TrimOptions.Trim,
                DetectDelimiter = false,
                Delimiter = "\t"
            };
        }
    }
}
