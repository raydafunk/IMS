using IMS.CoreBussiness;
using IMS.CoreBussiness.Validations;
using System.ComponentModel.DataAnnotations;

namespace IMS.UseCases.Products
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantitiy must be greater then or equal to 0")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater then or equal to 0")]
        public double Price { get; set; }

        [Proudct_EnsurePriceIsGreaterThanInventorisCost]
        public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

        public void AddInventory(Inventory inventory)
        {
            CheckInventorisExits(inventory);
        }

        private void CheckInventorisExits(Inventory inventory)
        {
            if (!ProductInventories.Any(x => x.Inventory != null &&
               x.Inventory.InventoryName.Equals(inventory.InventoryName)))
            {
                ProductInventories.Add(new ProductInventory
                {
                    InventoryId = inventory.InventoryId,
                    Inventory = inventory,
                    InventoryQuantity = 1,
                    Product = this
                });
            }
        }
    }
}