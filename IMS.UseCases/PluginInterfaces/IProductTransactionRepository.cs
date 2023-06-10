using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task<IEnumerable<ProductTransaction>> GetProductTranscationAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionTYpe);
        Task ProduceProductAsync(string productionNumber, Product product, int quantity, string doneby);
        Task SellProductAsync(string salesOrderNumber, Product product, int quantiy, double unitPrice, string doneBy);
    }
}