namespace HW_6_3.Host.Data.Entities;

public class CatalogBrand
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public ICollection<CatalogItem> CatalogItems { get; set; }
}