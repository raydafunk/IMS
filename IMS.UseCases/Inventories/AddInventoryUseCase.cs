using IMS.CoreBussiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
    public class AddInventoryUseCase : IAddInventoryUseCase
    {
        private readonly IInVentoryRespository inVentoryRespository;

        public AddInventoryUseCase(IInVentoryRespository inVentoryRespository)
        {
            this.inVentoryRespository = inVentoryRespository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await this.inVentoryRespository.AddInventoryAsync(inventory);
        }
    }
}
