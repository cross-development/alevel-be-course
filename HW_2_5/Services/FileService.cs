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
    private readonly FileOption _fileOptions;
    private readonly string _fileName;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileService"/> class.
    /// </summary>
    /// <param name="fileOptions">The instance of the <see cref="FileOption"/> class.</param>
    public FileService(IOptions<FileOption> fileOptions)
    {
        _fileOptions = fileOptions.Value;
        _fileName = $"{DateTime.Now:MM-dd-yyyy-hh-mm-ss-fff}.json";
    }

    /// <summary>
    /// This method is used to write some content to a file.
    /// </summary>
    /// <param name="logType">Log types which are described in the <see cref="LogType"/> enum.</param>
    /// <param name="content">Some content to write to a file.</param>
    public void WriteToFile(LogType logType, string content)
    {
        if (!Directory.Exists(_fileOptions.Path))
        {
            Directory.CreateDirectory(_fileOptions.Path);
        }

        string filePath = Path.Combine(_fileOptions.Path, _fileName);

        FileInfo fileInfo = new FileInfo(filePath);

        if (!fileInfo.Exists)
        {
            using (fileInfo.Create())
            {
            }

            LogRecord logRecord = new LogRecord();
            logRecord[logType] = logRecord[logType].Append(content).ToArray();

            SerializeData(filePath, logRecord);
        }
        else
        {
            LogRecord deserializedLogRecord = DeserializeData(filePath);
            deserializedLogRecord[logType] = deserializedLogRecord[logType].Append(content).ToArray();

            SerializeData(filePath, deserializedLogRecord);
        }
    }

    /// <summary>
    /// This method is used to delete oldest file.
    /// </summary>
    /// <param name="maxFileCount">Max number of files after which the oldest file will be deleted.</param>
    public void DeleteOldestFile(int maxFileCount)
    {
        string[] files = Directory.GetFiles(_fileOptions.Path);

        if (files.Length > maxFileCount)
        {
            string oldestFile = files.OrderBy(file => new FileInfo(file).CreationTime).First();

            File.Delete(oldestFile);
        }
    }

    /// <summary>
    /// This method is used to deserialize json.
    /// </summary>
    /// <param name="filePath">A path to the file you need to deserialize.</param>
    /// <returns>The instance of the <see cref="LogRecord"/> class.</returns>
    private LogRecord DeserializeData(string filePath)
    {
        string jsonTextContent = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<LogRecord>(jsonTextContent)!;
    }

    /// <summary>
    /// This method is used to serialize json.
    /// </summary>
    /// <param name="filePath">A path to the file you need to serialize.</param>
    /// <param name="logRecord">The instance of the <see cref="LogRecord"/> class data to serialize.</param>
    private void SerializeData(string filePath, LogRecord logRecord)
    {
        string jsonContent = JsonSerializer.Serialize(logRecord, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(filePath, jsonContent);
    }
}