using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.DistributorAggregate.ValueObjects;

namespace Application.Features.DistributorFeature.DistributorCommands.CreateDistributor.Dtos
{
    public class ContactDto
    {
        public ContactType ContactType { get; set; }
        public string ContactInformation { get; set; } = string.Empty;


        public ContactInformation ToDomainModel()
        {
            return new ContactInformation(ContactType, ContactInformation);
        }
    }
}
