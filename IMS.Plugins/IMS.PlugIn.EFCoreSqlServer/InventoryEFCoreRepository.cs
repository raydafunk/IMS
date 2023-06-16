using IMS.CoreBussiness.Entities;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.PlugIn.EFCoreSqlServer
{
    public class InventoryEFCoreRepository : IInVentoryRespository
    {
        private readonly IDbContextFactory<IMSDbContext> _contextFactory;

        public InventoryEFCoreRepository(IDbContextFactory<IMSDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }
        // add the inventory 
        public async Task AddInventoryAsync(Inventory inventory)
        {
            using var db = this._contextFactory.CreateDbContext();
            db.Inventories.Add(inventory);

            await db.SaveChangesAsync();



        }

        //get by name
        public async Task<IEnumerable<Inventory>> GetInvetoriesByNameAsync(string name)
        {
            using var db = this._contextFactory.CreateDbContext();
            return await db.Inventories.Where(x => x.InventoryName
            .ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();
        }

        public async Task<Inventory> GetInvetoriesByIdAsync(int inventoryid)
        {
            using var db = this._contextFactory.CreateDbContext();
            var invetnory = await db.Inventories.FindAsync(inventoryid);
            if(invetnory != null) return invetnory;

            return new Inventory();
        }

      

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            using var db = this._contextFactory.CreateDbContext();
            var inv = await db.Inventories.FindAsync(inventory.InventoryId);
            if(inv != null) 
            { 
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
                
                await db.SaveChangesAsync();
            }
        }
    }
}