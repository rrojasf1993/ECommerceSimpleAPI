using ECommerce.TechnicalTest.Domain.CQRSBase;
using ECommerce.TechnicalTest.Domain.DTO;

namespace ECommerce.TechnicalTest.Domain.Products.Querys;

public class GetProductByIdQuery:IQuery<ProductDto>
{
    public int Id { get; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
    
}