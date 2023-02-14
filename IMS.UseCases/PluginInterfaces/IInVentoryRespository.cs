using IMS.CoreBussiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInVentoryRespository
    {
        Task<IEnumerable<Inventory>> GetInvetoriesByNameAsync(string name);
        
    }
}