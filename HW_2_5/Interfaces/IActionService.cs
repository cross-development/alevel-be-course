namespace HW_2_5.Interfaces;

/// <summary>
/// IActionService interface.
/// </summary>
public interface IActionService
{
    /// <summary>
    /// This method logs an info type message.
    /// </summary>
    public void CallInfoAction();

    /// <summary>
    /// This method logs a warning type message.
    /// </summary>
    public void CallWarningAction();

    /// <summary>
    /// This method logs an error type message.
    /// </summary>
    public void CallErrorAction();
}