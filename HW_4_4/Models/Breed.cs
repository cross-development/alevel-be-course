﻿namespace HW_4_4.Models;

/// <summary>
/// Breed model.
/// </summary>
public class Breed
{
    /// <summary>
    /// Gets or sets breed id.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets breed name.
    /// </summary>
    public required string BreedName { get; set; }

    /// <summary>
    /// Gets or sets pets in a breed.
    /// </summary>
    public required ICollection<Pet> Pets { get; set; }

    /// <summary>
    /// Gets or sets category id for a breed.
    /// </summary>
    public required int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets navigation property for a category table.
    /// </summary>
    public required Category Category { get; set; }
}