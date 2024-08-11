using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Account;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public class AccountRepository : RepositoryBase<Account, int>, IAccountWriteRepository, IAccountReadOnlyRepository
{
    private readonly RandomUserConsumerDbContext _context;

    public AccountRepository(RandomUserConsumerDbContext context) : base(context)
    {
        _context = context;
    }

    public override Task<List<Account>> Search(int page, int pageSize, string search)
    {
        throw new NotImplementedException();
    }
}