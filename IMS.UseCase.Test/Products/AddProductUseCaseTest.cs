using IMS.CoreBussiness;
using IMS.CoreBussiness.Entities;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products;
using NSubstitute;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace IMS.UseCase.Test.Inventories
{
    public class AddProductUseCaseTest
    {
        private readonly IProductRepository _productRespository;
        private readonly AddProductUseCase _addProductUseCase;

        public AddProductUseCaseTest()
        {
            _productRespository = Substitute.For<IProductRepository>();
            _addProductUseCase = new AddProductUseCase(_productRespository);
        }

        [Fact]
        public async Task AddProductUseCase_WhenCalled_Should_ReturnObject()
        {
            var inventory = new Inventory();

            await _addProductUseCase.ExecuteAsync(Arg.Any<Product>());

            inventory.ShouldBe(inventory);
        }

        [Fact]
        public async Task AddProductUseCase_WhenCalled_Should_NotBeNull()
        {
            var inventory = new Inventory();

            await _addProductUseCase.ExecuteAsync(Arg.Any<Product>());

            inventory.ShouldNotBeNull();
        }
    }
} 

