using FluentValidation;

namespace Application.DistributorFeature.DistributorCommands.CreateDistributor
{
    public class CreateDistributorCommandValidation : AbstractValidator<CreateDistributorCommand>
    {
        public CreateDistributorCommandValidation()
        {

            RuleFor(x => x.Distributor.FirstName).NotEmpty().NotNull().MaximumLength(50).WithMessage("Uncorrect FirstName format");
            RuleFor(x => x.Distributor.LastName).NotEmpty().NotNull().MaximumLength(50).WithMessage("Uncorrect LastName format");
            RuleFor(x => x.Distributor.BirthDate).NotNull().WithMessage("Uncorrect BirthDate format");
            RuleFor(x => x.Distributor.Gender).NotNull().WithMessage("ImagePath cann't be null");
            RuleFor(x => x.Distributor.ImagePath).NotNull().WithMessage("ImagePath cann't be null");

            RuleFor(x => x.Distributor.IdInformation.DocumentType).NotNull().WithMessage("DocumentType cann't be null");

            RuleFor(x => x.Distributor.IdInformation.DocumentSeria)
                .MaximumLength(10)
                .When(x => !string.IsNullOrEmpty(x.Distributor.IdInformation.DocumentSeria));

            RuleFor(x => x.Distributor.IdInformation.DocumentNumber)
                .MaximumLength(10)
                .When(x => !string.IsNullOrEmpty(x.Distributor.IdInformation.DocumentNumber));

            RuleFor(x => x.Distributor.IdInformation.ExpirationDate).NotNull().WithMessage("ReleaseDate cann't be null");
            RuleFor(x => x.Distributor.IdInformation.ReleaseDate).NotNull().WithMessage("ReleaseDate cann't be null");
            RuleFor(x => x.Distributor.IdInformation.IdNumber).NotEmpty().NotNull().MaximumLength(50).WithMessage("Uncorrect IdNumber format");

            RuleFor(x => x.Distributor.IdInformation.Organization)
              .MaximumLength(100)
              .When(x => !string.IsNullOrEmpty(x.Distributor.IdInformation.Organization));

            RuleFor(x => x.Distributor.ContactInformation.ContactInformation).NotNull().WithMessage("ContactInformation cann't be null");
            RuleFor(x => x.Distributor.Address.Addess).NotNull().WithMessage("Addess cann't be null");

        }
    }
}
