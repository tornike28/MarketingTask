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
               await Save(product);

                return new CommandExecutionResult() { Success = true };

            }
            catch (Exception ex)
            {
                return new CommandExecutionResult() { Success = false, ErrorMessage = ex.Message };
            }
        }
    }
}
