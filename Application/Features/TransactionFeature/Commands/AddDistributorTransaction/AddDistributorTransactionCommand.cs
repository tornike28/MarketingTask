using MediatR;
using Utility;

namespace Application.Features.TransactionFeature.Commands.AddDistributorTransaction
{
    public class AddDistributorTransactionCommand : IRequest<CommandExecutionResult>
    {
        public int DistributorId { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
