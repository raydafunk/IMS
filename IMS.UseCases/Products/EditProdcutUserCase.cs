using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Products
{
    public class EditProdcutUserCase : IEditProdcutUserCase
    {
        private readonly IProductRepository _productRepository;

        public EditProdcutUserCase(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task ExectueAsync(Product product)
        {
            await this._productRepository.UpdateProductAsync(product);
        }
    }
}
