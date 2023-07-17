using HW_2_5.Enums;

namespace HW_2_5.Interfaces;

/// <summary>
/// IFileService interface.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// This method is used to write some content to a file.
    /// </summary>
    /// <param name="logType">Log types which are described in the <see cref="LogType"/> enum.</param>
    /// <param name="content">Some content to write to a file.</param>
    public void WriteToFile(LogType logType, string content);

    /// <summary>
    /// This method is used to delete oldest file.
    /// </summary>
    /// <param name="maxFileCount">Max number of files after which the oldest file will be deleted.</param>
    public void DeleteOldestFile(int maxFileCount);
}