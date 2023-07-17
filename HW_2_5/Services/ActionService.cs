using HW_2_5.Enums;
using HW_2_5.Exceptions;
using HW_2_5.Interfaces;

namespace HW_2_5.Services;

/// <summary>
/// ActionService class.
/// </summary>
public sealed class ActionService : IActionService
{
    private readonly ILoggerService _loggerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ActionService"/> class.
    /// </summary>
    /// <param name="loggerService">The implementation of the <see cref="ILoggerService"/> interface.</param>
    public ActionService(ILoggerService loggerService)
    {
        _loggerService = loggerService;
    }

    /// <summary>
    /// This method is used to call an info action.
    /// </summary>
    public void CallInfoAction()
    {
        _loggerService.Log(LogType.Info, $"Start method: {nameof(CallInfoAction)}");
    }

    /// <summary>
    /// This method is used to call a warning action.
    /// </summary>
    /// <exception cref="BusinessException">The instance of the <see cref="BusinessException"/> class.</exception>
    public void CallWarningAction()
    {
        throw new BusinessException("Skipped logic in method.");
    }

    /// <summary>
    /// This method is used to call an error action.
    /// </summary>
    /// <exception cref="Exception">The instance of the <see cref="Exception"/> class.</exception>
    public void CallErrorAction()
    {
        throw new Exception("I broke a logic.");
    }
}