using AdventOfCode.ConsoleApp.Models.Base;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public abstract class AdventOfCodeCalculator
    {
        public abstract AdventOfCodeEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput, bool partOne);
        public static int CharToDigit(char character)
        {
            if (char.IsUpper(character))
            {
                return character - 64 + 26;
            }
            else
            {
                return (int)character - 96;
            }
        }
    }
}
