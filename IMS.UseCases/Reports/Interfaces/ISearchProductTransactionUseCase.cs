using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;

namespace IMS.UseCases.Reports.Interfaces
{
    public interface ISearchProductTransactionUseCase
    {
        Task<IEnumerable<ProductTransaction>> ExeuteAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionTYpe);
    }
}