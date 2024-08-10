using RandomUserConsumer.Domain.Entities;

namespace RandomUserConsumer.Domain.Repositories;

public interface IUserReadOnlyRepository
{
    public Task<List<Domain.Entities.User>> ListUsers(int count, int page, string? search);
    public Task<User?> GetUserById(int id);
}