namespace IMS.UseCases.Products.Interfaces
{
    public interface IViewProductByNameUserCase
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name = "");
    }
}