namespace HW_3_2;

/// <summary>
/// Contact Model for the contact record in the phone book.
/// </summary>
public sealed class Contact
{
    /// <summary>
    /// Gets or sets the name of the contact.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the contact.
    /// </summary>
    public required string PhoneNumber { get; set; }
}