using IMS.UseCases.PluginInterfaces;
using NSubstitute;

namespace IMS.UseCase.Test.Purchase
{
    public class ProduceProductUseTest
    {
        private readonly IInVentoryTransactionRespository _inVentoryTransactionRespository;
        private readonly IInVentoryRespository _inVentoryRespository;

        public ProduceProductUseTest()
        {
            _inVentoryTransactionRespository = Substitute.For<IInVentoryTransactionRespository>();
            _inVentoryRespository = Substitute.For<IInVentoryRespository>();
        }
        
    }
}
