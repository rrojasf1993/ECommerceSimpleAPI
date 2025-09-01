using AutoMapper;
using ECommerce.TechnicalTest.Data.Entities;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Domain.Products.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TechnicalTest.Domain.Products.Handlers
{
    public class CreateProductHandler:IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request.Product);
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Products.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductDto>(entity);
        }
    }
}