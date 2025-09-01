using AutoMapper;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Domain.Products.Querys;
using MediatR;

namespace ECommerce.TechnicalTest.Domain.Products.Handlers;

public class GetProductByIdHandler:IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
        return product is null ? null : _mapper.Map<ProductDto>(product);
    }
    
}