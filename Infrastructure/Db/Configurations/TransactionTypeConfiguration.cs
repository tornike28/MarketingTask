using Domain.Aggregates.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db.Configurations
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(d => d.Distributor)
                   .WithMany(x => x.Transactions);

            builder.HasOne(d => d.Product)
                   .WithMany(x => x.Transactions);
        }
    }
}
