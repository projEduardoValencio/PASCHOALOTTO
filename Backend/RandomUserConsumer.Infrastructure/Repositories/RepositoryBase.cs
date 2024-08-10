using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public abstract class RepositoryBase
{
    private readonly RandomUserConsumerDbContext _context;

    protected RepositoryBase(RandomUserConsumerDbContext context) => _context = context;
}