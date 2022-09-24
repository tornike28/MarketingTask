using Application.Shared;
using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.ProductAggregate;
using Domain.Aggregates.TransactionAggregate;
using Domain.Aggregates.TransactionAggregate.IRepository;
using Infrastructure.Db;
using Utility;

namespace Application.Features.TransactionFeature.Commands.AddDistributorTransaction
{
    public class AddDistributorTransactionCommandHandler : CommandHandler<AddDistributorTransactionCommand>
    {
        private readonly ITransactionRepository TransactionReposiotry;
        private readonly ApplicationDbContext ApplicationDbContext;

        public AddDistributorTransactionCommandHandler(
            IServiceProvider serviceProvider,
            ITransactionRepository transactionReposiotry,
            ApplicationDbContext applicationDbContext) : base(serviceProvider)
        {
            TransactionReposiotry = transactionReposiotry;
            ApplicationDbContext = applicationDbContext;
        }

        public override async Task<CommandExecutionResult> Handle(AddDistributorTransactionCommand request, CancellationToken cancellationToken)
        {
            var product = ApplicationDbContext.Set<Product>()
                                             .SingleOrDefault(x => x.Id == request.ProductId);

            if (product == null)
                return await Fail(ErrorCode.ProductNotFound);

            var distributor = ApplicationDbContext.Set<Distributor>()
                                                  .SingleOrDefault(x => x.Id == request.DistributorId);

            if (product == null)
                return await Fail(ErrorCode.DistributorNotFound);

            return await TransactionReposiotry.AddTransaction(
                   new Transaction(
                                   distributor,
                                   request.SaleDate,
                                   product,
                                   request.ProductPrice,
                                   request.UnitPrice,
                                   request.TotalPrice));
        }
    }
}
