using System.Text.Json.Serialization;
using HW_2_5.Enums;

namespace HW_2_5.Models;

/// <summary>
/// LogRecord class.
/// </summary>
public sealed class LogRecord
{
    /// <summary>
    /// Gets or sets information logs.
    /// </summary>
    public string[] Info { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Gets or sets warning logs.
    /// </summary>
    public string[] Warning { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Gets or sets error logs.
    /// </summary>
    public string[] Error { get; set; } = Array.Empty<string>();

    /// <summary>
    /// This indexer is used to get or set logs by the log types.
    /// </summary>
    /// <param name="logType">Log types which are described in the <see cref="LogType"/> enum.</param>
    /// <returns>Array of logs by log type.</returns>
    [JsonIgnore]
    public string[] this[LogType logType]
    {
        get
        {
            return logType switch
            {
                LogType.Info => Info,
                LogType.Warning => Warning,
                LogType.Error => Error,
                _ => throw new ArgumentOutOfRangeException(nameof(logType), logType, "Unknown Log Type"),
            };
        }

        set
        {
            switch (logType)
            {
                case LogType.Info:
                    Info = value;
                    break;
                case LogType.Warning:
                    Warning = value;
                    break;
                case LogType.Error:
                    Error = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, "Unknown Log Type");
            }
        }
    }
}