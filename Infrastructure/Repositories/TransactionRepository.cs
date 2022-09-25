using Domain.Aggregates.TransactionAggregate;
using Domain.Aggregates.TransactionAggregate.IRepository;
using Infrastructure.Db;
using MediatR;
using Utility;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : BaseRepository<ApplicationDbContext, Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<CommandExecutionResult> AddTransaction(Transaction transaction)
        {
            try
            {
                await Save(transaction);

                return new CommandExecutionResult() { Success = true };

            }
            catch (Exception ex)
            {
                return new CommandExecutionResult() { Success = false, ErrorMessage = ex.Message };
            }
        }
    }
}
