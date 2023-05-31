using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInVentoryRespository
    {
        Task AddInventoryAsync(Inventory inventory);
         Task<Inventory> GetInvetoriesByIdAsync(int inventoryid);
        Task<IEnumerable<Inventory>> GetInvetoriesByNameAsync(string name);
        Task UpdateInventoryAsync(Inventory inventory);
    }
}