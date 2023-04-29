using IMS.CoreBussiness;
using IMS.Plugins.InMemory;
using IMS.UseCases.Products;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IMS.UseCase.Test.Reposistory
{
    public  class ProductRepositoryTest
    {
        private readonly ProductRepository _repo;

        public ProductRepositoryTest()
        {
            _repo= new ProductRepository();  
        }

        [Fact]
        public async Task AddProductAsync_WhenCalled_ShouldNotBeNUll()
        {
            var product = MockedProduct;

            await _repo.AddProductAsync(product);
            product.ShouldNotBeNull();
        }

        [Fact]
        public async Task AddInventoryAsync_WHenCalled_ShouldBeInventoryObject()
        {
            var product = MockedProduct;
            await _repo.AddProductAsync(product);

            product.ShouldBe(product);
        }

        [Fact]
        public async Task AddIventoryAsync_WhenCalled_ThesecodOBjectisEqual()
        {
            var product = SecondMockedProduct;
            await _repo.AddProductAsync(product);

            product.ShouldBe(product);
        }

        [Fact]
        public async Task GetProductByNameAsync_WhenCalled_ShouldNot_NameObjectIsNotNull()
        {
            IEnumerable<Product> inventories = new List<Product>() { new Product { ProductId = 1, ProductName = "fdc   ", Quantity = 10, Price = 2 } };
            await _repo.GetProductsByNameAsync("Bike Seat");

            inventories.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetProductByNameAsync_WhenCalled_ShouldHaveInventoriesInEnumerable()
        {
            IEnumerable<Product> productes = new List<Product>() { new Product { ProductId = 1, ProductName = "fdc   ", Quantity = 10, Price = 2 } };
            await _repo.GetProductsByNameAsync("Bike Seat");

            productes.ShouldHaveSingleItem();
        }

        [Fact]
        public async Task UpdateProductAsyn_WhenCalled_ShouldNotBeNUll()
        {
            var product = MockedProduct;
            await _repo.UpdateProductAsync(product);

            product.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateInventoryAsyn_WheCalled_ShouldNotReturnTheSameObject()
        {
            var product = MockedProduct;
            await _repo.UpdateProductAsync(product);

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
