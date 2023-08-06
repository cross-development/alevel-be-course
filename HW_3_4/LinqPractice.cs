using System.Linq;

namespace HW_3_4;

/// <summary>
/// LinqPractice class.
/// </summary>
public static class LinqPractice
{
    /// <summary>
    /// Runs linq methods.
    /// </summary>
    public static void RunLinqMethods()
    {
        List<Contact> contacts1 = new List<Contact>
        {
            new() { Id = 1, Name = "Contact1 1", Category = Category.Family, PhoneNumber = "+1 (724) 620-4308", Company = "Company 1" },
            new() { Id = 2, Name = "Contact1 2", Category = Category.Family, PhoneNumber = "+2 (902) 166-4423", Company = "Company 2" },
            new() { Id = 3, Name = "Contact1 3", Category = Category.Work, PhoneNumber = "+3 (303) 715-9271", Company = "Company 3" },
            new() { Id = 4, Name = "Contact1 4", Category = Category.Friend, PhoneNumber = "+3 (854) 837-4201", Company = "Company 1" },
            new() { Id = 5, Name = "Contact1 5", Category = Category.Friend, PhoneNumber = "+3 (458) 543-1061", Company = "Company 2" },
        };

        List<Contact> contacts2 = new List<Contact>
        {
            new() { Id = 1, Name = "Contact2 1", Category = Category.Friend, PhoneNumber = "+4 (530) 693-7148", Company = "Company 2" },
            new() { Id = 2, Name = "Contact2 2", Category = Category.Friend, PhoneNumber = "+4 (539) 106-8110", Company = "Company 3" },
            new() { Id = 3, Name = "Contact2 3", Category = Category.Work, PhoneNumber = "+3 (581) 516-8408", Company = "Company 3" },
            new() { Id = 4, Name = "Contact2 4", Category = Category.Work, PhoneNumber = "+2 (801) 797-1177", Company = "Company 1" },
            new() { Id = 5, Name = "Contact2 5", Category = Category.Family, PhoneNumber = "+3 (430) 406-6369", Company = "Company 1" },
        };

        List<Company> companies = new List<Company>
        {
            new() { Title = "Company 1", Location = "Location 1" },
            new() { Title = "Company 2", Location = "Location 2" },
            new() { Title = "Company 3", Location = "Location 3" },
        };

        // Boolean result
        LinqAny(contacts1);
        LinqAll(contacts1);
        LinqContains(contacts1);

        // Non-scalar result
        LinqFirstOrDefault(contacts1);
        LinqLastOrDefault(contacts1);

        // Grouping is needed
        LinqGroupBy(contacts1);
        LinqGroupJoin(contacts1, companies);

        // Order is important
        LinqOrderBy(contacts1);
        LinqOrderByDescending(contacts1);
        LinqThenBy(contacts1);
        LinqThenByDescending(contacts1);

        // Conditions
        LinqWhere(contacts1);
        LinqSkip(contacts1);
        LinqSkipWhile(contacts1);
        LinqTake(contacts1);
        LinqTakeWhile(contacts1);

        // Projections / Merging
        LinqSelect(contacts1);
        LinqJoin(contacts1, companies);
        LinqZip(contacts1, companies);

        // Operations with Set
        LinqConcat(contacts1, contacts2);
        LinqUnion(contacts1, contacts2);
    }

    private static void IterateThroughCollection<T>(List<T> items)
    {
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }

    private static void LinqAny(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ Any method ********");
        Console.WriteLine("Does any contact phone number start with +1?");

        bool result = contacts.Any(c => c.PhoneNumber.StartsWith("+1"));

        Console.WriteLine($"Answer: {result}\n");
    }

    private static void LinqAll(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ All method ********");
        Console.WriteLine("Are all contacts categorized as family phones?");

        bool result = contacts.All(c => c.Category == Category.Family);

        Console.WriteLine($"Answer: {result}\n");
    }

    private static void LinqContains(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ Contains method ********");
        Console.WriteLine("Does the phone book contain specific contact (name = Toy Lowe, category = friend, number = +3 (854) 837-4201)?");

        bool result = contacts.Contains(contacts[0]);

        Console.WriteLine($"Answer: {result}\n");
    }

    private static void LinqFirstOrDefault(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ FirstOrDefault method ********");
        Console.WriteLine("The first element of the contact list is:");

        Contact? result = contacts.FirstOrDefault(c => c.Id == 1);

        Console.WriteLine($"{result}\n");
    }

    private static void LinqLastOrDefault(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ LastOrDefault method ********");
        Console.WriteLine("The last element of the contact list is:");

        Contact? result = contacts.LastOrDefault(c => c.Category == Category.Family);

        Console.WriteLine($"{result}\n");
    }

