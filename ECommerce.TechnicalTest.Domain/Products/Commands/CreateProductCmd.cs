using AutoMapper;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.CQRSBase;
using ECommerce.TechnicalTest.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TechnicalTest.Domain.Products.Commands
{
    public class CreateProductCommand : ICommand<ProductDto>
    {
        public ProductDto Product { get; }

        public CreateProductCommand(ProductDto product)
        {
            Product = product;
        }
    }
}
