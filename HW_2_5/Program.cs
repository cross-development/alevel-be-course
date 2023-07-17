using HW_2_5.Services;
using HW_2_5.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using HW_2_5.Configs;

namespace HW_2_5;

/// <summary>
/// Program entry point.
/// </summary>
internal class Program
{
    /// <summary>
    /// Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    private static void Main(string[] args)
    {
        ServiceCollection serviceCollection = new ServiceCollection();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        ConfigureServices(serviceCollection, configuration);

        ServiceProvider provider = serviceCollection.BuildServiceProvider();
        App? app = provider.GetService<App>();

        app!.Run();
    }

    /// <summary>
    /// This method is used to configure app services.
    /// </summary>
    /// <param name="serviceCollection">The instance of the <see cref="ServiceCollection"/> class.</param>
    /// <param name="configuration">The implementation of the <see cref="IConfiguration"/> interface.</param>
    private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddOptions<FileOption>().Bind(configuration.GetSection("Logger"));

        serviceCollection.AddTransient<IActionService, ActionService>()
            .AddSingleton<ILoggerService, LoggerService>()
            .AddSingleton<IFileService, FileService>()
            .AddTransient<App>();
    }
}
