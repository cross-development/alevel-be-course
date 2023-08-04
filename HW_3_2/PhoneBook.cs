using System.Globalization;

namespace HW_3_2;

/// <summary>
/// The phone book class which is stored the contacts.
/// </summary>
public sealed class PhoneBook
{
    private readonly Dictionary<CultureInfo, SortedDictionary<string, List<Contact>>> _contacts;

    /// <summary>
    /// Initializes a new instance of the <see cref="PhoneBook"/> class.
    /// </summary>
    public PhoneBook()
    {
        _contacts = new Dictionary<CultureInfo, SortedDictionary<string, List<Contact>>>();
    }

    /// <summary>
    /// This method is used to add contact to the phone book.
    /// </summary>
    /// <param name="contact">Contact to add <see cref="Contact"/>.</param>
    /// <param name="cultureInfo">Culture info <see cref="CultureInfo"/>. Default culture: English.</param>
    public void AddContact(Contact contact, CultureInfo? cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.GetCultureInfo(LanguageCountryCode.UnitedStates);

        if (!_contacts.ContainsKey(cultureInfo))
        {
            IComparer<string> alphabet = GetAlphabetByCulture(cultureInfo);
            _contacts[cultureInfo] = new SortedDictionary<string, List<Contact>>(alphabet);
        }

        string groupName = GetContactsGroupName(contact, cultureInfo);

        if (!_contacts[cultureInfo].TryGetValue(groupName, out var contacts))
        {
            contacts = new List<Contact>();
            _contacts[cultureInfo][groupName] = contacts;
        }

        contacts.Add(contact);
    }

    /// <summary>
    /// This method is used to get all contacts in the phone book.
    /// </summary>
    /// <returns>The list of contacts in the phone book.</returns>
    public List<Contact> GetAllContacts()
    {
        return _contacts.Values
            .SelectMany(dictionary => dictionary.Values)
            .SelectMany(list => list)
            .ToList();
    }

    /// <summary>
    /// This method is used to get all contacts in the phone book.
    /// </summary>
    /// <param name="cultureInfo">Culture info <see cref="CultureInfo"/>.</param>
    /// <returns>The list of contacts in the phone book.</returns>
    public List<Contact> GetContactsByCulture(CultureInfo cultureInfo)
    {
        if (!_contacts.ContainsKey(cultureInfo))
        {
            return new List<Contact>();
        }

        var contacts = _contacts[cultureInfo]
            .SelectMany(kv => kv.Value)
            .ToList();

        return contacts;
    }

    /// <summary>
    /// This method is used to get alphabet for the culture.
    /// </summary>
    /// <param name="cultureInfo">Culture info <see cref="CultureInfo"/>.</param>
    /// <returns>The string comparer <see cref="StringComparer"/>.</returns>
    private IComparer<string> GetAlphabetByCulture(CultureInfo cultureInfo)
    {
        return cultureInfo.Name == LanguageCountryCode.Ukraine ?
            StringComparer.Create(cultureInfo, true) :
            StringComparer.InvariantCultureIgnoreCase;
    }

    /// <summary>
    /// This method is used to get contact's group name using culture info.
    /// </summary>
    /// <param name="contact">Contact to add <see cref="Contact"/>.</param>
    /// <param name="cultureInfo">Culture info <see cref="CultureInfo"/>.</param>
    /// <returns>The contact group.</returns>
    private string GetContactsGroupName(Contact contact, CultureInfo cultureInfo)
    {
        string alphabet = contact.Name.Trim().Substring(0, 1);

        if (char.IsDigit(alphabet[0]))
        {
            return "0-9";
        }

        return !alphabet.StartsWith("#") ? alphabet.ToUpper(cultureInfo) : "#";
    }
}