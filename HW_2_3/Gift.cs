using HW_2_3.Interfaces;

namespace HW_2_3;

/// <summary>
/// Gift Class.
/// </summary>
public class Gift
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Gift"/> class.
    /// </summary>
    /// <param name="giftItems">Gift items.</param>
    public Gift(IGiftItem[] giftItems)
    {
        GiftItems = giftItems;
    }

    /// <summary>
    /// Gets gift items.
    /// </summary>
    public IGiftItem[] GiftItems { get; }

    /// <summary>
    /// This method is used to calculate a total weight of the gift.
    /// </summary>
    /// <returns>Total weight.</returns>
    public double CalculateTotalWeight()
    {
        double totalWeight = 0.0;

        foreach (IGiftItem item in GiftItems)
        {
            totalWeight += item.Weight;
        }

        return totalWeight;
    }

    /// <summary>
    /// This method is used to calculate total gift price.
    /// </summary>
    /// <returns>Total price.</returns>
    public double CalculateTotalPrice()
    {
        double totalPrice = 0.0;

        foreach (IGiftItem item in GiftItems)
        {
            totalPrice += item.Price;
        }

        return totalPrice;
    }

    /// <summary>
    /// Sort the gift items by their weight.
    /// </summary>
    public void SortByWeight()
    {
        Array.Sort(GiftItems, (s1, s2) => s1.Weight.CompareTo(s2.Weight));
    }
}
