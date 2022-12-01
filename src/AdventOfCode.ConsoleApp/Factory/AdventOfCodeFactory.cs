using AdventOfCode.ConsoleApp.Calculators;
using System.Reflection;

namespace AdventOfCode.ConsoleApp.Factory
{
    public class AdventOfCodeFactory
    {
        public static AdventOfCodeCalculator? Create(string name)
        {
            try
            {
                var type = Assembly.GetAssembly(typeof(AdventOfCodeCalculator))?.GetType($"AdventOfCode.ConsoleApp.Calculators.{name}Calculator");

                if (type is null)
                {
                    throw new ArgumentException($"Resolved Type for class '{name}' is null");
                }

                return Activator.CreateInstance(type) as AdventOfCodeCalculator;


            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Unknown Calculator {name}.");
            }
        }
    }
}
