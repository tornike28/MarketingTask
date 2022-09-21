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
            Address address,
            int? recommendedby
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
            Recommendedby = recommendedby;

            Raise(new CreateDistributorEvent());
        }


        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public string ImagePath { get; private set; }
        public IdInformation IdInformation { get; private set; }
        public ContactInformation ContactInformation { get; private set; }
        public Address Address { get; private set; }
        public int? Recommendedby { get; private set; }
        public virtual ICollection<Transaction> Transactions { get; private set; }
    }
}
