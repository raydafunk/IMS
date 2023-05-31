using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.Produce.Interface
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneby);
    }
}