using IMS.CoreBussiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInVentoryRespository
    {
        Task AddInventoryAsync(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInvetoriesByNameAsync(string name);
        
    }
}