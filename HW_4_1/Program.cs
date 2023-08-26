using HW_4_1.Configs;
using HW_4_1.Interfaces;
using HW_4_1.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HW_4_1;

/// <summary>
/// Program entry point.
/// </summary>
internal class Program
{
    /// <summary>
    ///  Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        await app!.Start();
    }

    private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddOptions<ApiConfig>().Bind(configuration.GetSection("Api"));
        serviceCollection
            .AddHttpClient()
            .AddTransient<IHttpClientService, HttpClientService>()
            .AddTransient<IResourceService, ResourceService>()
            .AddTransient<IAuthService, AuthService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<App>();
    }
}