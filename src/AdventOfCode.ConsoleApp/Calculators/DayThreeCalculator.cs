using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayThreeCalculator : AdventOfCodeCalculator
    {
        public override AdventOfCodeEntity RunCalculations(IEnumerable<AdventOfCodeEntity> dataInput)
        {
            var data = dataInput.Cast<DayThreeEntity>().ToList();

            List<(string, int)> priorityList = new();
            bool breakForLoop;
            foreach (var item in data)
            {
                char[] rucksackOne = item.Data[..(item.Data.Length / 2)].ToCharArray();
                char[] rucksackTwo = item.Data[(item.Data.Length / 2)..].ToCharArray();

                breakForLoop = false;

                for (int i = 0; i < rucksackOne.Length; i++)
                {
                    for (int j = 0; j <rucksackTwo.Length; j++)
                    {

                        if (rucksackOne[i].Equals(rucksackTwo[j]))
                        {
                            Console.WriteLine($"{rucksackOne[i]} is equal to {rucksackTwo[j]}");
                            var value = CharToDigit(rucksackOne[i]);
                            priorityList.Add((rucksackOne[i].ToString(), value));
                            breakForLoop = true;
                            break;
                        }   
                    }
                    if (breakForLoop)
                        break;
                }
            }

            var summedValue = priorityList.Select(x => x.Item2).Sum();

            return null;
        }
    }
}
