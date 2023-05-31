using IMS.CoreBussiness.Entities;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public class EditInventoryUseCase : IEditInventoryUseCase
    {
        private readonly IInVentoryRespository inVentoryRespository;

        public EditInventoryUseCase(IInVentoryRespository inVentoryRespository)
        {
            this.inVentoryRespository = inVentoryRespository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await this.inVentoryRespository.UpdateInventoryAsync(inventory);
        }
    }
}
