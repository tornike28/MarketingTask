using Domain.Aggregates.TransactionAggregate;
using Domain.Aggregates.TransactionAggregate.IRepository;
using Infrastructure.Db;
using MediatR;
using Utility;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : BaseRepository<ApplicationDbContext,Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<CommandExecutionResult> AddTransaction(Transaction transaction)
        {
            try
            {
                _ApplicationDbContext.Set<Transaction>().Add(transaction);
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
