using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Domain.Aggregates.DistributorAggregate.IRepository
{
    public interface IDistributorRepository
    {
        Task<CommandExecutionResult> CreateDistributor(Distributor distributor);
    }
}
