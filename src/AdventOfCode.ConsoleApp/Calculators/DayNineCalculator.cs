using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayNineCalculator : AdventOfCodeCalculator
    {
        private List<(int, int)> _tailsVisited = new();

        public override AdventOfCodeEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput, bool partOne)
        {
            var data = dataInput.Cast<DayNineEntity>().ToList();

            List<(string direction, int steps)> input = new();

            foreach (var item in data)
            {
                var dataPoint = item.Data.Split(' ');
                input.Add((dataPoint[0].ToString(), int.Parse(dataPoint[1])));
            }

            int rows = 100;
            int columns = 100;
            int[,] grid = new int[rows, columns];
            int number = 1;
            for (int i = 0; i != rows; i++)
            {
                for (int j = 0; j != columns; j++)
                {
                    grid[i, j] = number;
                    number++;
                }
            }

            Console.WriteLine(grid[3, 4]);

            // Skapa spelplanen
            var twoDimList = new List<List<int>>();

            var startPosition = (100, 100);

            // Börjar med att addera startPosition
            _tailsVisited.Add(startPosition);

            (int positionX, int positionY) currentPosition = startPosition;

            foreach (var move in input)
            {
                switch (move.direction.ToUpper())
                {
                    case "U":
                        break;
                    case "R":
                        break;
                    case "D":
                        break;
                    case "L":
                        break;
                    default:
                        break;
                }
            }



            // Utgå från att spelplanen är oändligt stor - inga kanter verkar existera

            return null;
        }

        private void MoveUp(string direction, int steps)
        {

        }

        private void MoveRight(string direction, int steps)
        {

        }

        private void MoveDown()
        {

        }

        private void MoveLeft(string direction, int steps)
        {

        }


    }
}
