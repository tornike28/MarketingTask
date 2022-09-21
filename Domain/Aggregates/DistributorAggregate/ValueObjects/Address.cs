using Utility;

namespace Domain.Aggregates.DistributorAggregate.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(
            AddressType addressType,
            string fullAddress)
        {
            if (string.IsNullOrWhiteSpace(fullAddress))
                ThrowDomainException("Address cann't be null");

            AddressType = addressType;
            FullAddress = fullAddress;
        }

        public AddressType AddressType { get; private set; }
        public string FullAddress { get; private set; }
    }
}
