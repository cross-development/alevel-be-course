namespace HW_1_1;

internal class Program
{
    static void Main(string[] args)
    {
        Greeting();

        string? userInput;

        Console.WriteLine("1. Enter your first name:");
        userInput = Console.ReadLine();
        string firstName = GetUserInputOrDefault(userInput, "Vitalii");

        Console.WriteLine("2. Enter your last name:");
        userInput = Console.ReadLine();
        string lastName = GetUserInputOrDefault(userInput, "Derda");

        Console.WriteLine("3. Enter your current age:");
        userInput = Console.ReadLine();
        int age = int.Parse(GetUserInputOrDefault(userInput, "33"));

        Console.WriteLine();
        Console.WriteLine($"Great! {firstName} {lastName} you are almost there!");
        Console.WriteLine("Now, please enter the age at which you would like to start a new life (must be greater than your age):");
        userInput = Console.ReadLine();
        int yearsOfStartingNewUserLife = int.Parse(GetUserInputOrDefault(userInput, "40"));

        Console.WriteLine();
        Console.WriteLine("Now, let's calculate how many years you have left...");
        int yearsLeftToStartNewUserLife = CalculateRemainingYearsToTheNewLife(age, yearsOfStartingNewUserLife);

        PrintUserResults(firstName, lastName, yearsLeftToStartNewUserLife);

        Console.ReadKey();
    }

    private static void Greeting()
    {
        Console.WriteLine("Dear user,");
        Console.WriteLine();
        Console.WriteLine("Please enter your personal data so we can do some magic for you.");
        Console.WriteLine("P.S.: unless you provide your data we will use some data by default.");
        Console.WriteLine();
    }

    private static string GetUserInputOrDefault(string? userInput, string defaultValue)
    {
        return string.IsNullOrWhiteSpace(userInput) ? defaultValue : userInput;
    }

    private static int CalculateRemainingYearsToTheNewLife(int userAge, int yearsOfStartingNewUserLife)
    {
        return yearsOfStartingNewUserLife - userAge;
    }

    private static void PrintUserResults(string firstName, string lastName, int yearsLeftToStartNewUserLife)
    {
        Console.WriteLine();
        Console.WriteLine($"Wow! {firstName} {lastName} you have {yearsLeftToStartNewUserLife} years left before the start of your new life.");
    }
}
