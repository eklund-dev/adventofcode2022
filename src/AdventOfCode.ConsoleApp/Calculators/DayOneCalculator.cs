using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayOneCalculator : AdventOfCodeCalculator
    {
        public override DayOneEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput, bool partOne)
        {
            Console.WriteLine($"*** Running Calculations in --{nameof(DayOneCalculator)}-- *** ");

            List<int> topCarriers = new();
            int maxCalorieCarrier = int.MinValue;
            int caloriesCombined = 0;
            int carriers = 0;

            List<AdventOfCodeEntity> list = dataInput.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                DayOneEntity data = (DayOneEntity)list[i];
                if (data.Value is not null)
                {
                    caloriesCombined += (int)data.Value;
                }
                else
                {
                    if (caloriesCombined >= maxCalorieCarrier)
                    {
                        maxCalorieCarrier = caloriesCombined;
                    }

                    Console.WriteLine($"Leading calorie carrier is at number: {maxCalorieCarrier} calories.");
                    topCarriers.Add(caloriesCombined);
                    caloriesCombined = 0;
                    carriers++;
                }
            }

            Console.WriteLine("*** Top 3 Carriers ***");

            foreach (var carrier in topCarriers.OrderByDescending(x => x).Take(3))
            {
                Console.WriteLine(carrier);
            }

            var summarizedTopThreeCalorieCarrier = topCarriers.OrderByDescending(x => x).Take(3).Sum();
            var sortedList = topCarriers.OrderByDescending(x => x).ToList();
            Console.WriteLine($"Carriers: {carriers}");

            return new DayOneEntity { Value = maxCalorieCarrier };
        }

    }
}