using Microsoft.EntityFrameworkCore;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.User;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User, int>, IUserWriteRepository, IUserReadOnlyRepository
{
    public UserRepository(RandomUserConsumerDbContext context) : base(context)
    {
    }

    public override async Task<List<User>> Search(int page, int pageSize, string? search)
    {
        int skip = (page - 1) * pageSize;

        var query = _dbSet
            .Include(u => u.Contact)
            .Include(u => u.Address)
            .Skip(skip)
            .Take(pageSize);

        if (!String.IsNullOrWhiteSpace(search))
        {
            return await query
                .Where(u => EF.Functions.ILike(u.Name, $"%{search}%"))
                .ToListAsync();
        }

        return await query.ToListAsync();
    }

    public override async Task<int> Count(string? search)
    {
        if (!String.IsNullOrWhiteSpace(search))
        {
            return await _dbSet.CountAsync(u => EF.Functions.ILike(u.Name, $"%{search}%"));
        }

        return await _dbSet.CountAsync();
    }
}