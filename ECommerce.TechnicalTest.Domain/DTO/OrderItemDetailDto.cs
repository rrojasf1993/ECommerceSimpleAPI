namespace ECommerce.TechnicalTest.Domain.DTO;

public class OrderItemDetailDto
{

        public int Id { get; set; }
        public ProductDto Product { get; set; } = new();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

}