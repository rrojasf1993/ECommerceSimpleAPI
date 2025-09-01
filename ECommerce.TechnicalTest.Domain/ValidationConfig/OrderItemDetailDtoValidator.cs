using ECommerce.TechnicalTest.Domain.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TechnicalTest.Domain.ValidationConfig
{
    public class OrderItemDetailDtoValidator : AbstractValidator<OrderItemDetailDto>
    {
        public OrderItemDetailDtoValidator()
        {
                RuleFor(oi => oi.Quantity)
                    .GreaterThan(0).WithMessage("The quantity must be greater than 0");

                RuleFor(oi => oi.UnitPrice)
                    .GreaterThan(0).WithMessage("The unit price must be greater than 0");

                RuleFor(oi => oi.Product)
                    .NotNull().WithMessage("You must provide a product");
            
        }
    }
}