using AdventOfCode.ConsoleApp.Engine;
using AdventOfCode.ConsoleApp.Interfaces;
using AdventOfCode.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost? host = CreateHostBuilder(args).Build();

var engine = host.Services.GetRequiredService<IAdventOfCodeEngine>();

engine.Run("DayThree");

host.Run();

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) => services
            .AddScoped(typeof(IFileService<>), typeof(GenericFileService<>))
            .AddScoped(typeof(IOutputService<>), typeof(ConsoleOutputService<>))
            .AddScoped<IAdventOfCodeEngine, AdventOfCodeEngine>());
}