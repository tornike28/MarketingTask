using Application.Shared;
using Domain.Aggregates.DistributorAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application.DistributorFeature.DistributorQueries
{
    public class GetDistributorsQuery : Query<GetDistributorsQueryResult>
    {
        public override async Task<QueryExecutionResult<GetDistributorsQueryResult>> Execute()
        {
            var distributors = await _appContext.Set<Distributor>()
                                                .ToListAsync();

            return await Ok(new GetDistributorsQueryResult() { Distributors = distributors});
        }
    }
    public class GetDistributorsQueryResult
    {
        public List<Distributor>? Distributors { get; internal set; }
    }
}
