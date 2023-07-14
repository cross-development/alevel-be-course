namespace HW_2_4.Domains.Account;

/// <summary>
/// A checking account.
/// </summary>
public sealed class CheckingAccount : Account
{
    /// <summary>
    /// An account overdraft limit.
    /// </summary>
    private readonly double _overdraftLimit = -100;

    /// <summary>
    /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
    /// </summary>
    /// <param name="holder">An account holder.</param>
    /// <param name="accountNumber">An account number.</param>
    public CheckingAccount(string holder, string accountNumber)
        : base(holder, accountNumber)
    {
    }

    /// <summary>
    /// This method is used to withdraw some money.
    /// </summary>
    /// <param name="amount">Amount of money.</param>
    public override void Withdraw(double amount)
    {
        if (Balance >= _overdraftLimit)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine($"Overdraft limit has been reached. You overdraft limit is {_overdraftLimit}");
        }
    }
}