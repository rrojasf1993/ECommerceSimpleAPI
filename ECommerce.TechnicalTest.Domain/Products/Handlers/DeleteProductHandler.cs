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
    public class DeleteProductHandler:IRequestHandler<DeleteProductCmd, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteProductCmd request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);
            if (product is null) return false;

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
