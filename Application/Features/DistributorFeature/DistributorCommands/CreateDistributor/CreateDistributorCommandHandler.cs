using Application.Shared;
using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.DistributorAggregate.IRepository;
using Infrastructure.Db;
using Utility;

namespace Application.Features.DistributorFeature.DistributorCommands.CreateDistributor
{
    public class CreateDistributorCommandHandler : CommandHandler<CreateDistributorCommand>
    {
        private readonly IDistributorRepository _distributorRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public CreateDistributorCommandHandler(
            IServiceProvider serviceProvider,
            ApplicationDbContext applicationDbContext,
            IDistributorRepository distributorRepository) : base(serviceProvider)
        {
            _applicationDbContext = applicationDbContext;
            _distributorRepository = distributorRepository;
        }

        public override async Task<CommandExecutionResult> Handle(CreateDistributorCommand request, CancellationToken cancellationToken)
        {

            var distributor = new Distributor(
                                            request.FirstName,
                                            request.LastName,
                                            request.BirthDate,
                                            request.Gender,
                                            request.ImagePath,
                                            request.IdInformation.ToDomainModel(),
                                            request.ContactInformation.ToDomainModel(),
                                            request.Address.ToDomainModel()
                                            );

            if (request.Recommendedby.HasValue)
            {
                var recomendator = _applicationDbContext
                                                        .Set<Distributor>()
                                                        .SingleOrDefault(x => x.Id == request.Recommendedby.Value);

                if (recomendator.Recomendations.Any() && recomendator.Recomendations.Count(x => x.HierarchyLevel == 1) >= 3)
                    return await Fail("The max recommendation for one distributor Could be 3");

                if (recomendator == null)
                    return await Fail("Recommendator not found");

                if (recomendator.HierarchyLevel == 5)
                    return await Fail("Max Depth Of Recommendation Hierarchy");


                distributor.SetMemberBy(request.Recommendedby.Value, recomendator.HierarchyLevel, recomendator.Recommendedby);
            }

            return await _distributorRepository.CreateDistributor(distributor);
        }
    }
}
