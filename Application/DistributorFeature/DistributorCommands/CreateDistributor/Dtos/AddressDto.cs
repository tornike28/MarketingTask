using Domain.Aggregates;
using Domain.Aggregates.DistributorAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DistributorFeature.DistributorCommands.CreateDistributor.Dtos
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
