using Domain.Aggregates.DistributorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utility;

namespace Infrastructure.Db.Configurations
{
    public class DistributorTypeConfiguration : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.OwnsOne(x => x.Address, navigationBuilder => { });

            builder.OwnsOne(x => x.ContactInformation, navigationBuilder => { });

            builder.OwnsOne(x => x.IdInformation, navigationBuilder => { });

            builder.Property(x => x.Recomendations).HasJsonConversion();

            builder.HasIndex(x => x.FirstName);

            builder.HasIndex(x => x.LastName);
        }
    }
}
