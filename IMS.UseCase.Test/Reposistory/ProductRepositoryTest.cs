using IMS.CoreBussiness;
using IMS.UseCases.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCase.Test.Reposistory
{
    public  class ProductRepositoryTest
    {
        private readonly ProductInventory _repo;

        public ProductRepositoryTest()
        {
            _repo= new ProductInventory();  
        }

        private static Product MockedProduct
        {
            get
            {
                return new Product()
                {
                    ProductId = 1,
                    ProductName = "Test",
                    Quantity = 10,
                    Price = 2
                };
            }
        }

        private static Product SecondMockedProduct
        {
            get
            {
                return new Product()
                {
                    ProductId = 2,
                    ProductName = "Test 2",
                    Quantity = 11,
                    Price = 3
                };
            }
        }
    }


}
