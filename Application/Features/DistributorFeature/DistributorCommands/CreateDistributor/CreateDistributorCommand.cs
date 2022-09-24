using Application.Features.DistributorFeature.DistributorCommands.CreateDistributor.Dtos;
using Domain.Aggregates.DistributorAggregate;
using MediatR;
using Utility;

namespace Application.Features.DistributorFeature.DistributorCommands.CreateDistributor
{
    public class CreateDistributorCommand : IRequest<CommandExecutionResult>
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
