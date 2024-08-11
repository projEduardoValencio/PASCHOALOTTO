using RandomUserConsumer.Domain.Interfaces.Generics.Read;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Login;

public interface ILoginReadOnlyRepository : IReadOnly<Entities.Login, int>
{
}