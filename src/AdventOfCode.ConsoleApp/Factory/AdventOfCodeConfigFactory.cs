using AdventOfCode.ConsoleApp.TaskConfig;
using System.Reflection;

namespace AdventOfCode.ConsoleApp.Factory
{
    public class AdventOfCodeConfigFactory
    {
        public static AdventOfCodeConfigBase Create(string name)
        {
            try
            {
                var type = Assembly.GetAssembly(typeof(AdventOfCodeConfigBase))?.GetType($"AdventOfCode.ConsoleApp.TaskConfig.{name}Config");

                return type is null
                    ? throw new ArgumentException($"Resolved Type for class '{name}' is null")
                    : (AdventOfCodeConfigBase)Activator.CreateInstance(type)!;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Unknown Config: {name}.");
            }
        }
    }
}
