using HW_2_4.Enums;
using HW_2_4.Models.Abstractions;

namespace HW_2_4.Models;

/// <summary>
/// A transaction model.
/// </summary>
public sealed class Transaction : ITransaction
{
    /// <summary>
    /// Gets or sets a transaction id.
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a transaction type.
    /// </summary>
    public TransactionType Type { get; set; }

    /// <summary>
    /// Gets or sets a transaction amount.
    /// </summary>
    public required double Amount { get; set; }

    /// <summary>
    /// Gets or sets a transaction date.
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets an account number.
    /// </summary>
    public required string AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets an account holder.
    /// </summary>
    public required string AccountHolder { get; set; }
}