using HW_4_4.Data;

namespace HW_4_4;

/// <summary>
/// Application entry point.
/// </summary>
public sealed class App
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="context">The instance of the <see cref="ApplicationDbContext"/> class.</param>
    public App(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Application entry method.
    /// </summary>
    public void Start()
    {
        var pets = _context.Pets.ToList();

        pets.ForEach(p =>
        {
            Console.WriteLine(p.Name);
        });
    }
}