using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;

namespace IMS.UseCases.Reports.Interfaces
{
    public interface ISearchInventoryTranscationUseCase
    {
        Task<IEnumerable<InventoryTransaction>> ExeuteAsync(string inventoryName, DateTime? datefrom, DateTime? dateto, InventoryTransactionType? transactionTYpe);
    }
}