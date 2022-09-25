using Domain.Aggregates;
using Domain.Aggregates.DistributorAggregate.ValueObjects;

namespace Application.Features.DistributorFeature.DistributorCommands.CreateDistributor.Dtos
{
    public class AddressDto
    {
        public AddressType AddressType { get; set; }
        public string Addess { get; set; } = string.Empty;


        public Address ToDomainModel()
        {
            return new Address(AddressType, Addess);
        }
    }
}
