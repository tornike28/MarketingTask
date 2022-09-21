using Domain.Aggregates.DistributorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Infrastructure.Db.Configurations
{
    public class DistributorTypeConfiguration : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.Ignore(x => x.ContactInformation);
            builder.Property(x => x.ContactInformation).HasJsonConversion();

            builder.Ignore(x => x.IdInformation);
            builder.Property(x => x.IdInformation).HasJsonConversion();

            builder.Ignore(x => x.Address);
            builder.Property(x => x.Address).HasJsonConversion();

        }
    }
}
