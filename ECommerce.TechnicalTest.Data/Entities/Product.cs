namespace ECommerce.TechnicalTest.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }=DateTime.Now;
    // ← Navegación 1-N hacia OrderItemDetail
    public ICollection<OrderItemDetail> OrderItemDetails { get; set; }
        = new List<OrderItemDetail>();
}