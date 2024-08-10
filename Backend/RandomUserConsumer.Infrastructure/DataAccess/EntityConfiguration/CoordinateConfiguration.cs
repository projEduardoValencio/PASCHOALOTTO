using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Types;

namespace RandomUserConsumer.Infrastructure.DataAccess.EntityConfiguration;

public class CoordinateConfiguration : IEntityTypeConfiguration<Coordinate>
{
    public void Configure(EntityTypeBuilder<Coordinate> builder)
    {
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();
    }
}