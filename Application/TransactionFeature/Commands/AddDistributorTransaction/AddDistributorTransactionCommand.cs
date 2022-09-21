using Application.Shared;
using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.ProductAggregate;
using Domain.Aggregates.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application.TransactionFeature.Commands.AddDistributorTransaction
{
    public class AddDistributorTransactionCommand : Command
    {
        public DistributorTransactionRequest Transaction { get; set; }
        public override async Task<CommandExecutionResult> ExecuteAsync()
        {
           var product = ApplicationDbContext.Set<Product>()
                                             .SingleOrDefault(x=>x.Id == Transaction.ProductId);

            if (product == null)
                return await Fail(ErrorCode.ProductNotFound);

            var distributor = ApplicationDbContext.Set<Distributor>()
                                                  .SingleOrDefault(x => x.Id == Transaction.DistributorId);

            if (product == null)
                return await Fail(ErrorCode.DistributorNotFound);

            return await TransactionReposiotry.AddTransaction(new Transaction(distributor,Transaction.SaleDate,product,Transaction.ProductPrice,Transaction.UnitPrice,Transaction.TotalPrice));
        }
    }
}
