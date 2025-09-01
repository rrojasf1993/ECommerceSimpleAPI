using AutoFixture;
using AutoFixture.AutoMoq;
using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ECommerce.TechnicalTest.UnitTests;

public class OrdersControllerTests
{
    [Fact]
    public async Task GetById_ShouldReturnOk_WhenOrderExists()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var mockService = new Mock<IService<OrderDto>>();
        var order = fixture.Create<OrderDto>();
        mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(order);

        var controller = new OrdersController(mockService.Object);
        var result = await controller.GetById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(order, okResult.Value);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenOrderDoesNotExist()
    {
        var mockService = new Mock<IService<OrderDto>>();
        mockService.Setup(s => s.GetByIdAsync(99)).ReturnsAsync((OrderDto?)null);

        var controller = new OrdersController(mockService.Object);
        var result = await controller.GetById(99);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Create_ShouldReturnCreatedAt_WhenOrderIsCreated()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var mockService = new Mock<IService<OrderDto>>();
        var dto = fixture.Create<OrderDto>();
        mockService.Setup(s => s.CreateAsync(dto)).ReturnsAsync(dto);

        var controller = new OrdersController(mockService.Object);
        var result = await controller.Create(dto);

        var created = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(dto, created.Value);
    }
}
