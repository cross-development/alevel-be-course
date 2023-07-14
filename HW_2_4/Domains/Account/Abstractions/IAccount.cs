namespace HW_2_4.Domains.Account.Abstractions;

/// <summary>
/// ITransaction interface.
/// </summary>
public interface IAccount
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
    /// Gets an account balance.
    /// </summary>
    public double Balance { get; }

    /// <summary>
    /// This method is used to deposit some money.
    /// </summary>
    /// <param name="amount">Amount of money.</param>
    public void Deposit(double amount);

    /// <summary>
    /// This method is used to withdraw some money.
    /// </summary>
    /// <param name="amount">Amount of money.</param>
    public void Withdraw(double amount);
}