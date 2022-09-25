using Application.Shared;
using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application.Features.DistributorFeature.DistributorQueries
{
    public class CalculationQuery : Query<CalculationQueryResult>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public override async Task<QueryExecutionResult<CalculationQueryResult>> Execute()
        {
            List<DistributorBonus> DistributorBonuses = new();

            var distributors = _appContext.Set<Distributor>()
                                          .WhereIfHas(FirstName, x => x.FirstName.Contains(FirstName))
                                          .WhereIfHas(LastName, x => x.FirstName.Contains(LastName)).ToList();


            var activeTransaction = _appContext.Set<Transaction>()
                                               .Where(x => x.SaleDate >= From && x.SaleDate <= To).ToList();

            foreach (var distributor in distributors)
            {
                var distributorbonus = (activeTransaction.Where(x => x.DistributorId == distributor.Id).Sum(x => x.TotalPrice)) * 0.1;

                if (distributor.Recomendations.Count() > 0)
                {
                    if (distributor.Recomendations.Any(x => x.HierarchyLevel == 1))
                        distributorbonus += (activeTransaction.Where(x => (distributor.Recomendations.Where(x => x.HierarchyLevel == 1)).Select(x => x.DistributorSecondaryId).Contains(x.DistributorSecondaryId)).Sum(x => x.TotalPrice)) * 0.05;

                    if (distributor.Recomendations.Any(x => x.HierarchyLevel == 2))
                        distributorbonus += (activeTransaction.Where(x => (distributor.Recomendations.Where(x => x.HierarchyLevel == 2)).Select(x => x.DistributorSecondaryId).Contains(x.DistributorSecondaryId)).Sum(x => x.TotalPrice)) * 0.01;
                }
                DistributorBonuses.Add(new DistributorBonus()
                {
                    BonusAmount = distributorbonus,
                    FirstName = distributor.FirstName,
                    LastName = distributor.LastName,
                    Id = distributor.Id,
                });
            }


            return await Ok(new CalculationQueryResult { DistributorBonus = DistributorBonuses });
        }
    }
    public class CalculationQueryResult
    {
        public List<DistributorBonus> DistributorBonus { get; set; }
    }
    public class DistributorBonus
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public double BonusAmount { get; set; }
    }
}
