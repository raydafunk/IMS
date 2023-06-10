using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Reports.Interfaces;

namespace IMS.UseCases.Reports
{
    public class SearchInventoryTranscationUseCase : ISearchInventoryTranscationUseCase
    {
        private readonly IInVentoryTransactionRespository _inVentoryTransactionRespository;

        public SearchInventoryTranscationUseCase(IInVentoryTransactionRespository inVentoryTransactionRespository)
        {
            _inVentoryTransactionRespository = inVentoryTransactionRespository;
        }
        public async Task<IEnumerable<InventoryTransaction>> ExeuteAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionTYpe)
        {
            if (dateTo.HasValue) dateTo = dateTo.Value.AddDays(1);
            return await _inVentoryTransactionRespository.GetInventoryTranscationAsync(inventoryName, dateFrom, dateTo, transactionTYpe);
        }
    }
}
