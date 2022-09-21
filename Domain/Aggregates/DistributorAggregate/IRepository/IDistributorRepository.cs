using Utility;

namespace Domain.Aggregates.DistributorAggregate.IRepository
{
    public interface IDistributorRepository
    {
        Task<CommandExecutionResult> CreateDistributor(Distributor distributor);
    }
}
