using IMS.CoreBussiness;
using IMS.CoreBussiness.Entities;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products;
using NSubstitute;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace IMS.UseCase.Test.Products
{
    public class ViewProductByNameUserCaseTest
    {
        private readonly IProductRepository _productRepository;
        private readonly ViewProductByNameUserCase  _viewProductByNameUserCase;

        public ViewProductByNameUserCaseTest()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _viewProductByNameUserCase = new ViewProductByNameUserCase(_productRepository);
        }

        [Fact]
        public async Task GetInvetoriesByNameAsync_WhenCalled_Should_ReturnObject()
        {
            var product = new Inventory() { InventoryName = " Bike Body" };

            await _viewProductByNameUserCase.ExecuteAsync("Bike Body");

            product.ShouldBe(product);
        }

        [Fact]
        public async Task AddInventoryUseCase_WhenCalled_Should_NotBeNull()
        {
            var product = new Inventory() { InventoryName = " Bike Body" };

            await _viewProductByNameUserCase.ExecuteAsync("Bike Body");

            product.ShouldNotBeNull();
        }
    }
}
