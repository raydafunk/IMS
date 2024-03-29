﻿using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<Product> GetProductsByIdAsync(int productId);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
        Task UpdateProductAsync(Product product);
    }
}