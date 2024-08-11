using Microsoft.EntityFrameworkCore;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.User;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User, int>, IUserWriteRepository, IUserReadOnlyRepository
{
    private readonly RandomUserConsumerDbContext _context;

    public UserRepository(RandomUserConsumerDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<List<User>> Search(int page, int pageSize, string search)
    {
        int skip = (page - 1) * pageSize;
        
        return await _context.Users
            .Include(u=>u.Contact)
            .Include(u=>u.Address)
            .Skip(skip)
            .Take(pageSize)
            .Where(u=>u.Name.Contains(search ?? String.Empty)).ToListAsync();
    }
}