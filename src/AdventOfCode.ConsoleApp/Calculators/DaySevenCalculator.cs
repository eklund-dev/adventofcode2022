using AdventOfCode.ConsoleApp.Models.Base;
using AdventOfCode.ConsoleApp.Models.Type;

namespace AdventOfCode.ConsoleApp.Calculators
{
    public class DaySevenCalculator : AdventOfCodeCalculator
    {
        public override AdventOfCodeEntity RunCalculation(IEnumerable<AdventOfCodeEntity> dataInput, bool partOne)
        {
            // Testar med en mindre datamängd
            var testMinifiedData = dataInput.Cast<DaySevenEntity>().Skip(1).ToList();

            // Adderar root level
            List<DirectoryFolder> directories = new()
            {
                new DirectoryFolder { ParentFolder = null, IndexLevel = 0, Name = "/" }
            };

            int lineIndex = 0;
            var maxLevel = testMinifiedData.Count;

            DirectoryFolder? rootFolder = directories.Where(x => x.IndexLevel == 0).First();
            DirectoryFolder currentFolder = rootFolder;

            int treeLevelsTotal = 1;
            int currentTreelevel = 1;
            while (lineIndex < maxLevel)
            {
                for (int i = lineIndex; i < testMinifiedData.Count; i++)
                {
                    var nextMove = testMinifiedData[i].Data;
                    var checkIfCommand = nextMove[..1];

                    // Om ett Command dyker upp.
                    if (checkIfCommand.Equals(Commands.IsCommand))
                    {
                        // Visa listan i directoryn
                        if (nextMove.Equals(Commands.ShowList))
                        {
                            var directoryDataList = testMinifiedData.Skip(i + 1).TakeWhile(x => !x.Data.StartsWith(Commands.IsCommand)).ToList();
                            if (currentFolder?.SubFolders?.Count < 1)
                            {
                                foreach (var item in directoryDataList)
                                {
                                    if (item.Data.StartsWith("dir"))
                                    {
                                        // Addera ny Directory
                                        var dir = new DirectoryFolder
                                        {
                                            ParentFolder = currentFolder,
                                            Name = item.Data[4..],
                                            IndexLevel = currentTreelevel,
                                        };

                                        currentFolder?.SubFolders?.Add(dir);
                                        directories.Add(dir);
                                    }
                                    else
                                    {
                                        var itemData = item.Data.Split(' ').ToList();
                                        var file = new DirectoryFile
                                        {
                                            DirectoryFolderName = currentFolder?.Name,
                                            Value = int.Parse(itemData[0]),
                                            FileName = itemData[1],
                                            IndexLevel = currentTreelevel
                                        };
                                        currentFolder?.FolderFiles?.Add(file);
                                    }
                                }

                                currentFolder?.SetDirectoryValue();
                            }

                            var newCount = i += directoryDataList.Count + 1;
                            lineIndex = newCount;
                            break;

                        }

                        if (nextMove.Equals(Commands.ChangeDirectoryUpOneLevel))
                        {
                            currentFolder = currentFolder.ParentFolder;
                            currentTreelevel--;
                        }

                        // Gå ned ett steg i noderna.
                        if (nextMove.Contains(Commands.ChangeDirectory) && !nextMove.Equals(Commands.ChangeDirectoryUpOneLevel))
                        {
                            var folderName = nextMove.Split(' ')[2];
                            var subFolder = currentFolder?.SubFolders?.Where(x => x.Name.Equals(folderName)).First();
                            if (subFolder == null)
                                throw new ArgumentException("Subfolder is null - it cant be like that");

                            currentFolder = subFolder;
                            currentTreelevel++;
                        }

                        if (nextMove.Contains(Commands.OuterMostDirectory))
                        {
                            currentFolder = rootFolder;
                            currentTreelevel = 0;
                        }
                    }
                }

                if (currentTreelevel > treeLevelsTotal)
                {
                    treeLevelsTotal = currentTreelevel;
                };
            }

            // Efter denna körning är allt som det ska tror jag.
            for (int i = treeLevelsTotal; i >= 0; i--)
            {
                foreach (var dir in directories.Where(x => x.IndexLevel == i))
                {
                    if (dir.ParentFolder == null)
                    {
                        break;
                    }
                    var parent = dir.ParentFolder;
                    parent.AggregatedSubFolderValue += (dir.DirectoryValue + dir.AggregatedSubFolderValue);
                    dir.TotalValue += dir.AggregatedSubFolderValue + dir.DirectoryValue;
                }
            }

            rootFolder.TotalValue = rootFolder.DirectoryValue + rootFolder.AggregatedSubFolderValue;


            var numbers = directories
                .Where(x => (x.AggregatedSubFolderValue + x.DirectoryValue) <= 100000)
                .Select(x => x.AggregatedSubFolderValue)
                .Sum();

            var foldersWithoutSubDirectories = directories
                .Where(x => x.SubFolders.Count < 1 && x.DirectoryValue <= 100000)
                .Select(x => x.DirectoryValue)
                .Sum();

            var totalDiskSpace = 70000000;
            var totalSpaceUsedOnDisk = rootFolder.TotalValue;
            var spaceNeedOnDisk = 30000000;

            var spaceToFreeUp = Math.Abs(totalDiskSpace - totalSpaceUsedOnDisk - spaceNeedOnDisk);

            var smallesDirectoryToDelete = directories.Where(x => x.TotalValue > spaceToFreeUp).OrderBy(x => x.TotalValue).First();


            Console.WriteLine("End of iteration");

            return null;
        }

    }

    public static class Commands
    {
        public const string IsCommand = "$";
        public const string OuterMostDirectory = "$ cd /";
        public const string ShowList = "$ ls";
        public const string ChangeDirectory = "$ cd";
        public const string ChangeDirectoryUpOneLevel = "$ cd ..";
    }

    public class DirectoryFolder
    {
        public DirectoryFolder? ParentFolder { get; set; }
        public string? Name { get; set; }
        public int IndexLevel { get; set; }
        public List<DirectoryFolder>? SubFolders { get; set; } = new List<DirectoryFolder>();
        public List<DirectoryFile>? FolderFiles { get; set; } = new List<DirectoryFile>();
        public int DirectoryValue { get; private set; }
        public int AggregatedSubFolderValue { get; set; }
        public int TotalValue { get; set; }
        public void SetDirectoryValue()
        {
            if (FolderFiles?.Count > 0)
            {
                DirectoryValue = FolderFiles.Select(x => x.Value).Sum();
            }
        }

        //public void SetAggregatedValue()
        //{
        //    if (SubFolders?.Count > 0)
        //    {
        //        foreach (var sub in SubFolders)
        //        {
        //            sub.AggregatedSubFolderValue += sub.DirectoryValue;
        //        }

        //    }
        //}

    }

    public class DirectoryFile
    {
        public string? DirectoryFolderName { get; set; }
        public int IndexLevel { get; set; }
        public string? FileName { get; set; }
        public int Value { get; set; }
    }
}
