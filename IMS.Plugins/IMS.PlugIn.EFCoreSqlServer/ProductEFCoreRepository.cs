using IMS.CoreBussiness.Entities;
using IMS.PlugIn.EFCoreSqlServer;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.InMemory
{
    public class ProductEFCoreRepository : IProductRepository
    {
        private readonly IMSDbContext _db;

        public ProductEFCoreRepository(IMSDbContext db)
        {
            this._db = db;
        }
        //  add products
        public async Task AddProductAsync(Product product)
        {
            CheckforProductInventorisOnChanged(product, this._db);
            await this._db.SaveChangesAsync();
        }

        // get the id 
        public async Task<Product?> GetProductsByIdAsync(int productId)
        {
            return await this._db.Products.Include(x => x.ProductInventories)
                             .ThenInclude(x => x.Inventory)
                             .FirstOrDefaultAsync(x => x.ProductId == productId);
        }
         // get the name 
        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await _db.Products.Where(x => x.ProductName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();
        }

        // update the name
        public async Task UpdateProductAsync(Product product)
        {
            var prod = await this._db.Products
                 .Include(x => x.ProductInventories).FirstOrDefaultAsync(x => x.ProductId == product.ProductId);

            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                prod.ProductInventories = product.ProductInventories;
                CheckforProductInventorisOnChanged(product, this._db);

                await this._db.SaveChangesAsync();
            }
        }
        private void CheckforProductInventorisOnChanged(Product product, IMSDbContext _db)
        {
            if (product?.ProductInventories != null && product.ProductInventories.Count > 0)
            {
                foreach (var productinv in product.ProductInventories)
                {
                    if (productinv.Inventory != null)
                        _db.Entry(productinv.Inventory).State = EntityState.Unchanged;
                }
            }
        }

    }
}
