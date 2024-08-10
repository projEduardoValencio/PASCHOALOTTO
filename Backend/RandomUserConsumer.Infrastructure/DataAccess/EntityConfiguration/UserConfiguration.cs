using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Types;

namespace RandomUserConsumer.Infrastructure.DataAccess.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Gender)
            .HasConversion<string>(
                value => value.ToString(),
                value => new GenderType(value)
            );
        
        // Map Foreign Key to access the Contact entity
        builder
            .HasOne(u => u.Contact)
            .WithOne(c => c.User)
            .HasForeignKey<Contact>(c => c.IdUser);
        
        // Map Foreign Key to access the Address entity
        builder
            .HasOne(u => u.Address)
            .WithOne(a => a.User)
            .HasForeignKey<User>(c => c.IdAddress);
    }
}