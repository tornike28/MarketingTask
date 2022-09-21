using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Domain.Aggregates.DistributorAggregate.ValueObjects
{
    public class ContactInformation : ValueObject
    {
        public ContactInformation(
            ContactType contactType,
            string cotactInformation)
        {
            if (string.IsNullOrWhiteSpace(cotactInformation))
                ThrowDomainException("Contact information cann't be null");

            ContactType = contactType;
            CotactInformation = cotactInformation;
        }

        public ContactType ContactType { get; private set; }
        public string CotactInformation { get; private set; }
    }
}
