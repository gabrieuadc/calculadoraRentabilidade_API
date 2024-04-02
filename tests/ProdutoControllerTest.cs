using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using prodrentapi.Controllers;
using prodrentapi.Models;
using prodrentapi.services;
namespace prodrentapi.tests;

public class ProdutoControllerTest
{
    [Fact]
    public async Task GetAll_Returns_All_Products()
    {
        // Mock dos produtos
        var mockProducts = MockProducts();

        // Configuração do mock do serviço
        var mockService = new Mock<IProdutoService>();
        mockService.Setup(x => x.GetAsync()).ReturnsAsync(mockProducts);

        // Instanciando o controlador com o mock do serviço
        var controller = new ProdutoController(mockService.Object);

        // Chamando o método do controlador
        var result = await controller.Get();

        var actionResult = Assert.IsType<ActionResult<List<ProdutoModel>>>(result);
        var model = Assert.IsAssignableFrom<List<ProdutoModel>>(actionResult.Value);
        Assert.Equal(mockProducts, model);
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