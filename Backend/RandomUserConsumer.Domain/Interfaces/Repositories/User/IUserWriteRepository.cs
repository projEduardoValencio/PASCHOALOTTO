using RandomUserConsumer.Domain.Interfaces.Generics.Write;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.User;

public interface IUserWriteRepository : IWriteOnly<Entities.User, int>, IWriteTransactional
{
}