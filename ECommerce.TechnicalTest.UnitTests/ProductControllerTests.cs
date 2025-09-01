using AutoFixture;
using AutoFixture.AutoMoq;
using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Domain.Products.Commands;
using ECommerce.TechnicalTest.Domain.Products.Querys;
using ECommerceTechnicalTest.ProductsService.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ECommerce.TechnicalTest.UnitTests;

public class ProductControllerTests
{
    [Fact]
    public async Task GetById_ShouldReturnOk_WhenProductExists()
    {
        // Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        string name = fixture.Create<string>();
        decimal price = fixture.Create<decimal>();
        
        var productDto = fixture.Build<ProductDto>()
            .OmitAutoProperties() 
            .With(p => p.Name,name)
            .With(p => p.Price, price)
            .Create();

        var mediatorMock = new Mock<IMediator>();
        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), default))
            .ReturnsAsync(productDto);

        var controller = new ProductsController(mediatorMock.Object);

        // Act
        var result = await controller.GetById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedProduct = Assert.IsType<ProductDto>(okResult.Value);
        Assert.Equal(productDto.Id, returnedProduct.Id);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var mediatorMock = new Mock<IMediator>();
        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), default))
            .ReturnsAsync((ProductDto?)null);

        var controller = new ProductsController(mediatorMock.Object);

        // Act
        var result = await controller.GetById(fixture.Create<int>());

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
    
    [Fact]
    public async Task Create_ShouldReturnCreatedAtAction_WhenProductIsCreated()
    {
        // Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        string name = fixture.Create<string>();
        decimal price = fixture.Create<decimal>();
        
        var productDto = fixture.Build<ProductDto>()
            .OmitAutoProperties() 
            .With(p => p.Name,name)
            .With(p => p.Price, price)
            .Create();


        var mediatorMock = new Mock<IMediator>();
        mediatorMock
            .Setup(m => m.Send(It.IsAny<CreateProductCommand>(), default))
            .ReturnsAsync(productDto);

        var controller = new ProductsController(mediatorMock.Object);

        // Act
        var result = await controller.Create(productDto);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal(nameof(controller.GetById), createdResult.ActionName);
        Assert.Equal(productDto.Id, ((ProductDto)createdResult.Value!).Id);
        Assert.Equal(201, createdResult.StatusCode);
    }
    [Fact]
    public async Task Update_ShouldReturnNoContent_WhenUpdateIsSuccessful()
    {
        // Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        string name = fixture.Create<string>();
        decimal price = fixture.Create<decimal>();
        
        var productDto = fixture.Build<ProductDto>()
            .OmitAutoProperties() 
            .With(p => p.Name,name)
            .With(p => p.Price, price)
            .Create();
        
        var mediatorMock = new Mock<IMediator>();
        mediatorMock
            .Setup(m => m.Send(It.IsAny<UpdateProductCmd>(), default))
            .ReturnsAsync(true);

        var controller = new ProductsController(mediatorMock.Object);

        // Act
        var result = await controller.Update(productDto.Id, productDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
    
    [Fact]
    public async Task Update_ShouldReturnBadRequest_WhenIdMismatch()
    {
        // Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        var productDto = fixture.Build<ProductDto>()
            .OmitAutoProperties()
            .With(p => p.Id, 1)
            .Create();

        var mediatorMock = new Mock<IMediator>();
        var controller = new ProductsController(mediatorMock.Object);

        // Act
        var result = await controller.Update(999, productDto); // ID mismatch

        // Assert
        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("ID mismatch", badRequest.Value);
    }




}