    private static void LinqGroupBy(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ GroupBy method ********");

        IList<IGrouping<Category, Contact>> result = contacts.GroupBy(c => c.Category).ToList();

        foreach (IGrouping<Category, Contact> category in result)
        {
            Console.WriteLine($"Category: {category.Key}");

            foreach (Contact contact in category)
            {
                Console.WriteLine(contact);
            }
        }

        Console.WriteLine();
    }

    private static void LinqGroupJoin(List<Contact> contacts, List<Company> companies)
    {
        Console.WriteLine("******** LINQ GroupJoin method ********");
        Console.WriteLine("Use group join to join two lists:");

        var result = companies.GroupJoin(
            contacts,
            company => company.Title,
            contact => contact.Company,
            (company, employees) => new { Title = company.Title, Employees = employees })
            .ToList();

        foreach (var company in result)
        {
            Console.Write($"{company.Title}: \t");

            foreach (var emp in company.Employees)
            {
                Console.Write($"{emp.Name}, ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static void LinqOrderBy(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ OrderBy method ********");
        Console.WriteLine("Contacts are ordered by their name (by asc):");

        List<Contact> result = contacts.OrderBy(c => c.Name).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqOrderByDescending(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ OrderByDescending method ********");
        Console.WriteLine("Contacts are ordered by their phone number (by desc):");

        List<Contact> result = contacts.OrderByDescending(c => c.PhoneNumber).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqThenBy(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ ThenBy method ********");
        Console.WriteLine("Contacts are ordered by their name (by asc) then by their category (by asc):");

        List<Contact> result = contacts
            .OrderBy(c => c.Name)
            .ThenBy(c => c.Category)
            .ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqThenByDescending(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ ThenByDescending method ********");
        Console.WriteLine("Contacts are ordered by their name (by desc) then by their phone numbers (by desc):");

        List<Contact> result = contacts
            .OrderByDescending(c => c.Name)
            .ThenByDescending(c => c.PhoneNumber)
            .ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqWhere(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ ThenByDescending method ********");
        Console.WriteLine("Contacts are filtered by category = family:");

        List<Contact> result = contacts.Where(c => c.Category == Category.Friend).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqSkip(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ Skip method ********");
        Console.WriteLine("The first 2 contacts are skipped (starts from id=3):");

        List<Contact> result = contacts.Skip(2).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqSkipWhile(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ SkipWhile method ********");
        Console.WriteLine("Skip contacts until the phone number starts with +3 (starts from id=4):");

        List<Contact> result = contacts.SkipWhile(c => !c.PhoneNumber.StartsWith("+3")).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqTake(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ Take method ********");
        Console.WriteLine("Take the first 3 contacts:");

        List<Contact> result = contacts.Take(3).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqTakeWhile(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ TakeWhile method ********");
        Console.WriteLine("Take contacts until the contact id is less than 5:");

        List<Contact> result = contacts.TakeWhile(c => c.Id < 5).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqSelect(List<Contact> contacts)
    {
        Console.WriteLine("******** LINQ Select method ********");
        Console.WriteLine("Select the numbers of contacts:");

        List<string> result = contacts.Select(c => c.PhoneNumber).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqJoin(List<Contact> contacts, List<Company> companies)
    {
        Console.WriteLine("******** LINQ Join method ********");
        Console.WriteLine("Join two lists (contacts and companies):");

        var result = contacts.Join(
            companies,
            contact => contact.Company,
            company => company.Title,
            (contact, company) => new { Name = contact.Name, Company = company.Title, Location = company.Location }).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqZip(List<Contact> contacts, List<Company> companies)
    {
        Console.WriteLine("******** LINQ Zip method ********");
        Console.WriteLine("Zip two lists (contacts and companies):");

        var result = contacts.Zip(companies).ToList();

        foreach (var valueTuple in result)
        {
            Console.WriteLine($"{valueTuple.First} - {valueTuple.Second}");
        }

        Console.WriteLine();
    }

    private static void LinqConcat(List<Contact> contacts, List<Contact> contacts2)
    {
        Console.WriteLine("******** LINQ Concat method ********");
        Console.WriteLine("Concats two lists (contacts1 and contacts2):");

        List<Contact> result = contacts.Concat(contacts2).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }

    private static void LinqUnion(List<Contact> contacts1, List<Contact> contacts2)
    {
        Console.WriteLine("******** LINQ Union method ********");
        Console.WriteLine("Make a union of two lists (contacts1 and contacts2):");

        var result = contacts1.Union(contacts2).ToList();

        IterateThroughCollection(result);

        Console.WriteLine();
    }
}