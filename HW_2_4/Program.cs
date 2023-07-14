using HW_2_4.Factories;
using HW_2_4.Factories.Abstractions;
using HW_2_4.Repositories;
using HW_2_4.Repositories.Abstractions;
using HW_2_4.Services;
using HW_2_4.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace HW_2_4;

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
        var serviceCollection = new ServiceCollection()
            .AddTransient<IAccountFactory, AccountFactory>()
            .AddTransient<IAccountService, AccountService>()
            .AddTransient<ITransactionService, TransactionService>()
            .AddTransient<ITransactionRepository, TransactionRepository>()
            .AddTransient<Application>();

        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<Application>();

        app?.Run();
    }
}
