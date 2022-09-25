using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.DistributorAggregate.Events;
using Infrastructure.Db;
using Utility;

namespace Application.DomainEventHandlers
{
    public class CreateDistributorEventHandler : IDomainEventHandler<CreateDistributorEvent>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CreateDistributorEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task Handle(CreateDistributorEvent @event, CancellationToken cancellationToken)
        {
            var distributor = _applicationDbContext.Set<Distributor>().SingleOrDefault(x => x.Id == @event.Recommendedby);

            var recomendation = new Recomendation(@event.SecondaryId, 1);

            distributor.AddRecomendator(recomendation);

            if (@event.RecomendatorId != null)
            {
                var recommendator = _applicationDbContext.Set<Distributor>().SingleOrDefault(x => x.Id == @event.RecomendatorId);


                recomendation.IncreaseLevel();
                recommendator.AddRecomendator(recomendation);
            }

            _applicationDbContext.SaveChanges();
        }
    }
}
