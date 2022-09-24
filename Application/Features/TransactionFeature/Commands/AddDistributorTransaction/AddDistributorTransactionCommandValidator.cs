using FluentValidation;

namespace Application.Features.TransactionFeature.Commands.AddDistributorTransaction
{
    public class AddDistributorTransactionCommandValidator : AbstractValidator<AddDistributorTransactionCommand>
    {
        public AddDistributorTransactionCommandValidator()
        {
            RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("ProductPrice cann't be null");
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("UnitPrice cann't be null");
            RuleFor(x => x.DistributorId).NotEmpty().WithMessage("DistributorId cann't be null");
            RuleFor(x => x.TotalPrice).NotEmpty().WithMessage("TotalPrice cann't be null");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId cann't be null");
        }
    }
}
