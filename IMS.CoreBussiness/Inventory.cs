namespace IMS.CoreBussiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string InvetoryName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}