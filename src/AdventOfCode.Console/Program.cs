using AdventOfCode.ConsoleApp.Interfaces;
using AdventOfCode.ConsoleApp.Models;
using AdventOfCode.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

using IHost? host = CreateHostBuilder(args).Build();

var fileService = host.Services.GetRequiredService<IFileService<DayOneEntity>>();
var data = fileService.GetFileData();

PrintData(data);

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) => services
            .AddScoped(typeof(IFileService<>), typeof(GenericFileService<>)));

}

static void PrintData<T>(IEnumerable<T> data)
{
    StringBuilder sb = new();
    sb.AppendLine("             *** HO HO HO ***");
    sb.AppendLine("*** Welcome to AdventOfCode 2022 Edition ***");
    sb.AppendLine(string.Empty);

    Console.WriteLine(sb);

    Console.WriteLine($"Data: {data.GetType()}. MERRY CHRISTMASSSS");
}
