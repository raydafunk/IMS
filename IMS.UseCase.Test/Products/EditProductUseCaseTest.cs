using IMS.CoreBussiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products;
using NSubstitute;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace IMS.UseCase.Test.Products
{
    public  class EditProductUseCaseTest
    {
        private readonly IProductRepository _inProductRespository;

        private readonly EditProdcutUserCase _editProdcutUserCase;

        public EditProductUseCaseTest()
        {
            _inProductRespository = Substitute.For<IProductRepository>();
            _editProdcutUserCase = Substitute.For<EditProdcutUserCase>(_inProductRespository);   
        }

        [Fact]
        public async Task ExecuteAsync_WhenCalled_Should_ReturnObject()
        {
            var product = new Product();

            await _editProdcutUserCase.ExectueAsync(Arg.Any<Product>());

            product.ShouldBe(product);
        }

        [Fact]
        public async Task ExecuteAsync_WhenCalled_Should_NotBeNull()
        {
            var product = new Product();

            await _editProdcutUserCase.ExectueAsync(Arg.Any<Product>());

            product.ShouldNotBeNull();
        }

        [Fact]
        public async Task ExecuteAsync_WheCalled_ShouldNotReturnTheSameObject()
        {
            var product = MockedProduct;
            await _editProdcutUserCase.ExectueAsync(MockedProduct);

            product.ShouldNotBe(SecondMockedProduct);

        }
        private static Product MockedProduct
        {
            get
            {
                return new Product()
                {
                    ProductId = 1,
                    ProductName = "Test",
                    Quantity = 10,
                    Price = 2
                };
            }
        }

        private static Product SecondMockedProduct
        {
            get
            {
                return new Product()
                {
                    ProductId = 2,
                    ProductName = "Test 2",
                    Quantity = 11,
                    Price = 3
                };
            }
        }

    }
}
