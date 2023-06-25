using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW_1_4;

/// <summary>
/// Startup class.
/// </summary>
internal class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    /// <param name="args">Any array of strings.</param>
    private static void Main(string[] args)
    {
        int usersArrayLength = GetArrayLengthFromUserInput();

        int[] arrayOfRandomNumbers = CreateArrayWithRandomNumbers(usersArrayLength);
        Console.WriteLine($"Great! Now we have the array of {arrayOfRandomNumbers} elements.");
        Console.WriteLine($"We have just filled your array with {usersArrayLength} random numbers from 1 to 26.");
        DisplayArrayInfo(arrayOfRandomNumbers);
        Console.WriteLine();

        var (numOfEven, numOfOdd) = GetNumberOfEvenAndOddElements(arrayOfRandomNumbers);

        Console.WriteLine($"So, your array of {usersArrayLength} random numbers includes {numOfEven} even elements and {numOfOdd} odd elements.");
        Console.WriteLine("We are going to create two new arrays...");
        Console.WriteLine();

        var (arrayOfEvenNumbers, arrayOfOddNumbers) = FilterArrayByEvenAndOdd(arrayOfRandomNumbers, numOfEven, numOfOdd);

        Console.WriteLine($"The first array has a length of {numOfEven} elements. Its length corresponds to the number of even numbers in your first array.");
        DisplayArrayInfo(arrayOfEvenNumbers);
        Console.WriteLine();

        Console.WriteLine($"The second array has a length of {numOfOdd} elements. Its length corresponds to the number of odd numbers in your first array.");
        DisplayArrayInfo(arrayOfOddNumbers);

        Console.ReadKey();
    }

    /// <summary>
    /// This method allows you to get a number of array elements from a user.
    /// </summary>
    /// <returns>The length of an array from a user.</returns>
    private static int GetArrayLengthFromUserInput()
    {
        int arrayLength;
        int minArrayLength = 10;

        do
        {
            Console.Write("Please enter the number of array elements (min 10 elements): ");

            string? userInput = Console.ReadLine();

            Console.WriteLine();

            if (!int.TryParse(userInput, out arrayLength))
            {
                continue;
            }

            if (arrayLength >= minArrayLength)
            {
                break;
            }
        }
        while (arrayLength <= minArrayLength);

        return arrayLength;
    }

    /// <summary>
    /// This method allows you generate some random number and assigns it to the current element.
    /// </summary>
    /// <param name="random">An instance of the Random class.</param>
    /// <param name="currentElement">A current element of the target array.</param>
    private static void GetRandomNumber(Random random, out int currentElement)
    {
        currentElement = random.Next(1, 26);
    }

    /// <summary>
    /// This method allows you to get numbers of even and odd elements of an array.
    /// </summary>
    /// <param name="numbers">An array of a random elements.</param>
    /// <returns>A tuple that consists of the number of even and odd elements.</returns>
    private static (int numOfEven, int numOfOdd) GetNumberOfEvenAndOddElements(int[] numbers)
    {
        int numberOfEven = 0;
        int numberOfOdd = 0;

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                numberOfEven++;
            }
            else
            {
                numberOfOdd++;
            }
        }

        return (numberOfEven, numberOfOdd);
    }

    /// <summary>
    /// Filter an array of numbers to two new arrays with even and odd numbers.
    /// </summary>
    /// <param name="arrayToFilter">An array we want to filter.</param>
    /// <param name="numOfEven">A number of even elements for creating a new array with this length.</param>
    /// <param name="numOfOdd">A number of odd elements for creating a new array with this length.</param>
    /// <returns>A tuple that consists of two new arrays with filtered even and odd numbers.</returns>
    private static (int[] arrayOfEvenNumbers, int[] arrayOfOddNumbers) FilterArrayByEvenAndOdd(int[] arrayToFilter, int numOfEven, int numOfOdd)
    {
        int evenIndex = 0;
        int oddIndex = 0;

        int[] arrayOfEvenNumbers = new int[numOfEven];
        int[] arrayOfOddNumbers = new int[numOfOdd];

        foreach (int number in arrayToFilter)
        {
            if (number % 2 == 0)
            {
                arrayOfEvenNumbers[evenIndex] = number;
                evenIndex++;
            }
            else
            {
                arrayOfOddNumbers[oddIndex] = number;
                oddIndex++;
            }
        }

        return (arrayOfEvenNumbers, arrayOfOddNumbers);
    }

    /// <summary>
    /// Create and array of a random elements.
    /// </summary>
    /// <param name="arrayLength">A length of an array to create.</param>
    /// <returns>An array of a random elements with a passed length.</returns>
    private static int[] CreateArrayWithRandomNumbers(int arrayLength)
    {
        Random random = new Random();
        int[] arrayOfRandomNumbers = new int[arrayLength];

        for (int i = 0; i < arrayOfRandomNumbers.Length; i++)
        {
            GetRandomNumber(random, out arrayOfRandomNumbers[i]);
        }

        return arrayOfRandomNumbers;
    }

    /// <summary>
    /// Display elements of array with some message.
    /// </summary>
    /// <param name="array">An array to display elements.</param>
    /// <param name="message">Some message used before the list of each elements. (by default "Elements of the array:").</param>
    private static void DisplayArrayInfo(int[] array, string? message = "Elements of the array: ")
    {
        Console.WriteLine(message);
        Array.ForEach(array, (number) => Console.Write($"{number}, "));
        Console.WriteLine();
    }
}
