﻿using IMS.UseCases.Products;

namespace IMS.CoreBussiness
{
    public  class ProductInventory
    {
        public int ProductId { get; set; }

        public Product? Product { get; set; }
        public int InventoryId { get; set; }
        public Product? Inventory { get; set; }
        public int InventoryQuantity { get; set; }
    }
}
