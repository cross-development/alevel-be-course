using HW_4_4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HW_4_4;

/// <summary>
/// Program entry point.
/// </summary>
internal class Program
{
    /// <summary>
    ///  Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    private static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("application.json")
            .Build();

        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection, configuration);

        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        app!.Start();
    }

    private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        serviceCollection.AddTransient<App>();
    }
}
