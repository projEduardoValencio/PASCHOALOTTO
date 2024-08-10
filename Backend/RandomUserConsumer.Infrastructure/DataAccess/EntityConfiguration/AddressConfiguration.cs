using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Types;

namespace RandomUserConsumer.Infrastructure.DataAccess.EntityConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();
        
        builder
            .HasOne(a => a.Coordinate)
            .WithOne(c => c.Address)
            .HasForeignKey<Coordinate>(c => c.IdAddress);
    }
}