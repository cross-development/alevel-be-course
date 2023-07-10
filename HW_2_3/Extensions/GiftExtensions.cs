using HW_2_3.Interfaces;

namespace HW_2_3.Extensions;

/// <summary>
/// Extensions for the Gift class.
/// </summary>
public static class GiftExtensions
{
    /// <summary>
    /// Find gift item by name.
    /// </summary>
    /// <param name="gift">Instance of the <see cref="Gift"/> class.</param>
    /// <param name="name">Gift item name.</param>
    /// <returns>Found gift item or null.</returns>
    public static IGiftItem? FindByName(this Gift gift, string name)
    {
        return gift.GiftItems.FirstOrDefault(item => item.Name == name);
    }

    /// <summary>
    /// This method is used to get gift item description.
    /// </summary>
    /// <param name="gift">Instance of the <see cref="Gift"/> class.</param>
    /// <param name="name">Gift item name.</param>
    /// <returns>Gift item description or null.</returns>
    public static string? GetGiftItemDescription(this Gift gift, string name)
    {
        IGiftItem? item = FindByName(gift, name);

        return item?.GetDescription();
    }
}
