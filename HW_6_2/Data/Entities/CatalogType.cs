namespace HW_6_2.Data.Entities;

public class CatalogType
{
    public int Id { get; set; }
    public string Type { get; set; }
    public ICollection<CatalogItem> CatalogItems { get; set; }
}