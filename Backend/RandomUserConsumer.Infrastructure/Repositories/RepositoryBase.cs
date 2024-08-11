using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Generics.Read;
using RandomUserConsumer.Domain.Interfaces.Generics.Write;
using RandomUserConsumer.Exceptions.Exceptions;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public abstract class RepositoryBase<T, IT> : IWriteOnly<T, IT>, IReadOnly<T, IT>, IWriteTransactional
    where T : EntityBase
{
    private readonly RandomUserConsumerDbContext _context;
    protected readonly DbSet<T> _dbSet;
    private IDbContextTransaction _transaction;

    protected RepositoryBase(RandomUserConsumerDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Delete(IT id)
    {
        T entity = await this.Find(id);

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Update(IT id, T entity)
    {
        T findedEntity = await this.Find(id);

        // After check, we need to update values of entity finded
        _context.Entry(findedEntity).CurrentValues.SetValues(entity);
        _context.SaveChanges();
        return entity;
    }

    public async Task<T> Find(IT id)
    {
        T entity = await _dbSet.FindAsync(id);

        if (entity is null) throw new NotFoundException("Entity not found. Id: " + id);

        return entity;
    }

    public abstract Task<List<T>> Search(int page, int pageSize, string? search);

    public abstract Task<int> Count(string? search);


    public async void BeginTransaction()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async void CommitTrasaction()
    {
        await _transaction.CommitAsync();
    }

    public async void RollbackTransaction()
    {
        await _transaction.RollbackAsync();
    }
}