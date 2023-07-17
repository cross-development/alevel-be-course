using HW_2_5.Enums;
using HW_2_5.Exceptions;
using HW_2_5.Interfaces;

namespace HW_2_5;

/// <summary>
/// Application entry point.
/// </summary>
public class App
{
    private readonly Random _random;
    private readonly IActionService _actionService;
    private readonly ILoggerService _loggerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="actionService">The implementation of the <see cref="IActionService"/> interface.</param>
    /// <param name="loggerService">The implementation of the <see cref="ILoggerService"/> interface.</param>
    public App(IActionService actionService, ILoggerService loggerService)
    {
        _random = new Random();
        _actionService = actionService;
        _loggerService = loggerService;
    }

    /// <summary>
    /// Application entry method.
    /// </summary>
    public void Run()
    {
        for (int i = 0; i <= 100; i++)
        {
            int randomMethodNumber = _random.Next(1, 4);

            try
            {
                switch (randomMethodNumber)
                {
                    case 1:
                        {
                            _actionService.CallInfoAction();
                            break;
                        }

                    case 2:
                        {
                            _actionService.CallWarningAction();
                            break;
                        }

                    case 3:
                        {
                            _actionService.CallErrorAction();
                            break;
                        }

                    default:
                        {
                            throw new InvalidOperationException("Invalid random method number");
                        }
                }
            }
            catch (BusinessException e)
            {
                _loggerService.Log(LogType.Warning, $"Action got this custom Exception: {e.Message}");
            }
            catch (Exception e)
            {
                _loggerService.Log(LogType.Error, $"Action failed by reason: {e.Message}");
            }
        }

        Console.ReadKey();
    }
}