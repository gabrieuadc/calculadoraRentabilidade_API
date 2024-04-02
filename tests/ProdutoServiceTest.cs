using Moq;
using prodrentapi.services;
using Xunit;
using prodrentapi.Models;


namespace prodrentapi.tests;
    public class ProdutoServiceTest
    {
        [Fact]
        public async Task GetAsync_Returns_All_Products()
        {
            var mockProducts = MockProducts();

            var mockService = new Mock<IProdutoService>();
            mockService.Setup(x => x.GetAsync()).ReturnsAsync(mockProducts);

            var service = mockService.Object;

            var result = await service.GetAsync();

            Assert.Equal(mockProducts, result);
        }

        private List<ProdutoModel> MockProducts()
        {
            return new List<ProdutoModel>
            {
                new ProdutoModel { id = "1", Nome = "Product 1" },
                new ProdutoModel { id = "2", Nome = "Product 2" },
                new ProdutoModel { id = "3", Nome = "Product 3" }
            };
        }
    }