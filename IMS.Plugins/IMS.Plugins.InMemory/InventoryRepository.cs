using IMS.CoreBussiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInVentoryRespository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InvetoryName = "Bike Seat", Quantity = 10, Price =2},
                new Inventory { InventoryId = 2, InvetoryName = "Bike Body", Quantity = 10, Price =15},
                new Inventory { InventoryId = 3, InvetoryName = "Bike Wheels", Quantity = 20, Price =8},
                new Inventory { InventoryId = 4, InvetoryName = "Bike Pedal", Quantity = 20, Price =1}
            };
        }
        public async Task<IEnumerable<Inventory>> GetInvetoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);
            
            return _inventories.Where( x => x.InvetoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}