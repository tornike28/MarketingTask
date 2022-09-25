using MediatR;
using Utility;

namespace Application.Features.TransactionFeature.Commands.AddDistributorTransaction
{
    public class AddTransactionCommand : IRequest<CommandExecutionResult>
    {
        public int DistributorId { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductId { get; set; }
        public double ProductPrice { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
    }
}
