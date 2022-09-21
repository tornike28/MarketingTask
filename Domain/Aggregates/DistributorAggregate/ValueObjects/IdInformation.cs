using Utility;

namespace Domain.Aggregates.DistributorAggregate.ValueObjects
{
    public class IdInformation : ValueObject
    {
        public IdInformation(
            DocumentType documentType,
            string? documentSeria,
            string? documentNumber,
            DateTime releaseDate,
            DateTime expirationDate,
            string idNumber,
            string? organization
            )
        {
            if (string.IsNullOrWhiteSpace(idNumber))
                ThrowDomainException("IdNumber value cann't be null");

            DocumentType = documentType;
            DocumentSeria = documentSeria;
            DocumentNumber = documentNumber;
            ReleaseDate = releaseDate;
            ExpirationDate = expirationDate;
            IdNumber = idNumber;
            Organization = organization;
        }

        public DocumentType DocumentType { get; private set; }
        public string? DocumentSeria { get; private set; }
        public string? DocumentNumber { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string IdNumber { get; private set; }
        public string? Organization { get; private set; }
    }
}
