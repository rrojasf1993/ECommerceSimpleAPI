using ECommerce.TechnicalTest.Domain.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TechnicalTest.Domain.ValidationConfig
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            {
                RuleFor(o => o.CustomerId)
                    .GreaterThan(0).WithMessage("The client id must be greater than 0");

                RuleFor(o => o.OrderedItems)
                    .NotEmpty().WithMessage("You must provide at least one item");
                

                RuleForEach(o => o.OrderedItems)
                    .SetValidator(new OrderItemDetailDtoValidator());
            }
        }
    }
}
