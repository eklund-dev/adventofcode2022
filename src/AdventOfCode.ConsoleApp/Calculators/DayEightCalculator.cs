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
            List<int> viewCounter = new();
            foreach (var treeLine in forrest.Skip(1).Take(forrest.Count - 2))
            {
                for (int i = 1; i < treeLine.Count - 1; i++)
                {
                    var rowData = CheckVisibilityRow(treeLine[i], i, treeLine);
                    var columnData = CheckVisibilityColum(treeLine[i], i, currentTreeRow, forrest);

                    if (rowData.visibleRow || columnData.visibleColumn)
                        visibleTrees++;

                    viewCounter.Add(rowData.viewCounter);
                    viewCounter.Add(columnData.viewCounter);
                }

                currentTreeRow++;
            }

            int scenicView = 1;

            foreach (var item in viewCounter)
            {
                scenicView *= item;
            }

            Console.WriteLine(scenicView);

            Console.WriteLine($"Number of visible Trees found #{visibleTrees + 392}");

            return null;
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
