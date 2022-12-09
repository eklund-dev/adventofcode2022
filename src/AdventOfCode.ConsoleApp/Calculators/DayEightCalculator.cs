using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DayEightCalculator : AdventOfCodeCalculator
    {
        public override AdventOfCodeEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput, bool partOne)
        {
            var data = dataInput.Cast<DayEightEntity>().ToList();

            List<List<int>> forrest = new();
            foreach (var item in data)
            {
                List<int> treeRow = new();
                foreach (var nbr in item.Data)
                {
                    treeRow.Add(int.Parse(nbr.ToString()));
                }

                forrest.Add(treeRow);
            }

            int visibleTrees = 0;
            int currentTreeRow = 1;
            List<decimal> scenicViews = new();
            foreach (var treeLine in forrest.Skip(1).Take(forrest.Count - 2))
            {
                for (int i = 1; i < treeLine.Count - 1; i++)
                {
                    var rowData = CheckVisibilityRow(treeLine[i], i, treeLine);
                    var columnData = CheckVisibilityColum(treeLine[i], i, currentTreeRow, forrest);

                    List<int> viewCounter = ViewCounter(treeLine[i], i, currentTreeRow, treeLine, forrest);

                    if (rowData.visibleRow || columnData.visibleColumn)
                        visibleTrees++;

                    scenicViews.Add(CalculateScenicView(viewCounter));
                    viewCounter.Clear();
                }

                currentTreeRow++;
            }

            Console.WriteLine();

            int scenicView = 1;

            Console.WriteLine(scenicViews.Max());

            Console.WriteLine($"Number of visible Trees found #{visibleTrees + 392}");

            return null;
        }

        static decimal CalculateScenicView(List<int> viewCounter)
        {
            decimal calculatedScenicView = 1m;

            foreach (var item in viewCounter)
            {
                calculatedScenicView *= item;
            }

            return calculatedScenicView;
        }

        static List<int> ViewCounter(int currentTreeHeight, int rowIndex, int currentTreeRow, List<int> treeRow, List<List<int>> forrest)
        {
            List<int> viewCounter = new();
            List<int> treeColumns = new();

            int currentRow = 0;

            for (int i = 0; i < forrest.Count; i++)
            {
                treeColumns.Add(forrest[i][rowIndex]);
                currentRow++;
            }

            // Up
            int upCounter = 0;
            for (int i = currentTreeRow - 1; i >= 0; i--)
            {
                // Kör endast allt ovan därav --
                if (treeColumns[i] >= currentTreeHeight)
                {
                    upCounter++;
                    break;
                }

                upCounter++;
            }

            viewCounter.Add(upCounter);

            //Left
            int leftCounter = 0;
            for (int i = rowIndex - 1; i >= 0; i--)
            {
                if (treeRow[i] >= currentTreeHeight)
                {
                    leftCounter++;
                    break;
                }

                leftCounter++;
            }

            viewCounter.Add(leftCounter);

            // Down
            int downCounter = 0;
            for (int i = currentTreeRow + 1; i < treeColumns.Count; i++)
            {
                if (treeColumns[i] >= currentTreeHeight)
                {
                    downCounter++;
                    break;
                }

                downCounter++;
            }

            viewCounter.Add(downCounter);

            // Right
            int rightCounter = 0;
            for (int i = rowIndex + 1; i < treeRow.Count; i++)
            {
                if (treeRow[i] >= currentTreeHeight)
                {
                    rightCounter++;
                    break;
                }

                rightCounter++;
            }

            viewCounter.Add(rightCounter);

            return viewCounter;
        }

        static (bool visibleRow, int viewCounter) CheckVisibilityRow(int currentTreeHeight, int rowIndex, List<int> treeRow)
        {
            // Här vill jag iterera hela vägen ut från vänster till höger.
            bool visibleLeft = true;
            bool visibleRight = true;
            int viewCounter = 0;

            for (int i = 0; i < treeRow.Count; i++)
            {
                // ignorera att jämföra med egna värdet.
                if (i == rowIndex)
                    continue;

                // vänster om värdet
                if (i < rowIndex && treeRow[i] >= currentTreeHeight)
                {
                    visibleLeft = false;
                }
                else
                {
                    viewCounter++;
                }

                // Höger om värdet
                if (i > rowIndex && treeRow[i] >= currentTreeHeight)
                {
                    visibleRight = false;
                }
                else
                {
                    viewCounter++;
                }

            }

            if (!visibleLeft && !visibleRight)
            {
                return (false, viewCounter);
            }

            return (true, viewCounter);
        }

        static (bool visibleColumn, int viewCounter) CheckVisibilityColum(int currentTreeHeight, int rowIndex, int currentTreeRow, List<List<int>> forrest)
        {
            List<int> treeColumns = new();

            int currentRow = 0;
            for (int i = 0; i < forrest.Count; i++)
            {
                treeColumns.Add(forrest[i][rowIndex]);

                currentRow++;
            }

            bool visibleFromTop = true;
            bool visibleFromBottom = true;
            int viewCounter = 0;
            for (int i = 0; i < treeColumns.Count; i++)
            {
                // Uppifrån
                if (i == currentTreeRow)
                    continue;

                if (i < currentTreeRow && treeColumns[i] >= currentTreeHeight)
                {
                    visibleFromTop = false;
                }
                else
                {
                    viewCounter++;
                }

                if (i > currentTreeRow && treeColumns[i] >= currentTreeHeight)
                {
                    visibleFromBottom = false;
                }
                else
                {
                    viewCounter++;
                }
            }

            if (!visibleFromTop && !visibleFromBottom)
            {
                return (false, viewCounter);
            }

            return (true, viewCounter);
        }

    }
}
