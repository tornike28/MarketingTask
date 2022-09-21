using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.DistributorAggregate.IRepository;
using Infrastructure.Db;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Infrastructure.Repositories
{
    public class DistributorRepository : BaseRepository<ApplicationDbContext, Distributor>, IDistributorRepository
    {
        public DistributorRepository(ApplicationDbContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<CommandExecutionResult> CreateDistributor(Distributor distributor)
        {

            await Save(distributor);

            return new CommandExecutionResult() { ErrorMessage = "654" };
        }
    }
}
