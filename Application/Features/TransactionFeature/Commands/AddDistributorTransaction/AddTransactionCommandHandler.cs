using Application.Shared;
using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.TransactionAggregate;
using Domain.Aggregates.TransactionAggregate.IRepository;
using Infrastructure.Db;
using Utility;

namespace Application.Features.TransactionFeature.Commands.AddDistributorTransaction
{
    public class AddTransactionCommandHandler : CommandHandler<AddTransactionCommand>
    {
        private readonly ITransactionRepository _transactionReposiotry;
        private readonly ApplicationDbContext _applicationDbContext;

        public AddTransactionCommandHandler(
            ApplicationDbContext applicationDbContext,
            IServiceProvider serviceProvider,
            ITransactionRepository transactionReposiotry) : base(serviceProvider)
        {
            _applicationDbContext = applicationDbContext;
            _transactionReposiotry = transactionReposiotry;
        }

        public override async Task<CommandExecutionResult> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var distributor = _applicationDbContext.Set<Distributor>().SingleOrDefault(x => x.Id == request.DistributorId);

            if (distributor == null)
                return await Fail("distributor not found");

            return await _transactionReposiotry.AddTransaction(
                   new Transaction(
                                   request.DistributorId,
                                   distributor.SecondaryId,
                                   request.SaleDate,
                                   request.ProductId,
                                   request.ProductPrice,
                                   request.UnitPrice,
                                   request.TotalPrice));
        }
    }
}
