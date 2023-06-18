namespace HW_1_2;

internal class Program
{
    static void Main(string[] args)
    {
        var firstTask = new FirstTask();
        //int arrayLengthFromUserInput1 = firstTask.GetArrayLengthFromUserInput();
        //firstTask.CalculateNumbersInTheSpecificRange(arrayLengthFromUserInput1);
        //firstTask.CalculateNumbersInTheSpecificRangeUsingLinq(arrayLengthFromUserInput1);

        var secondTask = new SecondTask();
        int arrayLengthFromUserInput2 = secondTask.GetArrayLengthFromUserInput();
        secondTask.FilterArrayOfRandomNumbersInTheSpecificRange(arrayLengthFromUserInput2);
        //secondTask.FilterArrayOfRandomNumbersInTheSpecificRangeUsingLinq(arrayLengthFromUserInput2);
    }
}

internal enum SortOrder
{
    Asc,
    Desc,
}

internal class SecondTask
{
    private const int MinArrayBoundary = -1000;
    private const int MaxArrayBoundary = 1000;
    private const int ConditionForFiltering = 888;

    private int[] SortArrayWithoutMutation(int[] array, SortOrder order)
    {
        // Creating a copy of the passed array in order not to mutate the original one
        int[] copiedArray = new int[array.Length];
        Array.Copy(array, copiedArray, array.Length);

        switch (order)
        {
            case SortOrder.Asc:
                Array.Sort(copiedArray);
                break;
            case SortOrder.Desc:
                Array.Sort(copiedArray, (x, y) => y.CompareTo(x));
                break;
            default:
                throw new NotImplementedException();
        }

        return copiedArray;
    }

    private void DisplayElementsOfArray(int[] array, string message)
    {
        Console.WriteLine(message);
        Array.ForEach(array, (number) => Console.Write($"{number}, "));
        Console.WriteLine();
    }

    public int GetArrayLengthFromUserInput()
    {
        int arrayLength;
        int minArrayLength = 20;

        do
        {
            Console.Write("Please enter the number of array elements (min 20 elements): ");

            string? userInput = Console.ReadLine();

            Console.WriteLine();

            if (int.TryParse(userInput, out arrayLength))
            {
                if (arrayLength >= minArrayLength)
                {
                    break;
                }
            }
        } while (arrayLength <= minArrayLength);

        return arrayLength;
    }

    // The imperative solution of the first part of the homework.
    public void FilterArrayOfRandomNumbersInTheSpecificRange(int arrayLength)
    {
        Console.WriteLine($"There is an array of {arrayLength} elements with random numbers ranging from {MinArrayBoundary} to {MaxArrayBoundary}.");

        #region CreateAndFillInArrays

        int[] arrayOfRandomNumbersA = new int[arrayLength];
        int[] arrayOfRandomNumbersB = new int[arrayLength];

        for (int i = 0; i < arrayOfRandomNumbersA.Length; i++)
        {
            arrayOfRandomNumbersA[i] = new Random().Next(MinArrayBoundary, MaxArrayBoundary);

            if (arrayOfRandomNumbersA[i] <= ConditionForFiltering)
            {
                arrayOfRandomNumbersB[i] = arrayOfRandomNumbersA[i];
            }
        }

        #endregion


        #region DisplayElementsOfArray

        // Display all elements of the arrayOfRandomNumbersA
        Console.WriteLine();
        DisplayElementsOfArray(arrayOfRandomNumbersA, "The elements of the arrayOfRandomNumbersA:");

        // Display all elements of the arrayOfRandomNumbersB
        Console.WriteLine();
        DisplayElementsOfArray(arrayOfRandomNumbersB, "The elements of the arrayOfRandomNumbersB:");

        #endregion


        #region SortByAscAndDesc

        // Sort by ascending
        Console.WriteLine();
        var sortedArrayByAsc = SortArrayWithoutMutation(arrayOfRandomNumbersB, SortOrder.Asc);
        DisplayElementsOfArray(sortedArrayByAsc, "The arrayOfRandomNumbersB is sorted by ascending.");

        // Sort by descending
        Console.WriteLine();
        var sortedArrayByDesc = SortArrayWithoutMutation(arrayOfRandomNumbersB, SortOrder.Desc);
        DisplayElementsOfArray(sortedArrayByDesc, "The arrayOfRandomNumbersB is sorted by descending.");

        #endregion

        Console.ReadKey();
    }

