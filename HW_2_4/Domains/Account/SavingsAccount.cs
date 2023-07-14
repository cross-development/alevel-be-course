namespace HW_2_4.Domains.Account;

/// <summary>
/// A savings account.
/// </summary>
public sealed class SavingsAccount : Account
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
    /// </summary>
    /// <param name="holder">An account holder.</param>
    /// <param name="accountNumber">An account number.</param>
    public SavingsAccount(string holder, string accountNumber)
        : base(holder, accountNumber)
    {
    }

    /// <summary>
    /// This method is used to withdraw some money.
    /// </summary>
    /// <param name="amount">Amount of money.</param>
    public override void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds");
        }
    }
}