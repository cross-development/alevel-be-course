namespace HW_1_2;

internal class Program
{
    static void Main(string[] args)
    {
        Startup.StartProgram();

        int userChoice = Startup.GetOptionFromUserChoice();

        ILogger logger = new Logger();
        ISorter sorter = new Sorter(logger);

        IArrayService arrayService = new ArrayService(logger, sorter);

        switch (userChoice)
        {
            case 1:
                arrayService.CalculateFilteredElementsInRange(minRangeBoundary: -100, maxRangeBoundary: 100);
                Startup.FinishProgram();
                break;
            case 2:
                arrayService.FilterArrayByOneNumberAndSort(conditionForFiltering: 888);
                Startup.FinishProgram();
                break;
            default:
                Startup.FinishProgram();
                break;
        }
    }
}


// STARTUP UTILITY CLASS
internal static class Startup
{
    private static string[] DisplayOptionsMenu()
    {
        string[] userMenu = new string[3]
        {
            "1. Calculate the number of elements in the array that fall within the range -100 to 100.",
            "2. Filter all elements of the array which satisfy the condition \"element <= 888\".",
            "3. Exit.",
        };

        for (int i = 1; i <= userMenu.Length; i++)
        {
            Console.WriteLine($"{userMenu[i - 1]}");
        }

        return userMenu;
    }

    public static void StartProgram()
    {
        Console.WriteLine("Hello! What would you like to do?");
        Console.WriteLine();
    }

    public static void FinishProgram()
    {
        Console.WriteLine();
        Console.WriteLine("Bye! See you next time!");
        Console.ReadKey();
    }

    public static int GetOptionFromUserChoice()
    {
        int optionNumber;
        bool isValidChoice = false;

        do
        {
            string[] userMenu = DisplayOptionsMenu();

            Console.WriteLine();
            Console.Write("Enter your answer here: ");

            string? userInput = Console.ReadLine();

            Console.WriteLine();

            if (int.TryParse(userInput, out optionNumber))
            {
                if (optionNumber >= 1 && optionNumber <= userMenu.Length)
                {
                    isValidChoice = true;
                }
                else
                {
                    Console.WriteLine("We don't have this option. Please choose one of these options: ");
                }
            }
            else
            {
                Console.WriteLine("You have entered an invalid number. Please choose one of these options: ");
            }
        } while (!isValidChoice);

        return optionNumber;
    }
}

// ARRAY SERVICE
internal interface IArrayService
{
    void CalculateFilteredElementsInRange(int minRangeBoundary, int maxRangeBoundary);
    void FilterArrayByOneNumberAndSort(int conditionForFiltering);
}

internal class ArrayService : IArrayService
{
    private readonly ILogger _logger;
    private readonly ISorter _sorter;

    private const int MinArrayBoundary = -1000;
    private const int MaxArrayBoundary = 1000;

    public ArrayService(ILogger logger, ISorter sorter)
    {
        _logger = logger;
        _sorter = sorter;
    }

    private int GetArrayLengthFromUserInput()
    {
        int arrayLength;
        int minArrayLength = 10;

        do
        {
            Console.Write("Please enter the number of array elements (min 10 elements): ");

            string? userInput = Console.ReadLine();

            Console.WriteLine();

            if (!int.TryParse(userInput, out arrayLength)) continue;

            if (arrayLength >= minArrayLength) break;

        } while (arrayLength <= minArrayLength);

        Console.WriteLine($"There is an array of {arrayLength} elements with random numbers ranging from {MinArrayBoundary} to {MaxArrayBoundary}.");

        return arrayLength;
    }

    private void GetRandomNumber(out int currentElement)
    {
        currentElement = new Random().Next(MinArrayBoundary, MaxArrayBoundary);
    }

    public void CalculateFilteredElementsInRange(int minRangeBoundary, int maxRangeBoundary)
    {
        int arrayLength = GetArrayLengthFromUserInput();

        int numbersInRange = 0;
        int[] arrayOfRandomNumbers = new int[arrayLength];

        for (int i = 0; i < arrayOfRandomNumbers.Length; i++)
        {
            GetRandomNumber(out arrayOfRandomNumbers[i]);

            if (arrayOfRandomNumbers[i] >= minRangeBoundary && arrayOfRandomNumbers[i] <= maxRangeBoundary)
            {
                numbersInRange++;
            }
        }

        Console.WriteLine();
        _logger.DisplayElementsOfArray(arrayOfRandomNumbers, "The elements of the original array:");

        Console.WriteLine();
        Console.WriteLine($"The total number of numbers in the range from {minRangeBoundary} to {maxRangeBoundary} is: {numbersInRange}");
    }

    public void FilterArrayByOneNumberAndSort(int conditionForFiltering)
    {
        int arrayLength = GetArrayLengthFromUserInput();

        int[] arrayOfRandomNumbersA = new int[arrayLength];
        int[] arrayOfRandomNumbersB = new int[arrayLength];

        for (int i = 0; i < arrayOfRandomNumbersA.Length; i++)
        {
            GetRandomNumber(out arrayOfRandomNumbersA[i]);

            if (arrayOfRandomNumbersA[i] <= conditionForFiltering)
            {
                arrayOfRandomNumbersB[i] = arrayOfRandomNumbersA[i];
            }
        }

        Console.WriteLine();
        _logger.DisplayElementsOfArray(arrayOfRandomNumbersA, "The elements of the original array:");

        Console.WriteLine();
        _logger.DisplayElementsOfArray(arrayOfRandomNumbersB, "The elements of the filtered array that are less than or equal to 888:");

        Console.WriteLine();
        _sorter.SortByAsc(arrayOfRandomNumbersB);

        Console.WriteLine();
        _sorter.SortByDesc(arrayOfRandomNumbersB);
    }
}

// LOGGER SERVICE
internal interface ILogger
{
    void DisplayElementsOfArray(int[] array, string message);
}

internal class Logger : ILogger
{
    public void DisplayElementsOfArray(int[] array, string message)
    {
        Console.WriteLine(message);
        Array.ForEach(array, (number) => Console.Write($"{number}, "));
        Console.WriteLine();
    }
}

// SORTER SERVICE
internal interface ISorter
{
    int[] SortByAsc(int[] array);
    int[] SortByDesc(int[] array);
}

internal class Sorter : ISorter
{
    private readonly ILogger _logger;

    public Sorter(ILogger logger)
    {
        _logger = logger;
    }

    private int[] GetCopyOfOriginalArray(int[] array)
    {
        // Creating a copy of the passed array in order not to mutate the original one
        int[] copiedArray = new int[array.Length];
        Array.Copy(array, copiedArray, array.Length);

        return copiedArray;
    }

    public int[] SortByAsc(int[] array)
    {
        int[] copiedArray = GetCopyOfOriginalArray(array);
        Array.Sort(copiedArray);

        _logger.DisplayElementsOfArray(copiedArray, "The array has been sorted by ascending.");

        return copiedArray;
    }

    public int[] SortByDesc(int[] array)
    {
        int[] copiedArray = GetCopyOfOriginalArray(array);
        Array.Sort(copiedArray, (x, y) => y.CompareTo(x));

        _logger.DisplayElementsOfArray(copiedArray, "The array has been sorted by descending.");

        return copiedArray;
    }
}
