using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RandomUserConsumer.Domain.Entities;

namespace RandomUserConsumer.Infrastructure.DataAccess.EntityConfiguration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();
        
        builder
            .HasOne(a => a.Login)
            .WithOne(l => l.Account)
            .HasForeignKey<Account>(a=> a.IdLogin);
        
        builder
            .HasOne(a => a.User)
            .WithOne(u => u.Account)
            .HasForeignKey<Account>(a=> a.IdUser);
    }
}