    // The same solution as above but this one is declarative and uses LINQ
    public void FilterArrayOfRandomNumbersInTheSpecificRangeUsingLinq(int arrayLength)
    {
        Console.WriteLine($"There is an array of {arrayLength} elements with random numbers ranging from {MinArrayBoundary} to {MaxArrayBoundary}.");
        int[] arrayOfRandomNumbersA = Enumerable.Range(0, arrayLength).Select(n => new Random().Next(MinArrayBoundary, MaxArrayBoundary)).ToArray();

        // Display all elements of the arrayOfRandomNumbersA
        Console.WriteLine();
        DisplayElementsOfArray(arrayOfRandomNumbersA, "The elements of the arrayOfRandomNumbersA:");

        // Copy the element of the arrayOfRandomNumbersA if it satisfy the condition. Otherwise the number will we replace with 0.
        int[] arrayOfRandomNumbersB = arrayOfRandomNumbersA.Select((number) => number <= ConditionForFiltering ? number : 0).ToArray();

        // Display all elements of the arrayOfRandomNumbersB
        Console.WriteLine();
        DisplayElementsOfArray(arrayOfRandomNumbersB, "The elements of the arrayOfRandomNumbersB:");

        // Sort by ascending
        Console.WriteLine();
        var sortedArrayByAsc = arrayOfRandomNumbersB.OrderBy(x => x).ToArray();
        DisplayElementsOfArray(sortedArrayByAsc, "The arrayOfRandomNumbersB is sorted by ascending.");

        // Sort by descending
        Console.WriteLine();
        var sortedArrayByDesc = arrayOfRandomNumbersB.OrderByDescending(x => x).ToArray();
        DisplayElementsOfArray(sortedArrayByDesc, "The arrayOfRandomNumbersB is sorted by descending.");

        Console.ReadKey();
    }
}


internal class FirstTask
{
    private const int MinArrayBoundary = -200;
    private const int MaxArrayBoundary = 200;
    private const int MinFilteredArrayBoundary = -100;
    private const int MaxFilteredArrayBoundary = 100;

    public int GetArrayLengthFromUserInput()
    {
        int arrayLength;
        int minArrayLength = 1;

        do
        {
            Console.Write("Please enter the number of array elements (min 1 elements): ");

            string? userInput = Console.ReadLine();

            Console.WriteLine();

            if (int.TryParse(userInput, out arrayLength))
            {
                if (arrayLength >= minArrayLength)
                {
                    break;
                }
            }
        } while (arrayLength <= minArrayLength);

        return arrayLength;
    }

    // The imperative solution of the first part of the homework.
    public void CalculateNumbersInTheSpecificRange(int arrayLength)
    {
        Console.WriteLine($"There is an array of {arrayLength} elements with random numbers ranging from {MinArrayBoundary} to {MaxArrayBoundary}.");

        int numbersInRange = 0;
        int[] arrayOfRandomNumbers = new int[arrayLength];

        for (int i = 0; i < arrayOfRandomNumbers.Length; i++)
        {
            arrayOfRandomNumbers[i] = new Random().Next(MinArrayBoundary, MaxArrayBoundary);

            if (arrayOfRandomNumbers[i] >= MinFilteredArrayBoundary && arrayOfRandomNumbers[i] <= MaxFilteredArrayBoundary)
            {
                numbersInRange++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("The elements of the array:");
        arrayOfRandomNumbers.ToList().ForEach(number => Console.Write($"{number}, "));
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine($"The total number of numbers in the range from -100 to 100 is: {numbersInRange}");

        Console.ReadKey();
    }


    // The same solution as above but this one is declarative and uses LINQ
    public void CalculateNumbersInTheSpecificRangeUsingLinq(int arrayLength)
    {
        Console.WriteLine($"There is an array of {arrayLength} elements with random numbers ranging from {MinArrayBoundary} to {MaxArrayBoundary}.");
        int[] arrayOfRandomNumbers = Enumerable.Range(0, arrayLength).Select(n => new Random().Next(MinArrayBoundary, MaxArrayBoundary)).ToArray();

        Console.WriteLine();
        Console.WriteLine("The elements of the array:");
        arrayOfRandomNumbers.ToList().ForEach(number => Console.Write($"{number}, "));
        Console.WriteLine();

        Console.WriteLine();
        int numbersInRange = arrayOfRandomNumbers.Count(number => number is >= MinFilteredArrayBoundary and <= MaxFilteredArrayBoundary);
        Console.WriteLine($"The total number of numbers in the range from -100 to 100 is {numbersInRange}.");

        Console.ReadKey();
    }
}

