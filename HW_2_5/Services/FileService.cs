using System.Text.Json;
using HW_2_5.Configs;
using HW_2_5.Enums;
using HW_2_5.Interfaces;
using HW_2_5.Models;
using Microsoft.Extensions.Options;

namespace HW_2_5.Services;

/// <summary>
/// FileService class.
/// </summary>
public sealed class FileService : IFileService
{
    private readonly string _fileName;
    private readonly FileOption _fileOptions;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileService"/> class.
    /// </summary>
    /// <param name="fileOptions">The instance of the <see cref="FileOption"/> class.</param>
    public FileService(IOptions<FileOption> fileOptions)
    {
        _fileOptions = fileOptions.Value;
        _fileName = $"{DateTime.Now:MM-dd-yyyy-hh-mm-ss-fff}.json";
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    /// <summary>
    /// This method is used to write some content to a file.
    /// </summary>
    /// <param name="logType">Log types which are described in the <see cref="LogType"/> enum.</param>
    /// <param name="content">Some content to write to a file.</param>
    public void WriteToFile(LogType logType, string content)
    {
        CreateDirectory(_fileOptions.Path);

        string filePath = Path.Combine(_fileOptions.Path, _fileName);

        FileInfo fileInfo = new FileInfo(filePath);

        LogRecord? logRecord;

        if (!fileInfo.Exists)
        {
            fileInfo.Create().Close();

            logRecord = new LogRecord();
        }
        else
        {
            logRecord = DeserializeData(filePath);
        }

        if (logRecord != null)
        {
            logRecord[logType] = logRecord[logType].Append(content).ToArray();

            SerializeData(filePath, logRecord);
        }
    }

    /// <summary>
    /// This method is used to delete oldest file.
    /// </summary>
    /// <param name="maxFileCount">Max number of files after which the oldest file will be deleted.</param>
    public void DeleteOldestFile(int maxFileCount)
    {
        string[] files = Directory.GetFiles(_fileOptions.Path);

        if (files.Length <= maxFileCount)
        {
            return;
        }

        string oldestFile = files.OrderBy(file => new FileInfo(file).CreationTime).First();

        File.Delete(oldestFile);
    }

    /// <summary>
    /// This method is used to create directory to store log files.
    /// </summary>
    /// <param name="path">Directory path.</param>
    private void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    /// <summary>
    /// This method is used to deserialize json.
    /// </summary>
    /// <param name="filePath">A path to the file you need to deserialize.</param>
    /// <returns>The instance of the <see cref="LogRecord"/> class.</returns>
    private LogRecord? DeserializeData(string filePath)
    {
        string jsonTextContent = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<LogRecord>(jsonTextContent);
    }

    /// <summary>
    /// This method is used to serialize json.
    /// </summary>
    /// <param name="filePath">A path to the file you need to serialize.</param>
    /// <param name="logRecord">The instance of the <see cref="LogRecord"/> class data to serialize.</param>
    private void SerializeData(string filePath, LogRecord logRecord)
    {
        string jsonContent = JsonSerializer.Serialize(logRecord, _jsonSerializerOptions);

        File.WriteAllText(filePath, jsonContent);
    }
}