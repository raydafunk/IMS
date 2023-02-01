using IMS.CoreBussiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IViewInventoriesByNameUserCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}