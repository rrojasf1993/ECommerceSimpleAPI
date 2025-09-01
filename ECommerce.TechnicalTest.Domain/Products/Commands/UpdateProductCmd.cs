using ECommerce.TechnicalTest.Domain.CQRSBase;
using ECommerce.TechnicalTest.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TechnicalTest.Domain.Products.Commands
{
    public class UpdateProductCmd : ICommand<bool>
    {
    
        public ProductDto Product { get; }

        public UpdateProductCmd(ProductDto product)
        {
            Product = product;
        }
    }
}
