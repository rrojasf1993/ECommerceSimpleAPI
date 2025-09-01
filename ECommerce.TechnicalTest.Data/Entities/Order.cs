using ECommerce.TechnicalTest.Cross.Enums;

namespace ECommerce.TechnicalTest.Data.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime PlacementDate { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItemDetail> OrderedItems { get; set; } = new();
}