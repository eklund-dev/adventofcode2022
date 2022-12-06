using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayFiveCalculator : AdventOfCodeCalculator
    {
        private Dictionary<int, List<string>> _crates = PopulateCrates();

        public override AdventOfCodeEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput, bool partOne)
        {
            var data = dataInput.Cast<DayFiveEntity>();

            if (partOne)
            {
                //PopulateCrates(ref _crates);

                List<Stack<char>> stacks = new();

                ArrangeStack(ref stacks);

                foreach (var input in data)
                {
                    if (!string.IsNullOrWhiteSpace(input.Instruction))
                    {
                        (int quantity, int from, int to) = CraneInstructionParser(input.Instruction);

                        HandleCrateBusiness(input.Instruction);

                        //for (int i = 0; i < quantity; i++)
                        //{
                        //    char poppedChar = stacks[from - 1].Pop();
                        //    stacks[to - 1].Push(poppedChar);
                        //    Console.WriteLine("STACK");
                        //    Console.WriteLine($"Moving {poppedChar} from {from} to {to}");
                        //    Console.WriteLine("*****");
                        //}

                        //Console.WriteLine($"***** Last item in stack {to} {stacks[to - 1].Peek()}");

                    }
                }

                //Console.WriteLine("*** USING STACKS ***");

                //for (int i = 0; i < stacks.Count; i++)
                //{
                //    Console.WriteLine(stacks[i].Peek());
                //}

                Console.WriteLine("*** USING DICTIONARY ***");

                foreach (var item in _crates)
                {
                    Console.WriteLine($"ID: {item.Key} : Value {item.Value.Last()}");
                }

                Console.WriteLine();
            }

            return new DayFiveEntity();
        }

        private void HandleCrateBusiness(string instruction)
        {
            (int quantity, int from, int to) = CraneInstructionParser(instruction);

            List<string> elementsToadd = new();

            for (int i = 0; i < quantity; i++)
            {
                var data = _crates[from].Last();
                elementsToadd.Add(data);
                _crates[from].RemoveAt(_crates[from].Count - 1);
            }

            elementsToadd.Reverse();

            foreach (var item in elementsToadd)
            {
                //crate[to] = crate[to].Append(item).ToArray();
                _crates[to].Add(item);
                Console.WriteLine("Dictionary");
                Console.WriteLine($"Moving char: {item} from {from} to {to}.");
                Console.WriteLine("*****");
            }

            Console.WriteLine($"Last item in dictionary {to} is {_crates[to].Last()}");
            //crate[to] = crate[to].Concat(elementsToAdd.Reverse()).ToArray();
        }

        private static (int quantity, int from, int to) CraneInstructionParser(string instruction)
        {
            string[] charInstruction = instruction.Split(' ');

            int quantity = Convert.ToInt32(charInstruction[1]);
            int fromStack = Convert.ToInt32(charInstruction[3]);
            int toStack = Convert.ToInt32(charInstruction[5]);

            return (quantity, fromStack, toStack);
        }

        private static string[] ArrangeStack(ref List<Stack<char>> stacks)
        {
            var basePath = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent?.Parent?.FullName;
            var input = File.ReadAllLines($"{basePath}/AdventOfCodeFiles/AdventOfCodeDayFiveCrates.csv");

            for (int i = 0; i < 9; i++)
                stacks.Add(new Stack<char>());

            for (int i = 7; i >= 0; i--)
            {
                int indexOfStack = 0;
                var line = input[i].ToCharArray();
                for (int j = 1; j < line.Length; j += 4)
                {
                    if (char.IsLetter(line[j]))
                    {
                        stacks[indexOfStack].Push(line[j]);
                    }
                    indexOfStack++;
                }
            }

            return input;
        }

        private static Dictionary<int, List<string>> PopulateCrates()
        {
            Dictionary<int, List<string>> crateDict = new()
            {
                { 1, new List<string> { "Z", "J", "N", "W", "P", "S" } },
                { 2, new List<string> { "G", "S", "T" } },
                { 3, new List<string> { "V", "Q", "R", "L", "H" } },
                { 4, new List<string> { "V", "S", "T", "D" } },
                { 5, new List<string> { "Q", "Z", "T", "D", "B", "M", "J" } },
                { 6, new List<string> { "M", "W", "T", "J", "D", "C", "Z", "L" } },
                { 7, new List<string> { "L", "P", "M", "W", "G", "T", "J" } },
                { 8, new List<string> { "N", "G", "M", "T", "B", "F", "Q", "H" } },
                { 9, new List<string> { "R", "D", "G", "C", "P", "B", "Q", "W" } }
            };

            return crateDict;


        }
    }
}
