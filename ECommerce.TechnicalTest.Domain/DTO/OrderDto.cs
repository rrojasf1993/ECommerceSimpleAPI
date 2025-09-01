using ECommerce.TechnicalTest.Cross.Enums;

namespace ECommerce.TechnicalTest.Domain.DTO;

public class OrderDto
{

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PlacementDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItemDetailDto> OrderedItems { get; set; } = new();
        
}