using ECommerce.TechnicalTest.Cross;
using ECommerce.TechnicalTest.Data;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.AutomapperConfig;
using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Domain.Products.Commands;
using ECommerce.TechnicalTest.Domain.ValidationConfig;
using ECommerce.TechnicalTest.Services;
using ECommerceTechnicalTest.ProductsService.Filters;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o =>
{
    o.Filters.Add<ValidationExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add custom services
builder.Services.AddDbContext<ECommerceTechnicalTestDataContext>(options =>
{
    options.UseOracle(connectionString:builder.Configuration.GetConnectionString("ECommerceTechnicalTest"));
   
});
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//add custom middleware
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();
app.Run();