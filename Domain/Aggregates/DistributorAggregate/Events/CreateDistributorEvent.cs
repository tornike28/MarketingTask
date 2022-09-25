using MediatR;

namespace Domain.Aggregates.DistributorAggregate.Events
{
    public class CreateDistributorEvent : INotification
    {
        public CreateDistributorEvent
            (int recommendedby,
            string secondaryId,
            int? recomendatorId)
        {
            Recommendedby = recommendedby;
            SecondaryId = secondaryId;
            RecomendatorId = recomendatorId;
        }

        public int Recommendedby { get; }
        public string SecondaryId { get; }
        public int? RecomendatorId { get; }
    }
}
