using Domain.Aggregates.DistributorAggregate.Events;
using Utility;

namespace Application.DomainEventHandlers
{
    public class CreateDistributorEventHandler : IDomainEventHandler<CreateDistributorEvent>
    {
        public Task Handle(CreateDistributorEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
