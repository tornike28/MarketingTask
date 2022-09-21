using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.DistributorAggregate.ValueObjects;

namespace Application.DistributorFeature.DistributorCommands.CreateDistributor.Dtos
{
    public class IdInformationDto
    {
        public DocumentType DocumentType { get; set; }
        public string? DocumentSeria { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string IdNumber { get; set; } = string.Empty;
        public string? Organization { get; set; }



        public IdInformation ToDomainModel()
        {
            return new IdInformation(DocumentType,
                                     DocumentSeria,
                                     DocumentNumber,
                                     ReleaseDate,
                                     ExpirationDate,
                                     IdNumber,
                                     Organization);
        }
    }
}
