using HW_2_4.Domains.Account.Abstractions;
using HW_2_4.Enums;
using HW_2_4.Services.Abstractions;

namespace HW_2_4;

/// <summary>
/// Application entry point.
/// </summary>
public sealed class Application
{
    private readonly IAccountService _accountService;

    /// <summary>
    /// Initializes a new instance of the <see cref="Application"/> class.
    /// </summary>
    /// <param name="accountService">An implementation of the <see cref="IAccountService"/> interface.</param>
    public Application(IAccountService accountService)
    {
        _accountService = accountService;
    }

    /// <summary>
    /// Application entry method.
    /// </summary>
    public void Run()
    {
        IAccount savingsAccount = _accountService.OpenAccount(AccountType.Savings, "User1");

        _accountService.Deposit(savingsAccount, 1000);
        _accountService.Deposit(savingsAccount, 1000);
        _accountService.Withdraw(savingsAccount, 500);

        _accountService.ShowAccountDetails(savingsAccount);
        _accountService.ShowAccountTransactionHistory(savingsAccount);

        Console.WriteLine();

        IAccount checkingAccount = _accountService.OpenAccount(AccountType.Checking, "User2");

        _accountService.Deposit(checkingAccount, 2000);
        _accountService.Deposit(checkingAccount, 1000);
        _accountService.Withdraw(checkingAccount, 500);

        _accountService.ShowAccountDetails(checkingAccount);
        _accountService.ShowAccountTransactionHistory(checkingAccount);

        Console.ReadKey();
    }
}