using Application.DistributorFeature.DistributorCommands.CreateDistributor.Dtos;
using Application.Shared;
using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.DistributorAggregate.IRepository;
using FluentValidation.Attributes;
using Utility;

namespace Application.DistributorFeature.DistributorCommands.CreateDistributor
{
    [Validator(typeof(CreateDistributorCommandValidation))]

    public class CreateDistributorCommand : Command
    {
        public CreateDistributorRequest Distributor { get; set; }

        public override async Task<CommandExecutionResult> ExecuteAsync()
        {
            if (Distributor.Recommendedby.HasValue)
            {
                //check on count
            }

            var distributor = new Distributor(
                                              Distributor.FirstName,
                                              Distributor.LastName,
                                              Distributor.BirthDate,
                                              Distributor.Gender,
                                              Distributor.ImagePath,
                                              Distributor.IdInformation.ToDomainModel(),
                                              Distributor.ContactInformation.ToDomainModel(),
                                              Distributor.Address.ToDomainModel(),
                                              Distributor.Recommendedby
                                              );

            return await DistributorRepository.CreateDistributor(distributor);

        }
    }
}
