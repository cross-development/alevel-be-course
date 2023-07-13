using System.Text;
using HW_2_4.Domains.Account;
using HW_2_4.Domains.Account.Abstractions;
using HW_2_4.Enums;
using HW_2_4.Factories.Abstractions;
using HW_2_4.Services.Abstractions;

namespace HW_2_4.Services;

/// <summary>
/// An account service.
/// </summary>
public sealed class AccountService : IAccountService
{
    private readonly IAccountFactory _accountFactory;
    private readonly ITransactionService _transactionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountService"/> class.
    /// </summary>
    /// <param name="accountFactory">An implementation of the <see cref="IAccountFactory"/> interface.</param>
    /// <param name="transactionService">An implementation of the <see cref="ITransactionService"/> interface.</param>
    public AccountService(IAccountFactory accountFactory, ITransactionService transactionService)
    {
        _accountFactory = accountFactory;
        _transactionService = transactionService;
    }

    /// <summary>
    /// This method is used to open an account.
    /// </summary>
    /// <param name="accountType">An account type.</param>
    /// <param name="holder">An account holder.</param>
    /// <returns>The instance of the <see cref="Account"/> class.</returns>
    public IAccount OpenAccount(AccountType accountType, string holder)
    {
        string accountNumber = GenerateAccountNumber();

        return _accountFactory.CreateAccount(accountType, holder, accountNumber);
    }

    /// <summary>
    /// This method is used to show an account balance.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    public void ShowAccountDetails(IAccount account)
    {
        Console.WriteLine("Account details:");
        Console.WriteLine($"- holder: {account.Holder}");
        Console.WriteLine($"- number: {account.AccountNumber}");
        Console.WriteLine($"- balance: {account.Balance:N2}$");
        Console.WriteLine();
    }

    /// <summary>
    /// This method is used to show an account transaction history on the console.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    public void ShowAccountTransactionHistory(IAccount account)
    {
        _transactionService.ShowAccountTransactionHistory(account);
    }

    /// <summary>
    /// This method is used to deposit some money.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    /// <param name="amount">Amount of money.</param>
    public void Deposit(IAccount account, double amount)
    {
        account.Deposit(amount);
        _transactionService.AddTransaction(TransactionType.Deposit, account, amount);
    }

    /// <summary>
    /// This method is used to withdraw some money.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    /// <param name="amount">Amount of money.</param>
    public void Withdraw(IAccount account, double amount)
    {
        account.Withdraw(amount);
        _transactionService.AddTransaction(TransactionType.Withdraw, account, amount);
    }

    /// <summary>
    /// This method is used to generate an account number.
    /// </summary>
    /// <returns>An account number.</returns>
    private string GenerateAccountNumber()
    {
        // IBAN number length
        byte accountNumberLength = 29;

        Random random = new Random();
        StringBuilder accountNumber = new StringBuilder("UA");

        for (int i = 0; i < accountNumberLength; i++)
        {
            accountNumber.Append(random.Next(0, 10).ToString());
        }

        return accountNumber.ToString();
    }
}