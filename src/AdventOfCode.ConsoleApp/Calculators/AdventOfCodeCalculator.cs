using AdventOfCode.ConsoleApp.Models.Base;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public abstract class AdventOfCodeCalculator
    {
        public abstract AdventOfCodeEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput);
    }
}
