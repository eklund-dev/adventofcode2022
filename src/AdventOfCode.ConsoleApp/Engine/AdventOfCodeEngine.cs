using AdventOfCode.ConsoleApp.Factory;
using AdventOfCode.ConsoleApp.Interfaces;
using AdventOfCode.ConsoleApp.Models.Type;
using CsvHelper.Configuration;
using System.Globalization;

namespace AdventOfCode.ConsoleApp.Engine
{
    public class AdventOfCodeEngine : IAdventOfCodeEngine
    {
        private readonly IFileService<DayThreeEntity> _service;
        private readonly IOutputService<DayThreeEntity> _outputService;
        private readonly string _fileName = "AdventOfCodeDayThree";

        public AdventOfCodeEngine(IFileService<DayThreeEntity> service, IOutputService<DayThreeEntity> outputService)
        {
            _service = service;
            _outputService = outputService;
        }

        public void Run(string adventOfCodeTaskName)
        {
            var calculator = AdventOfCodeFactory.Create(adventOfCodeTaskName) ??
                throw new ArgumentNullException($"Could not create instance of calculator with name '{adventOfCodeTaskName}'");

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            var data = _service.GetFileData(_fileName, configuration);
            var response = calculator.RunCalculations(data);
            _outputService.PrintOutput((DayThreeEntity)response);
        }
    }
}
