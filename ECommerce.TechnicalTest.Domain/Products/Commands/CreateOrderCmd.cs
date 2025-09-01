using ECommerce.TechnicalTest.Domain.DTO;
using MediatR;

namespace ECommerce.TechnicalTest.Domain.Products.Commands;

public class CreateOrderCmd: IRequest<bool>
{
    public OrderDto Order { get; }

    public CreateOrderCmd(OrderDto order)
    {
        Order = order;
    }
}
