using IMS.CoreBussiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Purchase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Purchase
{
    public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
    {
        private readonly IInVentoryTransactionRespository _inVentoryTransactionRespository;
        private readonly IInVentoryRespository _inVentoryRespository;

        public PurchaseInventoryUseCase(IInVentoryTransactionRespository inVentoryTransactionRespository, IInVentoryRespository inVentoryRespository)
        {
            _inVentoryTransactionRespository = inVentoryTransactionRespository;
            _inVentoryRespository = inVentoryRespository;
        }
        public async Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneby)
        {
            //inseret a record in the transition table 
            //TODO: Create intergation test when i have setup a database
            _inVentoryTransactionRespository.PurchaseAsync(poNumber, inventory, quantity, doneby, inventory.Price);

            // increase the quantity
            inventory.Quantity += quantity;
            await _inVentoryRespository.UpdateInventoryAsync(inventory);
        }
    }
}
