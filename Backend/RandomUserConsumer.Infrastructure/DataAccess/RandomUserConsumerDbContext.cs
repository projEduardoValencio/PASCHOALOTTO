using Microsoft.EntityFrameworkCore;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Types;

namespace RandomUserConsumer.Infrastructure.DataAccess;

public class RandomUserConsumerDbContext : DbContext
{
    public RandomUserConsumerDbContext(DbContextOptions<RandomUserConsumerDbContext> options) : base(options) { }
    
    internal DbSet<User> Users { get; set; }
    internal DbSet<Contact> Contacts { get; set; }
    internal DbSet<Account> Accounts { get; set; }
    internal DbSet<Address> Addresses { get; set; }
    internal DbSet<Coordinate> Coordinates { get; set; }
    internal DbSet<Login> Logins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RandomUserConsumerDbContext).Assembly);
    }
}