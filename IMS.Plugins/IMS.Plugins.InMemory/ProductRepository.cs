using IMS.CoreBussiness.Entities;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.EFCoreSqlServer
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product(){ProductId = 1, ProductName = "Bike", Quantity = 10, Price = 150},
                new Product(){ProductId = 1, ProductName = "Car", Quantity = 5, Price = 25000},
            };
        }

        public Task AddProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;
            _products.Add(product);

            return Task.CompletedTask;
        }

        public async Task<Product> GetProductsByIdAsync(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            var newProduct = new Product();
            CheckProduct(product, newProduct);
            return await Task.FromResult(newProduct);
        }

        private static void CheckProduct(Product? product, Product newProduct)
        {
            /// checking to see if the product is not empty then build up the product
            if (product != null)
            {
                newProduct.ProductId = product.ProductId;
                newProduct.ProductName = product.ProductName;
                newProduct.Price = product.Price;
                newProduct.Quantity = product.Quantity;
                newProduct.ProductInventories = new List<ProductInventory>();
                CheckProductListInventoris(product, newProduct);
            }
        }

        private static void CheckProductListInventoris(Product? product, Product newProduct)
        {
            /// checking to see if the productListinventories  is not empty then build up theProductListInventoris
            if (product!.ProductInventories != null && product.ProductInventories.Count > 0)
            {
                foreach (var productInventory in product.ProductInventories)
                {
                    var productInv = new ProductInventory()
                    {
                        InventoryId = productInventory.InventoryId,
                        ProductId = productInventory.ProductId,
                        Product = product,
                        Inventory = new Inventory(),
                        InventoryQuantity = productInventory.InventoryQuantity,
                    };
                    CheckInventoris(newProduct, productInventory, productInv);
                }
            }
        }

        private static void CheckInventoris(Product newProduct, ProductInventory productInventory, ProductInventory productInv)
        {
            /// checking to see if the inventories  is not empty then build up Inventoris
            if (productInv.Inventory != null)
            {
                productInv.Inventory.InventoryId = productInventory.InventoryId;
                productInv.Inventory.InventoryName = productInventory.Inventory!.InventoryName;
                productInv.Inventory!.Price = productInventory.Inventory!.Price;
                productInv.Inventory!.Quantity = productInventory.Inventory!.Quantity;
            }
            newProduct.ProductInventories.Add(productInv);
        }

        /// <summary>
        /// get all the products in the repo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_products);
            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateProductAsync(Product product)
        {
            return GetDifferentProductbyId(product);
        }

        private Task GetDifferentProductbyId(Product product)
        {
            // dont allow the same inventories to have the same name
            if (_products.Any(x => x.ProductId != product.ProductId
                  && x.ProductName.ToLower() == product.ProductName.ToLower()))
                return Task.CompletedTask;

            var prod = _products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                prod.ProductInventories = product.ProductInventories;
            }
            return Task.CompletedTask;
        }
    }
}
