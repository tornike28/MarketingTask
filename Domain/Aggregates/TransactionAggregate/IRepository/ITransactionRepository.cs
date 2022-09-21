using Utility;

namespace Domain.Aggregates.TransactionAggregate.IRepository
{
    public interface ITransactionRepository
    {
        Task<CommandExecutionResult> AddTransaction(Transaction transaction);
    }
}
