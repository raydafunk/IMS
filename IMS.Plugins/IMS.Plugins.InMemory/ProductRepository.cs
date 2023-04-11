using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products;

namespace IMS.Plugins.InMemory
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
            if(_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;
            _products.Add(product);

            return Task.CompletedTask;
        }

        public async Task<Product> GetProductsByIdAsync(int productId)
        {
           var product = await Task.FromResult(_products.First(x => x.ProductId == productId));
            var newProduct = new Product
            {
                ProductId = productId,
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = product.Quantity,
            };
            return await Task.FromResult(newProduct);
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
            throw new NotImplementedException();
        }
    }
}
