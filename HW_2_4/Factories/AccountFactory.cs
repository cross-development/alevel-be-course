using HW_2_4.Domains.Account;
using HW_2_4.Domains.Account.Abstractions;
using HW_2_4.Enums;
using HW_2_4.Factories.Abstractions;

namespace HW_2_4.Factories;

/// <summary>
/// An account factory.
/// </summary>
public sealed class AccountFactory : IAccountFactory
{
    /// <summary>
    /// This method is used to create a new account by the account type.
    /// </summary>
    /// <param name="accountType">An account type.</param>
    /// <param name="holder">An account holder.</param>
    /// <param name="accountNumber">An account number.</param>
    /// <returns>The instance of the <see cref="Account"/> class.</returns>
    /// <exception cref="ArgumentException">The instance of the <see cref="ArgumentException"/> class.</exception>
    public IAccount CreateAccount(AccountType accountType, string holder, string accountNumber)
    {
        return accountType switch
        {
            AccountType.Savings => new SavingsAccount(holder, accountNumber),
            AccountType.Checking => new CheckingAccount(holder, accountNumber),
            _ => throw new ArgumentException("Invalid account type"),
        };
    }
}