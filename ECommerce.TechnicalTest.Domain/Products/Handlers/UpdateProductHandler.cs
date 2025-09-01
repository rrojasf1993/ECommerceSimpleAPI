using AutoMapper;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.Products.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TechnicalTest.Domain.Products.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCmd, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProductCmd request, CancellationToken cancellationToken)
        {
            var existing = await _unitOfWork.Products.GetByIdAsync(request.Product.Id);
            if (existing is null) return false;

            _mapper.Map(request.Product, existing);
            existing.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Products.Update(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}

