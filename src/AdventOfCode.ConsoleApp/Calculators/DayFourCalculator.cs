using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayFourCalculator : AdventOfCodeCalculator
    {
        public override AdventOfCodeEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput, bool partOne)
        {
            var data = dataInput.Cast<DayFourEntity>();
            int counter = 0;

            if (partOne)
            {
                foreach (var item in data)
                {
                    if (item.RangeOne != null && item.RangeTwo != null)
                    {
                        var rangeOne = ConvertToIntArray(item.RangeOne);
                        var rangeTwo = ConvertToIntArray(item.RangeTwo);

                        if (IsCoveredAll(rangeOne, rangeTwo))
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine($"Counter: {counter}");
            return new DayFourEntity();
        }

        private static int[] ConvertToIntArray(string range)
        {
            return range.Split('-')
                .Select(x =>
                {
                    _ = int.TryParse(x, out int n);
                    return n;
                })
                .ToArray();
        }

        private static bool IsCovered(int[] rangeOne, int[] rangeTwo)
        {
            // Range 1 har lägsta första värde.
            if (rangeOne.First() < rangeTwo.First())
            {
                return rangeOne.Last() >= rangeTwo.Last();
            }

            // Rangen har samma lägsta värde
            if (rangeOne.First() == rangeTwo.First())
            {
                return rangeOne.Last() >= rangeTwo.Last() || rangeTwo.Last() > rangeOne.Last();
            }

            //Range två har lägre första värde
            if (rangeOne.First() > rangeTwo.First())
            {
                return rangeTwo.Last() >= rangeOne.Last();
            }

            return false;

        }

        private static bool IsCoveredAll(int[] rangeOne, int[] rangeTwo)
        {
            // 21-41, 33-89
            if (rangeOne.First() < rangeTwo.First())
            {
                return rangeOne.Last() >= rangeTwo.First();
            }

            // 19-41, 3-89
            if (rangeTwo.First() < rangeOne.First())
            {
                return rangeTwo.Last() >= rangeOne.First();

            }

            // 21-30, 21-44
            return rangeOne.First() == rangeTwo.First();
        }

    }
}
