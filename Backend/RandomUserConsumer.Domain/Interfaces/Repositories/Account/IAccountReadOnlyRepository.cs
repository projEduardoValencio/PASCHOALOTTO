using RandomUserConsumer.Domain.Interfaces.Generics.Read;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Account;

public interface IAccountReadOnlyRepository : IReadOnly<Entities.Account, int>
{
}