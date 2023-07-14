using HW_2_4.Domains.Account.Abstractions;
using HW_2_4.Enums;
using HW_2_4.Repositories.Abstractions;
using HW_2_4.Services.Abstractions;

namespace HW_2_4.Services;

/// <summary>
/// A transaction service.
/// </summary>
public sealed class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionService"/> class.
    /// </summary>
    /// <param name="transactionRepository">An implementation of the <see cref="ITransactionRepository"/> interface.</param>
    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    /// <summary>
    /// This method is used to add a transaction to the transaction history.
    /// </summary>
    /// <param name="transactionType">A transaction type.</param>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    /// <param name="amount">A transaction amount.</param>
    public void AddTransaction(TransactionType transactionType, IAccount account, double amount)
    {
        _transactionRepository.AddTransaction(transactionType, account, amount);
    }

    /// <summary>
    /// This method is used to show an account transaction history on the console.
    /// </summary>
    /// <param name="account">An implementation of the <see cref="IAccount"/> interface.</param>
    public void ShowAccountTransactionHistory(IAccount account)
    {
        _transactionRepository.ShowAccountTransactionHistory(account);
    }
}