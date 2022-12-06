using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DaySixCalculator : AdventOfCodeCalculator
    {
        public override AdventOfCodeEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput, bool partOne)
        {
            var data = dataInput.Cast<DaySixEntity>().ToList();

            string testData = string.Empty;
            foreach (var item in data)
            {
                testData = item.Data!;
            }

            bool keepIterating = true;
            int index = 0;
            while (keepIterating)
            {
                List<char> sameShit = new();
                for (int i = index; i < index + 14; i++)
                {
                    sameShit.Add(testData[i]);
                }

                if (sameShit.Count != sameShit.Distinct().Count())
                {
                    // Duplicates found
                    sameShit.Clear();
                    index++;
                }
                else
                {
                    // No duplicates found
                    keepIterating = false;
                }
            }

            Console.WriteLine($"Found the first at {index + 14}.");

            return null;
        }

    }
}
