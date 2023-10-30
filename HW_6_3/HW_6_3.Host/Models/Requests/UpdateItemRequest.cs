﻿namespace HW_6_3.Host.Models.Requests;

public sealed class UpdateItemRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal? Price { get; set; }
    public string PictureFileName { get; set; }
    public int? AvailableStock { get; set; }
    public int? CatalogTypeId { get; set; }
    public int? CatalogBrandId { get; set; }
}