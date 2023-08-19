namespace HW_3_7;

/// <summary>
/// Logger class.
/// </summary>
public class Logger
{
    /// <summary>
    /// Event that used to notify when to back up the log file.
    /// </summary>
    public event EventHandler<BackupEventArgs>? BackupRequired;

    private readonly int _backupThreshold;
    private readonly AutoResetEvent _waitHandle = new(true);
    private int _logCount = 0;

    /// <summary>
    /// Gets a name of the log file.
    /// </summary>
    public string FileName { get; } = "log.log";

    /// <summary>
    /// Gets a pathname for a backup folder.
    /// </summary>
    public string BackupFolderPath { get; } = "Backup";

    /// <summary>
    /// Initializes a new instance of the <see cref="Logger"/> class.
    /// </summary>
    /// <param name="backupThreshold">A threshold for a backup.</param>
    public Logger(int backupThreshold)
    {
        if (!Directory.Exists(BackupFolderPath))
        {
            Directory.CreateDirectory(BackupFolderPath);
        }

        _backupThreshold = backupThreshold;
    }

    /// <summary>
    /// Used to log message.
    /// </summary>
    /// <param name="message">Some log message.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task LogAsync(string message)
    {
        _waitHandle.WaitOne();

        await File.AppendAllTextAsync(FileName, $"[{DateTime.Now}]: {message}\n");

        Interlocked.Increment(ref _logCount);

        Console.WriteLine($"Logging: {message}");

        if (_logCount == _backupThreshold)
        {
            OnBackupRequired();

            _logCount = 0;
        }

        _waitHandle.Set();
    }

    /// <summary>
    /// Used to notify when to back up the log file.
    /// </summary>
    protected virtual void OnBackupRequired()
    {
        BackupRequired?.Invoke(this, new BackupEventArgs(FileName));
    }
}