using AutoMapper;
using ECommerce.TechnicalTest.Data.Entities;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.DTO;

namespace ECommerce.TechnicalTest.Services;

public class OrdersService: IService<OrderDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly  ProductVerifyService _productVerifyServiceInstance;
    public OrdersService(IUnitOfWork unitOfWork, IMapper mapper, ProductVerifyService productVerifyService)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
        this._productVerifyServiceInstance = productVerifyService;
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        return order is null ? null : _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> CreateAsync(OrderDto item)
    {
        foreach (OrderItemDetailDto orderItem in item.OrderedItems)
        {
            if (!await _productVerifyServiceInstance.ProductExistsAsync(orderItem.Id))
                throw new InvalidOperationException($"Product with ID {orderItem.Id} does not exist.");
        }
        var entity = _mapper.Map<Order>(item);
        entity.PlacementDate = DateTime.UtcNow;
     
        await _unitOfWork.Orders.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<OrderDto>(entity);
    }

    public async Task<bool> UpdateAsync(OrderDto itemToUpdate)
    {
        var existing = await _unitOfWork.Orders.GetByIdAsync(itemToUpdate.Id);
        if (existing is null) return false;

        _mapper.Map(itemToUpdate, existing);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order is null) return false;

        _unitOfWork.Orders.Delete(order);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
    
    
}

