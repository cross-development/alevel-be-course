namespace HW_2_1;

/// <summary>
/// A class with the info, warning, and error actions.
/// </summary>
internal class Actions
{
    private readonly Logger _logger;

    public Actions(Logger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// This method logs an info type message.
    /// </summary>
    /// <returns>
    /// An instance of the Result class. The instance has the Status property, which in this case is True.
    /// </returns>
    public Result CallInfoAction()
    {
        _logger.Log(LogType.Info, $"Start method: {nameof(CallInfoAction)}");

        return new Result { Status = true };
    }

    /// <summary>
    /// This method logs a warning type message.
    /// </summary>
    /// <returns>
    /// An instance of the Result class. The instance has the Status property, which in this case is True.
    /// </returns>
    public Result CallWarningAction()
    {
        _logger.Log(LogType.Warning, $"Skipped logic in method: {nameof(CallWarningAction)}");

        return new Result { Status = true };
    }

    /// <summary>
    /// This method logs does not log anything. It allows you to determine the error message in the calling code yourself.
    /// </summary>
    /// <returns>
    /// An instance of the Result class. The instance has two properties: Status, which is False, and Error, which is a default error message.
    /// </returns>
    public Result CallErrorAction()
    {
        return new Result { Status = false, Error = "I broke a logic" };
    }
}
