using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using AutoMapper;
using ECommerce.TechnicalTest.Data.Entities;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.DTO;
using ECommerce.TechnicalTest.Domain.Products.Commands;
using ECommerce.TechnicalTest.Domain.Products.Handlers;
using FluentAssertions;
using Moq;
using Xunit;
namespace ECommerce.TechnicalTest.UnitTests;

public class CreateProductTest
{
    [Fact]
    public async Task Handle_ShouldCreateProductAndReturnDto()
    {
        // Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        var unitOfWorkMock = fixture.Freeze<Mock<IUnitOfWork>>();
        var mapperMock = fixture.Freeze<Mock<IMapper>>();

        string name = fixture.Create<string>();
        decimal price = fixture.Create<decimal>();
        
        var productDto = fixture.Build<ProductDto>()
            .OmitAutoProperties() 
            .With(p => p.Name,name)
            .With(p => p.Price, price)
            .Create();
        
        var productEntity = fixture.Build<Product>()
            .OmitAutoProperties() 
            .With(p => p.Name, name)
            .With(p => p.Price, price)
            .Create();



        mapperMock.Setup(m => m.Map<Product>(productDto)).Returns(productEntity);
        mapperMock.Setup(m => m.Map<ProductDto>(productEntity)).Returns(productDto);

        unitOfWorkMock.Setup(u => u.Products.AddAsync(productEntity)).Returns(Task.CompletedTask);
        unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

        var handler = new CreateProductHandler(unitOfWorkMock.Object, mapperMock.Object);
        var command = new CreateProductCommand(productDto);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(productDto.Name);
        unitOfWorkMock.Verify(u => u.Products.AddAsync(productEntity), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task Handle_ShouldThrowException_WhenSaveFails()
    {
        // Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        var unitOfWorkMock = fixture.Freeze<Mock<IUnitOfWork>>();
        var mapperMock = fixture.Freeze<Mock<IMapper>>();

        string name = fixture.Create<string>();
        decimal price = fixture.Create<decimal>();
        var productDto = fixture.Build<ProductDto>()
            .OmitAutoProperties() 
            .With(p => p.Name,name)
            .With(p => p.Price, price)
            .Create();
        
        var productEntity = fixture.Build<Product>()
            .OmitAutoProperties() 
            .With(p => p.Name, name)
            .With(p => p.Price, price)
            .Create();
        
        mapperMock.Setup(m => m.Map<Product>(productDto)).Returns(productEntity);
        mapperMock.Setup(m => m.Map<ProductDto>(productEntity)).Returns(productDto);

        unitOfWorkMock.Setup(u => u.Products.AddAsync(productEntity)).Returns(Task.CompletedTask);
        unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ThrowsAsync(new Exception("Error connecting to the database"));

        var handler = new CreateProductHandler(unitOfWorkMock.Object, mapperMock.Object);
        var command = new CreateProductCommand(productDto);

        // Act & Assert
        await FluentActions
            .Invoking(() => handler.Handle(command, CancellationToken.None))
            .Should()
            .ThrowAsync<Exception>()
            .WithMessage("Error connecting to the database");
    }


}
