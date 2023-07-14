using HW_2_4.Domains.Account.Abstractions;
using HW_2_4.Enums;
using HW_2_4.Models;
using HW_2_4.Models.Abstractions;
using HW_2_4.Repositories.Abstractions;

namespace HW_2_4.Repositories;

/// <summary>
/// A transaction repository.
/// </summary>
public sealed class TransactionRepository : ITransactionRepository
{
    /// <summary>
    /// A mock transaction storage.
    /// </summary>
    private ITransaction[] _transactions = Array.Empty<ITransaction>();

    /// <summary>
    /// This method is used to add a transaction to the transaction history.
    /// </summary>
    /// <param name="transactionType">A transaction type.</param>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    /// <param name="amount">A transaction amount.</param>
    public void AddTransaction(TransactionType transactionType, IAccount account, double amount)
    {
        Array.Resize(ref _transactions, _transactions.Length + 1);
        _transactions[^1] = new Transaction
        {
            Id = Guid.NewGuid(),
            Type = transactionType,
            Date = DateTime.Now,
            Amount = amount,
            AccountNumber = account.AccountNumber,
            AccountHolder = account.Holder
        };
    }

    /// <summary>
    /// This method is used to show an account transaction history on the console.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    public void ShowAccountTransactionHistory(IAccount account)
    {
        foreach (ITransaction transaction in _transactions)
        {
            if (transaction.AccountNumber == account.AccountNumber)
            {
                Console.WriteLine($"{transaction.Date}: " +
                                  $"transaction {transaction.Id}, " +
                                  $"type {transaction.Type}, " +
                                  $"amount {transaction.Amount:N2}$, " +
                                  $"account holder {transaction.AccountHolder}");
            }
        }
    }
}