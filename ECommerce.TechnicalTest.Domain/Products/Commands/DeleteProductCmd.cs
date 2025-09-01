using ECommerce.TechnicalTest.Domain.CQRSBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TechnicalTest.Domain.Products.Commands
{
    public class DeleteProductCmd : ICommand<bool>
    {
        public int ProductId { get; }

        public DeleteProductCmd(int productId)
        {
            ProductId = productId;
        }
    }
    
}
