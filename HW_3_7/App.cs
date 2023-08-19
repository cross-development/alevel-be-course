namespace HW_3_7;

/// <summary>
/// Application entry point.
/// </summary>
public sealed class App
{
    private readonly Logger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="logger">The instance of a Logger <see cref="Logger"/> class.</param>
    public App(Logger logger)
    {
        _logger = logger;
        _logger.BackupRequired += Logger_BackupRequired;
    }

    /// <summary>
    /// Application entry method.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task Start()
    {
        if (File.Exists(_logger.FileName))
        {
            File.Delete(_logger.FileName);
        }

        List<Task> tasks = new List<Task>();

        for (var i = 0; i < 2; ++i)
        {
            tasks.Add(Task.Run(async () =>
            {
                for (var j = 0; j < 50; ++j)
                {
                    await _logger.LogAsync($"Log entry {j} in the thread {Thread.CurrentThread.ManagedThreadId}");

                    await Task.Delay(1000);
                }
            }));
        }

        await Task.WhenAll(tasks.ToArray());
    }

    /// <summary>
    /// Used to subscribe to the Backup event inside Logger <see cref="Logger"/> class.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">An object that contains backup event args <see cref="BackupEventArgs"/>.</param>
    private void Logger_BackupRequired(object? sender, BackupEventArgs args)
    {
        var backupName = $"{DateTime.Now:yyyyMMddHHmmss}.log";
        var backupPath = Path.Combine(_logger.BackupFolderPath, backupName);

        Console.WriteLine($"Backup created: {backupPath}");

        File.Copy(args.FileName, backupPath);
    }
}