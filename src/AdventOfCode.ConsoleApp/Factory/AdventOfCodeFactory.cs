using AdventOfCode.ConsoleApp.Calculators;
using System.Reflection;

namespace AdventOfCode.ConsoleApp.Factory
{
    public class AdventOfCodeFactory
    {
        public static AdventOfCodeCalculator Create(string name)
        {
            try
            {
                var type = Assembly.GetAssembly(typeof(AdventOfCodeCalculator))?.GetType($"AdventOfCode.ConsoleApp.Calculators.{name}Calculator");

                return type is null
                    ? throw new ArgumentException($"Resolved Type for class '{name}' is null")
                    : (AdventOfCodeCalculator)Activator.CreateInstance(type)!;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Unknown Calculator {name}.");
            }
        }
    }
}
