using IMS.CoreBussiness.Entities;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
    public class ViewInventoriesByNameUserCase : IViewInventoriesByNameUserCase
    {
        private readonly IInVentoryRespository _inVentoryRespository;

        public ViewInventoriesByNameUserCase(IInVentoryRespository inVentoryRespository)
        {
            _inVentoryRespository = inVentoryRespository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await _inVentoryRespository.GetInvetoriesByNameAsync(name);
        }
    }
}
