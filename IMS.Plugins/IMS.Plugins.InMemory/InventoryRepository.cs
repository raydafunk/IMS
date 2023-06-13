using IMS.CoreBussiness.Entities;
using IMS.UseCases.PluginInterfaces;
using System.Net.WebSockets;
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
                new Inventory { InventoryId = 1, InventoryName = "Bike Seats   ", Quantity = 10, Price =2},
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

        public async Task<Inventory> GetInvetoriesByIdAsync(int inventoryid)
        {
            var inventory = await Task.FromResult(_inventories.First(x => x.InventoryId == inventoryid));
            var newInventory= new Inventory
            {
                InventoryId = inventoryid,
                InventoryName = inventory.InventoryName,
                Price = inventory.Price,
                Quantity = inventory.Quantity,
            };
            return await Task.FromResult(newInventory);
        }

        //get by name
        public async Task<IEnumerable<Inventory>> GetInvetoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            return GetDifferentInvetoriesByid(inventory);
        }

        private Task GetDifferentInvetoriesByid(Inventory inventory)
        {
            // dont allow the same inventories to have the same name
            if (_inventories.Any(x => x.InventoryId == inventory.InventoryId
                  && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var inv = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
            }
            return Task.CompletedTask;
        }
    }
}