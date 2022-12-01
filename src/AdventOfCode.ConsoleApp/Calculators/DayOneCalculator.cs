using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayOneCalculator : AdventOfCodeCalculator
    {
        public override DayOneEntity RunCalculations(IEnumerable<AdventOfCodeEntity> dataInput)
        {
            Console.WriteLine("Running Calculations in the cool calculator hhhäh");
            return new DayOneEntity();
        }
    }
}
