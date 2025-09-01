using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace ECommerceTechnicalTest.ProductsService.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationEx)
            {
                var errors = validationEx.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage });

                context.Result = new BadRequestObjectResult(errors);
                context.ExceptionHandled = true;
            }
        }
    }
}
