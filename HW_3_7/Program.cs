using Newtonsoft.Json;

namespace HW_3_7;

/// <summary>
/// Program entry point.
/// </summary>
internal class Program
{
    /// <summary>
    /// Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    private static async Task Main(string[] args)
    {
        var config = await File.ReadAllTextAsync("config.json");

        var backupConfig = JsonConvert.DeserializeObject<Config>(config);
        var backupThreshold = backupConfig?.BackupThreshold ?? 0;

        var logger = new Logger(backupThreshold);

        var app = new App(logger);

        await app.StartAsync();
    }
}
