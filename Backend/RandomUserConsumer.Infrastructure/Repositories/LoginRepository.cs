using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Login;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public class LoginRepository : RepositoryBase<Login, int>, ILoginWriteRepository, ILoginReadOnlyRepository
{
    private readonly RandomUserConsumerDbContext _context;

    public LoginRepository(RandomUserConsumerDbContext context) : base(context)
    {
        _context = context;
    }

    public override Task<List<Login>> Search(int page, int pageSize, string search)
    {
        throw new NotImplementedException();
    }
}