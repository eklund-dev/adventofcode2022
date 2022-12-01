using AdventOfCode.Console.Interfaces;
using AdventOfCode.Console.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdventOfCode.Console
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            System.Console.WriteLine("Hello World");

            return host.RunAsync();
        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args);
                //.ConfigureServices((_, services) => n
                    //services.AddTransient<IFileService<string>, typeof(CsvFileService));
        }
    }
}