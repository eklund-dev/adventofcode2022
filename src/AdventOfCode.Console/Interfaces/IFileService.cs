namespace AdventOfCode.Console.Interfaces
{
    public interface IFileService<T>
    {
        public IEnumerable<string> GetFileData();
    }
}
