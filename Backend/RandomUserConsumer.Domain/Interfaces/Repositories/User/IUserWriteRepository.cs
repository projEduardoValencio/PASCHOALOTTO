using RandomUserConsumer.Domain.Entities;

namespace RandomUserConsumer.Domain.Repositories;

public interface IUserWriteRepository
{
    public Task AddUser(User user);
}