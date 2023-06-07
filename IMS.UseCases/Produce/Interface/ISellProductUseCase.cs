using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.Produce.Interface
{
    public interface ISellProductUseCase
    {
        Task ExecuteAsync(string salesOrderNumber, Product product, int quantiy, double unitPrice, string doneBy);
    }
}