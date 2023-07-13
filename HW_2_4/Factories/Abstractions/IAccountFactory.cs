using HW_2_4.Domains.Account;
using HW_2_4.Domains.Account.Abstractions;
using HW_2_4.Enums;

namespace HW_2_4.Factories.Abstractions;

/// <summary>
/// IAccountFactory interface.
/// </summary>
public interface IAccountFactory
{
    /// <summary>
    /// This method is used to create a new account by the account type.
    /// </summary>
    /// <param name="accountType">An account type.</param>
    /// <param name="holder">An account holder.</param>
    /// <param name="accountNumber">An account number.</param>
    /// <returns>The instance of the <see cref="Account"/> class.</returns>
    public IAccount CreateAccount(AccountType accountType, string holder, string accountNumber);
}