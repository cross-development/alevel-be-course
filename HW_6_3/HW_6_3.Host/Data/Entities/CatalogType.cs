namespace HW_6_3.Host.Data.Entities;

public class CatalogType
{
    public int Id { get; set; }
    public string Type { get; set; }
    public ICollection<CatalogItem> CatalogItems { get; set; }
}