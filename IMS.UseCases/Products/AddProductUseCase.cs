﻿using IMS.CoreBussiness.Entities;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository _productRepository;
        public AddProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ExecuteAsync(Product product)
        {
            if (product == null) return;


            await this._productRepository.AddProductAsync(product);

        }
    }
}
