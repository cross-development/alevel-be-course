using HW_2_4.Domains.Account.Abstractions;
using HW_2_4.Enums;

namespace HW_2_4.Repositories.Abstractions;

/// <summary>
/// ITransactionRepository interface.
/// </summary>
public interface ITransactionRepository
{
    /// <summary>
    /// This method is used to add a transaction to the transaction history.
    /// </summary>
    /// <param name="transactionType">A transaction type.</param>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    /// <param name="amount">A transaction amount.</param>
    public void AddTransaction(TransactionType transactionType, IAccount account, double amount);

    /// <summary>
    /// This method is used to show an account transaction history on the console.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    public void ShowAccountTransactionHistory(IAccount account);
}