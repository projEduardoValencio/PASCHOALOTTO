using Microsoft.EntityFrameworkCore;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Repositories;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public class UserRepository : RepositoryBase, IUserWriteRepository, IUserReadOnlyRepository
{
    private readonly RandomUserConsumerDbContext _context;

    public UserRepository(RandomUserConsumerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<User>> ListUsers(int count,int page, string? search)
    {
        int skip = (page - 1) * count;
        IQueryable<User> query = _context.Users
            .Include(u=>u.Contact)
            .Include(u=>u.Address)
            .Skip(skip)
            .Take(count);
        // return await query.Where(u=>u.Name.Contains(search ?? String.Empty)).ToListAsync();
        return await query.ToListAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return  await _context.Users.FindAsync(id);
    }
    
    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
    }
}