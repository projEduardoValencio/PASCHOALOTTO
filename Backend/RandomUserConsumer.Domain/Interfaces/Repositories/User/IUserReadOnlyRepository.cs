using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Generics.Read;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.User;

public interface IUserReadOnlyRepository : IReadOnly<Entities.User, int>
{
    Task<List<Entities.User>> ListAll();
}