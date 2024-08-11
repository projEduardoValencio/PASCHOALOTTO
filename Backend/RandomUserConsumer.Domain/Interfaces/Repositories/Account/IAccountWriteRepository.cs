using RandomUserConsumer.Domain.Interfaces.Generics.Write;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Account;

public interface IAccountWriteRepository : IWriteOnly<Entities.Account, int>
{
}