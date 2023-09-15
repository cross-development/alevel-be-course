using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HW_4_5.Data;
using HW_4_5.Repositories;
using HW_4_5.Repositories.Abstractions;
using HW_4_5.Services;
using HW_4_5.Services.Abstractions;

namespace HW_4_5;

/// <summary>
/// Program entry point.
/// </summary>
public sealed class Program
{
    /// <summary>
    ///  Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection, configuration);

        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        await app!.Start();
    }

    private static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        serviceCollection
            .AddTransient<ILocationService, LocationService>()
            .AddTransient<ICategoryService, CategoryService>()
            .AddTransient<IBreedService, BreedService>()
            .AddTransient<IPetService, PetService>()
            .AddTransient<ILocationRepository, LocationRepository>()
            .AddTransient<ICategoryRepository, CategoryRepository>()
            .AddTransient<IBreedRepository, BreedRepository>()
            .AddTransient<IPetRepository, PetRepository>()
            .AddTransient<App>();
    }
}
