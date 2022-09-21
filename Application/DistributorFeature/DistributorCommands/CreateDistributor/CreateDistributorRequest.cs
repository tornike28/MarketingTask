using Application.DistributorFeature.DistributorCommands.CreateDistributor.Dtos;
using Domain.Aggregates.DistributorAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DistributorFeature.DistributorCommands.CreateDistributor
{
    public class CreateDistributorRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public IdInformationDto IdInformation { get; set; }
        public ContactDto ContactInformation { get; set; }
        public AddressDto Address { get; set; }
        public int? Recommendedby { get; set; }
    }
}
