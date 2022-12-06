using AdventOfCode.ConsoleApp.Extensions;
using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayThreeCalculator : AdventOfCodeCalculator
    {
        public override AdventOfCodeEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput, bool partOne)
        {
            var data = dataInput.Cast<DayThreeEntity>().ToList();
            List<(string, int)> priorityList = new();

            if (partOne)
            {
                bool breakForLoop;
                foreach (var item in data)
                {
                    char[] rucksackOne = item.Data[..(item.Data.Length / 2)].ToCharArray();
                    char[] rucksackTwo = item.Data[(item.Data.Length / 2)..].ToCharArray();

                    breakForLoop = false;

                    for (int i = 0; i < rucksackOne.Length; i++)
                    {
                        for (int j = 0; j < rucksackTwo.Length; j++)
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

            }
            else
            {
                bool keepGoing = true;
                int skip = 0;
                int take = 3;

                while (keepGoing)
                {
                    var myList = data.Skip(skip).Take(take).ToList();

                    if (myList.Count >= 3)
                    {
                        var rucksackOne = myList[0].Data.Alphabetize().ToCharArray();
                        var rucksackTwo = myList[1].Data.Alphabetize().ToCharArray();
                        var rucksackThree = myList[2].Data.Alphabetize().ToCharArray();

                        for (int i = 0; i < rucksackOne.Length; i++)
                        {
                            if (Array.Exists(rucksackTwo, element => element.Equals(rucksackOne[i]) &&
                                Array.Exists(rucksackThree, element => element.Equals(rucksackOne[i]))))
                            {
                                Console.WriteLine($"Matching element is {rucksackOne[i]}");
                                var value = CharToDigit(rucksackOne[i]);
                                priorityList.Add((rucksackOne[i].ToString(), value));
                                break;
                            }
                        }

                        skip += 3;
                    }
                    else
                    {
                        keepGoing = false;
                    }
                }
                var summedValue = priorityList.Select(x => x.Item2).Sum();

            }


            return null;
        }

    }
}
