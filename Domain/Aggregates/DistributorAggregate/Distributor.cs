using Domain.Aggregates.DistributorAggregate.Events;
using Domain.Aggregates.DistributorAggregate.ValueObjects;
using Domain.Aggregates.TransactionAggregate;
using Utility;

namespace Domain.Aggregates.DistributorAggregate
{
    public class Distributor : AggregateRoot
    {
        public Distributor()
        {

        }

        public Distributor(
            string firstName,
            string lastName,
            DateTime birthDate,
            Gender gender,
            string imagePath,
            IdInformation idInformation,
            ContactInformation contactInformation,
            Address address
            )
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            ImagePath = imagePath;
            IdInformation = idInformation;
            ContactInformation = contactInformation;
            Address = address;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public string ImagePath { get; private set; }
        public IdInformation IdInformation { get; private set; }
        public ContactInformation ContactInformation { get; private set; }
        public Address Address { get; private set; }
        public int HierarchyLevel { get; private set; }
        public int? Recommendedby { get; private set; }

        public List<Recomendation> Recomendations = new List<Recomendation>();

        public void SetMemberBy(int recommendedby, int? hierarchyLevel, int? recomendatorId)
        {
            if (hierarchyLevel == null)
                HierarchyLevel = 1;
            else
            {
                HierarchyLevel = hierarchyLevel.Value + 1;
            }

            Recommendedby = recommendedby;

            Raise(new CreateDistributorEvent(recommendedby, this.SecondaryId,  recomendatorId));
        }

        public void AddRecomendator(Recomendation recomendation)
        {
            Recomendations.Add(recomendation);
        }
    }
}
