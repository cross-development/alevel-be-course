using HW_2_4.Domains.Account;
using HW_2_4.Domains.Account.Abstractions;
using HW_2_4.Enums;

namespace HW_2_4.Services.Abstractions;

/// <summary>
/// IAccountService interface.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// This method is used to open an account.
    /// </summary>
    /// <param name="accountType">An account type.</param>
    /// <param name="holder">An account holder.</param>
    /// <returns>The instance of the <see cref="Account"/> class.</returns>
    public IAccount OpenAccount(AccountType accountType, string holder);

    /// <summary>
    /// This method is used to show an account balance.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    public void ShowAccountDetails(IAccount account);

    /// <summary>
    /// This method is used to show an account transaction history on the console.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    public void ShowAccountTransactionHistory(IAccount account);

    /// <summary>
    /// This method is used to deposit some money.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    /// <param name="amount">Amount of money.</param>
    public void Deposit(IAccount account, double amount);

    /// <summary>
    /// This method is used to withdraw some money.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    /// <param name="amount">Amount of money.</param>
    public void Withdraw(IAccount account, double amount);
}