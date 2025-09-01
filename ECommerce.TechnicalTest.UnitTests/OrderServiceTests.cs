using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using ECommerce.TechnicalTest.Cross.Util;
using ECommerce.TechnicalTest.Data.Entities;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Polly;

namespace ECommerce.TechnicalTest.UnitTests;

public class OrderServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ProductVerifyService> _verifierMock;
    private readonly Services.OrdersService _service;

    public OrderServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>(); 
         Mock<IConfiguration> configMock = new Mock<IConfiguration>();
         Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
         Mock<IAsyncPolicy<HttpResponseMessage>> mockPolicy = new Mock<IAsyncPolicy<HttpResponseMessage>>();
         Mock<RetryingHttpClient> retryingHttpClientMock = new Mock<RetryingHttpClient>(mockHttpClient.Object,mockPolicy.Object);
         _verifierMock = new Mock<ProductVerifyService>(retryingHttpClientMock.Object,configMock.Object);

        _service = new Services.OrdersService(_unitOfWorkMock.Object, _mapperMock.Object, _verifierMock.Object);
    }
    
    [Fact]
    public async Task CreateAsync_ShouldCreateOrder_WhenProductsExist()
    {
       
        var dto = new OrderDto
        {
            CustomerId = 123,
            OrderedItems = new List<OrderItemDetailDto>
            {
                new() { Id = 1, Quantity = 2 },
                new() { Id = 2, Quantity = 1 }
            }
        };

        var entity = new Order { Id = 1, CustomerId = 123 };

        _verifierMock.Setup(v => v.ProductExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        _mapperMock.Setup(m => m.Map<Order>(dto)).Returns(entity);
        _mapperMock.Setup(m => m.Map<OrderDto>(entity)).Returns(dto);

        _unitOfWorkMock.Setup(u => u.Orders.AddAsync(entity)).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.FromResult<int>(1));

        var result = await _service.CreateAsync(dto);

        Assert.Equal(dto, result);
        _unitOfWorkMock.Verify(u => u.Orders.AddAsync(entity), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task CreateAsync_ShouldThrow_WhenProductDoesNotExist()
    {
        
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var dto = fixture.Create<OrderDto>();

        _verifierMock.Setup(v => v.ProductExistsAsync(999)).ReturnsAsync(false);

        await Assert.ThrowsAsync<InvalidOperationException>(() => _service.CreateAsync(dto));

        _unitOfWorkMock.Verify(u => u.Orders.AddAsync(It.IsAny<Order>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Never);
    }
    
    [Fact]
    public async Task GetByIdAsync_ShouldReturnOrderDto_WhenOrderExists()
    {
        var entity = new Order { Id = 1, CustomerId = 123 };
        var dto = new OrderDto { Id = 1, CustomerId = 123 };

        _unitOfWorkMock.Setup(u => u.Orders.GetByIdAsync(1)).ReturnsAsync(entity);
        _mapperMock.Setup(m => m.Map<OrderDto>(entity)).Returns(dto);

        var result = await _service.GetByIdAsync(1);

        Assert.Equal(dto, result);
    }
    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue_WhenOrderExists()
    {
        var entity = new Order { Id = 1 };

        _unitOfWorkMock.Setup(u => u.Orders.GetByIdAsync(1)).ReturnsAsync(entity);
        _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.FromResult<int>(1));

        var result = await _service.DeleteAsync(1);

        Assert.True(result);
        _unitOfWorkMock.Verify(u => u.Orders.Delete(entity), Times.Once);
    }




}