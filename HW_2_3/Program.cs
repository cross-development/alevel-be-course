using HW_2_3.Extensions;
using HW_2_3.Interfaces;

namespace HW_2_3;

/// <summary>
/// Program entry point.
/// </summary>
public class Program
{
    /// <summary>
    /// Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    private static void Main(string[] args)
    {
        IGiftItem[] giftItems = new IGiftItem[]
        {
            new Cookie { Name = "Cookie1", Price = 500, IsSugarFree = true, Weight = 100 },
            new Cookie { Name = "Cookie2", Price = 600, IsSugarFree = false, Weight = 100 },
            new Candy { Name = "Candy1", Price = 100, Flavor = "Cherry", Weight = 10 },
            new Candy { Name = "Candy2", Price = 200, Flavor = "Lemon", Weight = 10 },
            new Chocolate { Name = "Chocolate1", Price = 300, Type = "White", Weight = 50 },
            new Chocolate { Name = "Chocolate2", Price = 400, Type = "Black", Weight = 50 },
        };

        Gift gift = new Gift(giftItems);

        Console.WriteLine("Great news! Your gift is complete!");
        Console.WriteLine("Here are its contents:");

        foreach (var item in gift.GiftItems)
        {
            Console.WriteLine(item.GetDescription());
        }

        Console.WriteLine();
        double giftPrice = gift.CalculateTotalPrice();
        Console.WriteLine($"The cost of your gift: {giftPrice}");

        Console.WriteLine();
        double giftWeight = gift.CalculateTotalWeight();
        Console.WriteLine($"The weight of your gift: {giftWeight}");

        Console.WriteLine();
        Console.WriteLine("Let's sort your gift items by weight.");
        gift.SortByWeight();
        Console.WriteLine("Now its content looks like this:");

        foreach (var item in gift.GiftItems)
        {
            Console.WriteLine(item.GetDescription());
        }

        Console.WriteLine();
        Console.WriteLine("Let's find the Candy1 inside your gift and get its description.");
        IGiftItem? foundGiftCandy1 = gift.FindByName("Candy1");

        if (foundGiftCandy1 != null)
        {
            Console.WriteLine($"Candy1 has been found. Here is its description:");
            Console.WriteLine(foundGiftCandy1.GetDescription());
        }

        Console.WriteLine();
        Console.WriteLine("Let's get the Chocolate2 description, which is in your gift.");
        string? foundGiftChocolate2 = gift.GetGiftItemDescription("Chocolate2");

        if (foundGiftChocolate2 != null)
        {
            Console.WriteLine($"Chocolate2 has the following description:");
            Console.WriteLine(foundGiftChocolate2);
        }

        Console.ReadKey();
    }
}
