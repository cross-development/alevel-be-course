using HW_2_4.Domains.Account.Abstractions;

namespace HW_2_4.Domains.Account;

/// <summary>
/// A base account.
/// </summary>
public abstract class Account : IAccount
{
    /// <summary>
    /// Gets an account number.
    /// </summary>
    public string AccountNumber { get; }

    /// <summary>
    /// Gets an account holder.
    /// </summary>
    public string Holder { get; }

    /// <summary>
    /// Gets or sets an account balance.
    /// </summary>
    public double Balance { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Account"/> class.
    /// </summary>
    /// <param name="holder">An account holder.</param>
    /// <param name="accountNumber">An account number.</param>
    protected Account(string holder, string accountNumber)
    {
        Balance = 0;
        Holder = holder;
        AccountNumber = accountNumber;
    }

    /// <summary>
    /// This method is used to deposit some money.
    /// </summary>
    /// <param name="amount">Amount of money.</param>
    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }

    /// <summary>
    /// This method is used to withdraw some money.
    /// </summary>
    /// <param name="amount">Amount of money.</param>
    public abstract void Withdraw(double amount);
}