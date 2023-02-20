using IMS.CoreBussiness;
using IMS.UseCases.PluginInterfaces;
using System.Security.Cryptography.X509Certificates;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInVentoryRespository
    {
        private readonly List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "fdc   ", Quantity = 10, Price =2},
                new Inventory { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price =15},
                new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price =8},
                new Inventory { InventoryId = 4, InventoryName = "Bike Pedal", Quantity = 20, Price =1}
            };
        }
        // add the inventory 
        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;
            _inventories.Add(inventory);

            return Task.CompletedTask;
        }
        //get by name
        public async Task<IEnumerable<Inventory>> GetInvetoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            // dont allow the same inventories to have the same name
            if (_inventories.Any(x => x.InventoryId == inventory.InventoryId 
                  && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                 return Task.CompletedTask;

           var inv = _inventories.FirstOrDefault(x => x.InventoryId== inventory.InventoryId);
            if ( inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
            }
            return Task.CompletedTask;
        }
    }
}