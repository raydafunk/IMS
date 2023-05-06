using IMS.CoreBussiness.Entities;
using IMS.Plugins.InMemory;
using IMS.UseCases.PluginInterfaces;
using NSubstitute;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace IMS.UseCase.Test.Reposistory
{
    public class ProductTransactionRespositoryTest
    {
       
        private readonly IProductRepository _productRepo;
        public ProductTransactionRespositoryTest()
        {
           
            _productRepo = Substitute.For<IProductRepository>();

        }

        [Fact]
        public async Task ProduceProductAsync_Whencalled_Should_excuteGetProductsByIdAsync()
        {

            await _productRepo.GetProductsByIdAsync(1);
            _productRepo.Received();
        }
    }

}
