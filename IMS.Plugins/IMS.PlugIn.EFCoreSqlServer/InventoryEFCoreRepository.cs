using IMS.CoreBussiness.Entities;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
namespace IMS.PlugIn.EFCoreSqlServer
{
    public class InventoryEFCoreRepository : IInVentoryRespository
    {
        private readonly IMSDbContext _db;
        public InventoryEFCoreRepository(IMSDbContext db)
        {
            _db = db;
        }
        // add the inventory 
        public async Task AddInventoryAsync(Inventory inventory)
        {
            this._db.Inventories.Add(inventory);
            await _db.SaveChangesAsync();
        }

        //get by name
        public async Task<IEnumerable<Inventory>> GetInvetoriesByNameAsync(string name)
        {
            return await this._db.Inventories.Where(x => x.InventoryName
            .ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();
        }

        public async Task<Inventory> GetInvetoriesByIdAsync(int inventoryid)
        {
           var invetnory = await this._db.Inventories.FindAsync(inventoryid);
            if(invetnory != null) return invetnory;

            return new Inventory();
        }

      

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            var inv = await _db.Inventories.FindAsync(inventory.InventoryId);
            if(inv != null) 
            { 
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
                
                await _db.SaveChangesAsync();
            }
        }
    }
}