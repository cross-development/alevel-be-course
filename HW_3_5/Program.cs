namespace HW_3_5;

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
        string result = await ReadAndConcatenateAsync();

        Console.WriteLine(result);
    }

    /// <summary>
    /// Used to read file asynchronously.
    /// </summary>
    /// <param name="fileName">A file name to read.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private static async Task<string> ReadAsync(string fileName)
    {
        using StreamReader reader = new StreamReader(fileName);

        return await reader.ReadToEndAsync();
    }

    /// <summary>
    /// Used to read files and contact their results.
    /// </summary>
    /// <returns>The string result of concatenating two files.</returns>
    private static async Task<string> ReadAndConcatenateAsync()
    {
        Task<string> readHelloTask = ReadAsync("Hello.txt");
        Task<string> readWorldTask = ReadAsync("World.txt");

        await Task.WhenAll(readHelloTask, readWorldTask);

        string helloText = readHelloTask.Result;
        string worldText = readWorldTask.Result;

        return $"{helloText} {worldText}";
    }
}
