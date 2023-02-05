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
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price =2},
                new Inventory { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price =15},
                new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price =8},
                new Inventory { InventoryId = 4, InventoryName = "Bike Pedal", Quantity = 20, Price =1}
            };
        }
        public async Task<IEnumerable<Inventory>> GetInvetoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);
            
            return _inventories.Where( x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}