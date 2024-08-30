using Domain.Base;

namespace Domain.Products;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;  
    public string Brand { get; set; }
    public int Price { get; set; }
    public int Barcode { get; set; }
}