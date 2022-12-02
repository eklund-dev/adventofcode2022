using CsvHelper.Configuration;

namespace AdventOfCode.ConsoleApp.TaskConfig
{
    public abstract class AdventOfCodeConfigBase
    {
        public abstract string FileName { get; }

        public abstract CsvConfiguration Configuration { get; }
    }
}
