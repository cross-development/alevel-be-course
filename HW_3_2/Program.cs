using System.Globalization;

namespace HW_3_2;

/// <summary>
/// Program entry point.
/// </summary>
internal class Program
{
    /// <summary>
    /// Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    private static void Main(string[] args)
    {
        PhoneBook phoneBook = new PhoneBook();

        Contact contact1 = new Contact { Name = "John Doe", PhoneNumber = "(206) 342-8631" };
        Contact contact2 = new Contact { Name = "Will Smith", PhoneNumber = "(717) 550-1675" };
        Contact contact3 = new Contact { Name = "Jenna Doe", PhoneNumber = "(248) 762-0356" };
        Contact contact4 = new Contact { Name = "#", PhoneNumber = "(212) 658-3916" };
        Contact contact5 = new Contact { Name = "1John Doe", PhoneNumber = "(209) 300-2557" };
        Contact contact6 = new Contact { Name = "Антон Марков", PhoneNumber = "(262) 162-1585" };
        Contact contact7 = new Contact { Name = "Петро Коваленко", PhoneNumber = "(252) 258-3799" };
        Contact contact8 = new Contact { Name = "Петро Орлов", PhoneNumber = "(234) 109-6666" };

        phoneBook.AddContact(contact1, CultureInfo.GetCultureInfo(LanguageCountryCode.UnitedStates));
        phoneBook.AddContact(contact2, CultureInfo.GetCultureInfo(LanguageCountryCode.UnitedStates));
        phoneBook.AddContact(contact3, CultureInfo.GetCultureInfo(LanguageCountryCode.UnitedStates));
        phoneBook.AddContact(contact4);
        phoneBook.AddContact(contact5);
        phoneBook.AddContact(contact6, CultureInfo.GetCultureInfo(LanguageCountryCode.Ukraine));
        phoneBook.AddContact(contact7, CultureInfo.GetCultureInfo(LanguageCountryCode.Ukraine));
        phoneBook.AddContact(contact8, CultureInfo.GetCultureInfo(LanguageCountryCode.Ukraine));

        CultureInfo selectedCulture = CultureInfo.GetCultureInfo(LanguageCountryCode.UnitedStates);
        List<Contact> selectedContacts = phoneBook.GetContactsByCulture(selectedCulture);

        Console.WriteLine($"Contacts in {selectedCulture.Name} group:");

        selectedContacts.ForEach(contact => Console.WriteLine($"Contact name: {contact.Name}, Phone number: {contact.PhoneNumber}"));

        Console.WriteLine("\nAll contacts in the phone book:");

        List<Contact> allContacts = phoneBook.GetAllContacts();
        allContacts.ForEach(contact => Console.WriteLine($"Contact name: {contact.Name}, Phone number: {contact.PhoneNumber}"));

        Console.ReadKey();
    }
}
