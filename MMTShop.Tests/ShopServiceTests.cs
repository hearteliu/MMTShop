using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMTShop.DTO;
using MMTShop.Interfaces;
using MMTShop.Models;
using MMTShop.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShop.Tests
{
    [TestClass]
    public class ShopServiceTestBase
    {
        protected IShopService shopService;

        protected Mock<IDatabaseService> databaseServiceMock = new Mock<IDatabaseService>();

        protected Mock<IDtoConverterService> dtoConverterServiceMock = new Mock<IDtoConverterService>();

        protected Mock<ILogger<ShopService>> loggerMock = new Mock<ILogger<ShopService>>();

        protected const string categoryName = "Home";

        protected const string SKU = "10001";

        protected const string name = "Table";

        protected const string description = "Wooden table description";

        protected const int price = 99;

        public void Setup()
        {
            shopService =
                new ShopService(databaseServiceMock.Object, dtoConverterServiceMock.Object, loggerMock.Object);
        }

    }

    [TestClass]
    public class When_Getting_Featured_Products : ShopServiceTestBase
    {
        protected List<ProductDTO> productDTOs = new List<ProductDTO>();

        protected ProductDTO firstTestProductDTO;

        protected ProductDTO secondTestProductDto;

        protected ProductModel firstProductModel;

        public When_Getting_Featured_Products()
        {
            firstTestProductDTO = new ProductDTO()
                {
                    SKU = SKU,
                    Name = name,
                    Description = description,
                    Price = price
                };

            secondTestProductDto = new ProductDTO();

            firstProductModel = new ProductModel()
                {
                    SKU = SKU,
                    Name = name,
                    Description = description,
                    Price = price
                };

            base.Setup();
        }

        [TestMethod]
        public async Task We_Should_Call_Database_Service()
        {
            // arrange
            databaseServiceMock.Setup(x => x.GetFeaturedProducts()).ReturnsAsync(productDTOs);

            // act
            await shopService.GetFeaturedProducts();

            // assert
            databaseServiceMock.Verify(x => x.GetFeaturedProducts(), Times.Once());
        }

        [TestMethod]
        public async Task We_Should_Get_The_Correct_Results()
        {
            // arrange

            productDTOs.Add(firstTestProductDTO);

            databaseServiceMock.Setup(x => x.GetFeaturedProducts()).ReturnsAsync(productDTOs);

            dtoConverterServiceMock.Setup(
                x => x.ConvertDtoToProductModel(firstTestProductDTO)).Returns(firstProductModel);

            // act
            var result = await shopService.GetFeaturedProducts();

            // assert
            result[0].SKU.Should().BeEquivalentTo(SKU);
            result[0].Name.Should().BeEquivalentTo(name);
            result[0].Description.Should().BeEquivalentTo(description);
            result[0].Price.Should().Be(price);
        }

        [TestMethod]
        public async Task We_Should_Not_Call_Converter_Service_With_No_Dtos()
        {
            // arrange
            databaseServiceMock.Setup(x => x.GetFeaturedProducts()).ReturnsAsync(productDTOs);

            // act
            await shopService.GetFeaturedProducts();

            // assert
            dtoConverterServiceMock.Verify(x => x.ConvertDtoToProductModel(It.IsAny<ProductDTO>()), Times.Never);
        }

        [TestMethod]
        public async Task We_Should_Call_Converter_Service_When_We_Have_Dtos()
        {
            // arrange

            productDTOs.Add(firstTestProductDTO);

            databaseServiceMock.Setup(x => x.GetFeaturedProducts()).ReturnsAsync(productDTOs);

            // act
            await shopService.GetFeaturedProducts();

            // assert
            dtoConverterServiceMock.Verify(x => x.ConvertDtoToProductModel(firstTestProductDTO), Times.Once);
        }

        [TestMethod]
        public async Task We_Should_Call_Converter_Service_For_Each_Dto()
        {
            // arrange

            productDTOs.Add(firstTestProductDTO);

            productDTOs.Add(secondTestProductDto);

            databaseServiceMock.Setup(x => x.GetFeaturedProducts()).ReturnsAsync(productDTOs);

            // act
            await shopService.GetFeaturedProducts();

            // assert
            dtoConverterServiceMock.Verify(x => x.ConvertDtoToProductModel(It.IsAny<ProductDTO>()), Times.Exactly(2));
        }
    }

    [TestClass]
    public class When_Getting_Categories : ShopServiceTestBase
    {
        protected List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

        protected CategoryDTO firstTestCategoryDTO;

        protected CategoryDTO secondTestCategoryDto;

        protected CategoryModel firstCategoryModel;

        public When_Getting_Categories()
        {
            firstTestCategoryDTO = new CategoryDTO()
                {
                    Name = categoryName
                };

            secondTestCategoryDto = new CategoryDTO();

            firstCategoryModel = new CategoryModel()
                {
                    Name = categoryName
                };

            base.Setup();
        }

        [TestMethod]
        public async Task We_Should_Call_Database_Service()
        {
            // arrange
            databaseServiceMock.Setup(x => x.GetCategories()).ReturnsAsync(categoryDTOs);

            // act
            await shopService.GetCategories();

            // assert
            databaseServiceMock.Verify(x => x.GetCategories(), Times.Once());
        }

        [TestMethod]
        public async Task We_Should_Get_The_Correct_Results()
        {
            // arrange

            categoryDTOs.Add(firstTestCategoryDTO);

            databaseServiceMock.Setup(x => x.GetCategories()).ReturnsAsync(categoryDTOs);

            dtoConverterServiceMock.Setup(
                x => x.ConvertDtoToCategoryModel(firstTestCategoryDTO)).Returns(firstCategoryModel);

            // act
            var result = await shopService.GetCategories();

            // assert
            result[0].Name.Should().BeEquivalentTo(categoryName);
        }

        [TestMethod]
        public async Task We_Should_Not_Call_Converter_Service_With_No_Dtos()
        {
            // arrange
            databaseServiceMock.Setup(x => x.GetCategories()).ReturnsAsync(categoryDTOs);

            // act
            await shopService.GetCategories();

            // assert
            dtoConverterServiceMock.Verify(x => x.ConvertDtoToCategoryModel(It.IsAny<CategoryDTO>()), Times.Never);
        }

        [TestMethod]
        public async Task We_Should_Call_Converter_Service_When_We_Have_Dtos()
        {
            // arrange

            categoryDTOs.Add(firstTestCategoryDTO);

            databaseServiceMock.Setup(x => x.GetCategories()).ReturnsAsync(categoryDTOs);

            // act
            await shopService.GetCategories();

            // assert
            dtoConverterServiceMock.Verify(x => x.ConvertDtoToCategoryModel(firstTestCategoryDTO), Times.Once);
        }

        [TestMethod]
        public async Task We_Should_Call_Converter_Service_For_Each_Dto()
        {
            // arrange

            categoryDTOs.Add(firstTestCategoryDTO);

            categoryDTOs.Add(secondTestCategoryDto);

            databaseServiceMock.Setup(x => x.GetCategories()).ReturnsAsync(categoryDTOs);

            // act
            await shopService.GetCategories();

            // assert
            dtoConverterServiceMock.Verify(x => x.ConvertDtoToCategoryModel(It.IsAny<CategoryDTO>()), Times.Exactly(2));
        }
    }

    [TestClass]
    public class When_Getting_Products_By_Category_Name : ShopServiceTestBase
    {
        protected List<ProductDTO> productDTOs = new List<ProductDTO>();

        protected ProductDTO firstTestProductDTO = new ProductDTO();

        protected ProductDTO secondTestProductDto = new ProductDTO();

        protected ProductModel firstProductModel;

        public When_Getting_Products_By_Category_Name()
        {
            firstTestProductDTO = new ProductDTO()
            {
                SKU = SKU,
                Name = name,
                Description = description,
                Price = price
            };

            secondTestProductDto = new ProductDTO();

            firstProductModel = new ProductModel()
            {
                SKU = SKU,
                Name = name,
                Description = description,
                Price = price
            };

            base.Setup();
        }

        [TestMethod]
        public async Task We_Should_Call_Database_Service()
        {
            // arrange
            databaseServiceMock.Setup(
                x => x.GetProductsByCategoryName(categoryName)).ReturnsAsync(productDTOs);

            // act
            await shopService.GetProductsByCategoryName(categoryName);

            // assert
            databaseServiceMock.Verify(x => x.GetProductsByCategoryName(categoryName), Times.Once());
        }

        [TestMethod]
        public async Task We_Should_Get_The_Correct_Results()
        {
            // arrange

            productDTOs.Add(firstTestProductDTO);

            databaseServiceMock.Setup(
                x => x.GetProductsByCategoryName(categoryName)).ReturnsAsync(productDTOs);

            dtoConverterServiceMock.Setup(
                x => x.ConvertDtoToProductModel(firstTestProductDTO)).Returns(firstProductModel);

            // act
            var result = await shopService.GetProductsByCategoryName(categoryName);

            // assert
            result[0].SKU.Should().BeEquivalentTo(SKU);
            result[0].Name.Should().BeEquivalentTo(name);
            result[0].Description.Should().BeEquivalentTo(description);
            result[0].Price.Should().Be(price);
        }

        [TestMethod]
        public async Task We_Should_Not_Call_Converter_Service_With_No_Dtos()
        {
            // arrange
            databaseServiceMock.Setup(
                x => x.GetProductsByCategoryName(categoryName)).ReturnsAsync(productDTOs);

            // act
            await shopService.GetProductsByCategoryName(categoryName);

            // assert
            dtoConverterServiceMock.Verify(x => x.ConvertDtoToProductModel(It.IsAny<ProductDTO>()), Times.Never);
        }

        [TestMethod]
        public async Task We_Should_Call_Converter_Service_When_We_Have_Dtos()
        {
            // arrange

            productDTOs.Add(firstTestProductDTO);

            databaseServiceMock.Setup(
                x => x.GetProductsByCategoryName(categoryName)).ReturnsAsync(productDTOs);

            // act
            await shopService.GetProductsByCategoryName(categoryName);

            // assert
            dtoConverterServiceMock.Verify(x => x.ConvertDtoToProductModel(firstTestProductDTO), Times.Once);
        }

        [TestMethod]
        public async Task We_Should_Call_Converter_Service_For_Each_Dto()
        {
            // arrange

            productDTOs.Add(firstTestProductDTO);

            productDTOs.Add(secondTestProductDto);

            databaseServiceMock.Setup(
                x => x.GetProductsByCategoryName(categoryName)).ReturnsAsync(productDTOs);

            // act
            await shopService.GetProductsByCategoryName(categoryName);

            // assert
            dtoConverterServiceMock.Verify(x => x.ConvertDtoToProductModel(It.IsAny<ProductDTO>()), Times.Exactly(2));
        }
    }
}
