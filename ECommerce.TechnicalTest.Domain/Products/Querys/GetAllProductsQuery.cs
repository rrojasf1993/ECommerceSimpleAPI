using ECommerce.TechnicalTest.Domain.CQRSBase;
using ECommerce.TechnicalTest.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TechnicalTest.Domain.Products.Querys
{
    public class GetAllProductsQuery: IQuery<IEnumerable<ProductDto>>
    {

    }
}
