using FluentValidation;

namespace Application.TransactionFeature.Commands.AddDistributorTransaction
{
    public class AddDistributorTransactionCommandValidator : AbstractValidator<AddDistributorTransactionCommand>
    {
        public AddDistributorTransactionCommandValidator()
        {
            RuleFor(x => x.Transaction.ProductPrice).NotEmpty().WithMessage("");
            RuleFor(x => x.Transaction.UnitPrice).NotEmpty().WithMessage("");
            RuleFor(x => x.Transaction.DistributorId).NotEmpty().WithMessage("");
            RuleFor(x => x.Transaction.TotalPrice).NotEmpty().WithMessage("");
            RuleFor(x => x.Transaction.ProductId).NotEmpty().WithMessage("");
        }
    }
}
