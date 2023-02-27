using IMS.CoreBussiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
    {
        private readonly IInVentoryRespository _inventoryRespository;

        public ViewInventoryByIdUseCase(IInVentoryRespository inVentoryRespository)
        {
            this._inventoryRespository = inVentoryRespository;
        }
        public async Task<Inventory> ExeuteAysnc(int inventoryid)
        {
            return await _inventoryRespository.GetInvetoriesByIdAsync(inventoryid);
        }
    }
}
