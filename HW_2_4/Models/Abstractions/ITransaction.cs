using HW_2_4.Enums;

namespace HW_2_4.Models.Abstractions;

/// <summary>
/// ITransaction interface.
/// </summary>
public interface ITransaction
{
    /// <summary>
    /// Gets or sets a transaction id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a transaction type.
    /// </summary>
    public TransactionType Type { get; set; }

    /// <summary>
    /// Gets or sets a transaction amount.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Gets or sets a transaction date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets an account number.
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets an account holder.
    /// </summary>
    public string AccountHolder { get; set; }
}