using AdventOfCode.ConsoleApp.Factory;
using AdventOfCode.ConsoleApp.Interfaces;
using AdventOfCode.ConsoleApp.Models.Base;

namespace AdventOfCode.ConsoleApp.Engine
{
    public class AdventOfCodeEngine<T> : IAdventOfCodeEngine<T> where T : AdventOfCodeEntity
    {
        private readonly IFileService<T> _service;
        private readonly IOutputService<T> _outputService;

        public AdventOfCodeEngine(IFileService<T> service, IOutputService<T> outputService)
        {
            _service = service;
            _outputService = outputService;
        }

        public void Run(string adventOfCodeTaskName)
        {
            var calculator = AdventOfCodeFactory.Create(adventOfCodeTaskName) ??
                throw new ArgumentNullException($"Could not create instance of Calculator with name '{adventOfCodeTaskName}'");

            var taskConfig = AdventOfCodeConfigFactory.Create(adventOfCodeTaskName) ??
                throw new ArgumentNullException($"Could not create instance of Config with name '{adventOfCodeTaskName}'");

            var data = _service.GetFileData(taskConfig.FileName, taskConfig.Configuration);

            var response = (T)calculator.RunCalculation(data);

            _outputService.PrintOutput(response);
        }
    }
}
