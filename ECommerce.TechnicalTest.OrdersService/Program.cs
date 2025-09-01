using ECommerce.TechnicalTest.Cross;
using ECommerce.TechnicalTest.Cross.Util;
using ECommerce.TechnicalTest.Data;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.AutomapperConfig;
using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Domain.Products.Commands;
using ECommerce.TechnicalTest.Domain.ValidationConfig;
using ECommerce.TechnicalTest.Services;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Extensions.Http;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add custom services
int retryCount = 3;
int.TryParse(builder.Configuration["RetryCount"], out retryCount);
int spanBetweenRetriesInSeconds = 15;
int.TryParse(builder.Configuration["SecondsBetweenRetries"], out retryCount);

//Add custom services
builder.Services.AddDbContext<ECommerceTechnicalTestDataContext>(options =>
{
    options.UseOracle(connectionString:builder.Configuration.GetConnectionString("ECommerceTechnicalTest"));
   
});
var retryPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(spanBetweenRetriesInSeconds, retryAttempt)));
builder.Services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(retryPolicy);
builder.Services.AddHttpClient<RetryingHttpClient>()
    .AddPolicyHandler(retryPolicy);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddScoped<RetryingHttpClient>();
builder.Services.AddScoped<ProductVerifyService>();
builder.Services.AddScoped<IService<OrderDto>, OrdersService>();
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