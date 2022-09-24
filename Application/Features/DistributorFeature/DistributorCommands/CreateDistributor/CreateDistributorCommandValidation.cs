using FluentValidation;

namespace Application.Features.DistributorFeature.DistributorCommands.CreateDistributor
{
    public class CreateDistributorCommandValidation : AbstractValidator<CreateDistributorCommand>
    {
        public CreateDistributorCommandValidation()
        {

            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50).WithMessage("Uncorrect FirstName format");
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50).WithMessage("Uncorrect LastName format");
            RuleFor(x => x.BirthDate).NotNull().WithMessage("Uncorrect BirthDate format");
            RuleFor(x => x.Gender).NotNull().WithMessage("ImagePath cann't be null");
            RuleFor(x => x.ImagePath).NotNull().WithMessage("ImagePath cann't be null");

            RuleFor(x => x.IdInformation.DocumentType).NotNull().WithMessage("DocumentType cann't be null");

            RuleFor(x => x.IdInformation.DocumentSeria)
                .MaximumLength(10)
                .When(x => !string.IsNullOrEmpty(x.IdInformation.DocumentSeria));

            RuleFor(x => x.IdInformation.DocumentNumber)
                .MaximumLength(10)
                .When(x => !string.IsNullOrEmpty(x.IdInformation.DocumentNumber));

            RuleFor(x => x.IdInformation.ExpirationDate).NotNull().WithMessage("ReleaseDate cann't be null");
            RuleFor(x => x.IdInformation.ReleaseDate).NotNull().WithMessage("ReleaseDate cann't be null");
            RuleFor(x => x.IdInformation.IdNumber).NotEmpty().MaximumLength(50).WithMessage("Uncorrect IdNumber format");

            RuleFor(x => x.IdInformation.Organization)
              .MaximumLength(100)
              .When(x => !string.IsNullOrEmpty(x.IdInformation.Organization));

            RuleFor(x => x.ContactInformation.ContactInformation).NotNull().WithMessage("ContactInformation cann't be null");
            RuleFor(x => x.Address.Addess).NotNull().WithMessage("Addess cann't be null");

        }
    }
}
