using AdventOfCode.ConsoleApp.Interfaces;
using System.Text;

namespace AdventOfCode.ConsoleApp.Services
{
    public class ConsoleOutputService<T> : IOutputService<T> where T : class
    {
        public void PrintOutput(T data)
        {
            StringBuilder sb = new();
            sb.AppendLine("             *** HO HO HO ***");
            sb.AppendLine("*** Welcome to AdventOfCode 2022 Edition ***");
            sb.AppendLine(string.Empty);
            //sb.AppendLine($"Data Type: {data?.GetType()}.");
            //sb.AppendLine($"Response: {data}");

            Console.WriteLine(sb);
        }
    }
}
