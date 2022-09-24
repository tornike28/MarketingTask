using Application.Shared;
using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.DistributorAggregate.IRepository;
using Utility;

namespace Application.Features.DistributorFeature.DistributorCommands.CreateDistributor
{
    public class CreateDistributorCommandHandler : CommandHandler<CreateDistributorCommand>
    {
        private readonly IDistributorRepository DistributorRepository;

        public CreateDistributorCommandHandler(
            IServiceProvider serviceProvider, 
            IDistributorRepository distributorRepository) : base(serviceProvider)
        {
            DistributorRepository = distributorRepository;
        }

        public override async Task<CommandExecutionResult> Handle(CreateDistributorCommand request, CancellationToken cancellationToken)
        {
            if (request.Recommendedby.HasValue)
            {
                //check on count
            }

            var distributor = new Distributor(
                                              request.FirstName,
                                              request.LastName,
                                              request.BirthDate,
                                              request.Gender,
                                              request.ImagePath,
                                              request.IdInformation.ToDomainModel(),
                                              request.ContactInformation.ToDomainModel(),
                                              request.Address.ToDomainModel(),
                                              request.Recommendedby
                                              );

            return await DistributorRepository.CreateDistributor(distributor);
        }
    }
}
