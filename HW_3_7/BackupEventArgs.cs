namespace HW_3_7;

/// <summary>
/// Backup event args class.
/// </summary>
public class BackupEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BackupEventArgs"/> class.
    /// </summary>
    /// <param name="fileName">A name of the log file.</param>
    public BackupEventArgs(string fileName)
    {
        FileName = fileName;
    }

    /// <summary>
    /// Gets or sets a name of the log file.
    /// </summary>
    public string FileName { get; set; }
}