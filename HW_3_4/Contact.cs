namespace HW_3_4;

/// <summary>
/// This enum declares categories of a contact.
/// </summary>
public enum Category
{
    /// <summary>
    /// Category for contacts who are friends.
    /// </summary>
    Friend,

    /// <summary>
    /// Category for contacts who are coworkers.
    /// </summary>
    Work,

    /// <summary>
    /// Category for contacts who are relatives.
    /// </summary>
    Family,
}

/// <summary>
/// Contact class.
/// </summary>
public class Contact
{
    /// <summary>
    /// Gets or sets contact id.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets a contact name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets a contact phone number.
    /// </summary>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets a contact category.
    /// </summary>
    public required Category Category { get; set; }

    /// <summary>
    /// Gets or sets a contact company.
    /// </summary>
    public required string Company { get; set; }

    /// <summary>
    /// Overrides base method.
    /// </summary>
    /// <returns>String representation of a contact.</returns>
    public override string ToString()
    {
        return $"Contact id: {Id}, name: {Name}, category: {Category}, phone number: {PhoneNumber}";
    }
}