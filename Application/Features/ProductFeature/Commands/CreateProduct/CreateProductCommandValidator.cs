using FluentValidation;

namespace Application.Features.ProductFeature.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code cann't be null");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cann't be null");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price cann't be null");
        }
    }
}
