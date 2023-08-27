using HW_4_1.Interfaces;
using Newtonsoft.Json;

namespace HW_4_1;

/// <summary>
/// Application entry point.
/// </summary>
public class App
{
    private readonly IResourceService _resourceService;
    private readonly IAuthService _authService;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="resourceService">The implementation of the <see cref="IResourceService"/> interface.</param>
    /// <param name="authService">The implementation of the <see cref="IAuthService"/> interface.</param>
    public App(IResourceService resourceService, IAuthService authService)
    {
        _resourceService = resourceService;
        _authService = authService;
    }

    /// <summary>
    /// Application entry method.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task Start()
    {
        Console.WriteLine("Resource Service Methods");
        await ExecuteResourceService();

        Console.WriteLine();

        Console.WriteLine("Auth Service Methods");
        await ExecuteAuthService();
    }

    /// <summary>
    /// Used to call Resource service's methods.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task ExecuteResourceService()
    {
        var result1 = await _resourceService.GetResourceById(1);
        var result2 = await _resourceService.GetAllResources();

        Console.WriteLine(JsonConvert.SerializeObject(result1));
        Console.WriteLine(JsonConvert.SerializeObject(result2));
    }

    /// <summary>
    /// Used to call Auth service's methods.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task ExecuteAuthService()
    {
        var result1 = await _authService.Register("eve.holt@reqres.in", "pistol");
        var result2 = await _authService.Login("eve.holt@reqres.in", "cityslicka");

        Console.WriteLine(JsonConvert.SerializeObject(result1));
        Console.WriteLine(JsonConvert.SerializeObject(result2));
    }
}