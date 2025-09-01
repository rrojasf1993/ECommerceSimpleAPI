using ECommerce.TechnicalTest.Domain.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TechnicalTest.Domain.ValidationConfig
{
    public class ProductDtoValidator:AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The product name is required")
                .MaximumLength(100);

            RuleFor(p => p.Description)
                .MaximumLength(500);

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("The product price is required and greater than 0");

            RuleFor(p => p.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("The product stock quantity is required and greater than 0");
        }
    }
}