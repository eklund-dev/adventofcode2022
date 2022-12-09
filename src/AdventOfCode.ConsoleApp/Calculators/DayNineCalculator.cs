using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayNineCalculator : AdventOfCodeCalculator
    {
        private const int _rows = 10;
        private const int _columns = 10;
        private List<int> _tailsVisited = new();
        private readonly int[,] _grid = new int[_rows, _columns];

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
            int number = 1;

            for (int i = 0; i != rows; i++)
            {
                for (int j = 0; j != columns; j++)
                {
                    _grid[i, j] = number;
                    number++;
                }
            }

            (int row, int column) startPosition = (5, 5);

            // Börjar med att addera startPosition
            _tailsVisited.Add(_grid[startPosition.row, startPosition.column]);

            // sätt startposition för både head och tail - båda startar på samma plats
            (int positionRow, int positionColumn) headerPosition = (startPosition.row, startPosition.column);
            (int positionRow, int positionColumn) tailPosition = (startPosition.row, startPosition.column);

            foreach (var (direction, steps) in input)
            {
                for (int i = 0; i < steps; i++)
                {
                    switch (direction.ToUpper())
                    {
                        case "U":
                            headerPosition = MoveUp(headerPosition);
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

            }

            return null;
        }

        private void CheckIfTailHasVisitThisPosition(int row, int column)
        {
            if (!_tailsVisited.Any(x => x == _grid[row, column]))
            {
                _tailsVisited.Add(_grid[row, column]);
            }
            else
            {
                Console.WriteLine("Damn you already been up in this place dawg.");
            }
        }

        private static (int positionRow, int positionColumn) MoveUp((int positionRow, int positionColumn) currentPosition)
        {
            return (currentPosition.positionRow - 1, currentPosition.positionColumn);
        }

        private void MoveRight(int steps, (int positionRow, int positionColumn) currentPosition)
        {

        }

        private void MoveDown(int steps, (int positionRow, int positionColumn) currentPosition)
        {

        }

        private void MoveLeft(int steps, (int positionRow, int positionColumn) currentPosition)
        {

        }

    }
}
