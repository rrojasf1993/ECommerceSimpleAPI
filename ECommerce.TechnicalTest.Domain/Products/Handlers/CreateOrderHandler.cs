using AutoMapper;
using ECommerce.TechnicalTest.Cross.Enums;
using ECommerce.TechnicalTest.Data.Entities;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.Products.Commands;
using MediatR;

namespace ECommerce.TechnicalTest.Domain.Products.Handlers;

public class CreateOrderHandler: IRequestHandler<CreateOrderCmd, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    
    public CreateOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
      
    }
    
    public async Task<bool> Handle(CreateOrderCmd request, CancellationToken cancellationToken)
    {
        var orderEntity = _mapper.Map<Order>(request.Order);
        orderEntity.PlacementDate = DateTime.UtcNow;
        orderEntity.Status = OrderStatus.Pending;

        await _unitOfWork.Orders.AddAsync(orderEntity);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
