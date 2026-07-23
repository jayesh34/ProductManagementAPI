using Application.DTOs;
using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Moq;
using Xunit;

public class ProductServiceTests
{
    [Fact]
    public async Task GetByIdAsync_Returns_Product_When_Product_Exists()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            ProductName = "Laptop"
        };

        var productRepo = new Mock<IProductRepository>();

        productRepo
            .Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(product);

        var unitOfWork = new Mock<IUnitOfWork>();

        unitOfWork.Setup(x => x.Products)
                  .Returns(productRepo.Object);

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductMappingProfile>();
        });

        var mapper = mapperConfig.CreateMapper();

        var service = new ProductService(
            unitOfWork.Object,
            mapper);

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Laptop", result.ProductName);
    }
}