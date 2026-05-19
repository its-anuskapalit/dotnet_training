using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MoreInterfaceExamples;

public static class Demo_DI_Host_Logging
{
    public static async Task RunAsync()
    {
        Console.WriteLine("---- 15) DI + Host + Logging Interfaces Demo ----");

        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<Greeter>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.Information);
            })
            .Build();

        var greeter = host.Services.GetRequiredService<Greeter>();
        greeter.SayHello("Student");

        var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
        ILogger customLogger = loggerFactory.CreateLogger("CustomCategory");
        customLogger.LogInformation("ILoggerFactory created this logger.");

        await host.StartAsync();
        await host.StopAsync();

        Console.WriteLine();
    }

    public sealed class Greeter
    {
        private readonly ILogger<Greeter> _logger;

        public Greeter(ILogger<Greeter> logger) => _logger = logger;

        public void SayHello(string name)
        {
            _logger.LogInformation("Hello {Name} from Greeter (ILogger<T>)", name);
        }
    }
}
