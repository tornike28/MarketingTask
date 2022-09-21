using Utility;

namespace Domain.Aggregates.ProductAggregate.IRepository
{
    public interface IProductRepository
    {
        Task<CommandExecutionResult> CreateProduct(Product product);
    }
}
