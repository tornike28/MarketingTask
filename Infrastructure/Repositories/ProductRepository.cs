using Domain.Aggregates.ProductAggregate;
using Domain.Aggregates.ProductAggregate.IRepository;
using Infrastructure.Db;
using MediatR;
using Utility;

namespace Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<ApplicationDbContext, Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<CommandExecutionResult> CreateProduct(Product product)
        {
            try
            {
                _ApplicationDbContext.Set<Product>().Add(product);
                _ApplicationDbContext.SaveChanges();

                return new CommandExecutionResult() { ResultId = "3" };

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
