using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task ProduceProductAsync(string productionNumber, Product product, int quantity, string doneby);
        Task SellProductAsync(string salesOrderNumber, Product product, int quantiy, string doneBy);
    }
}