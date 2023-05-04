using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IViewInventoriesByNameUserCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}