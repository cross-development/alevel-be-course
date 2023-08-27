using HW_4_1.Interfaces;
using Newtonsoft.Json;

namespace HW_4_1;

/// <summary>
/// Application entry point.
/// </summary>
public sealed class App
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IResourceService _resourceService;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="authService">The implementation of the <see cref="IAuthService"/> interface.</param>
    /// <param name="userService">The implementation of the <see cref="IUserService"/> interface.</param>
    /// <param name="resourceService">The implementation of the <see cref="IResourceService"/> interface.</param>
    public App(IAuthService authService, IUserService userService, IResourceService resourceService)
    {
        _authService = authService;
        _userService = userService;
        _resourceService = resourceService;
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

        Console.WriteLine();

        Console.WriteLine("User Service Methods");
        await ExecuteUserService();
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

    /// <summary>
    /// Used to call User service's methods.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task ExecuteUserService()
    {
        var result1 = await _userService.GetUserById(1);
        var result2 = await _userService.GetAllUsers();
        var result3 = await _userService.CreateUser("morpheus", "leader");
        var result4 = await _userService.UpdateUser(2, "morpheus", "zion resident");
        var result5 = await _userService.DeleteUser(2);

        Console.WriteLine(JsonConvert.SerializeObject(result1));
        Console.WriteLine(JsonConvert.SerializeObject(result2));
        Console.WriteLine(JsonConvert.SerializeObject(result3));
        Console.WriteLine(JsonConvert.SerializeObject(result4));
        Console.WriteLine(JsonConvert.SerializeObject(result5));
    }
}